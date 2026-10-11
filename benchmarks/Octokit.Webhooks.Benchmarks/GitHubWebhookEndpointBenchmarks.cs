namespace Octokit.Webhooks.Benchmarks;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Octokit.Webhooks.AspNetCore;
using Octokit.Webhooks.TestUtils;

/// <summary>
/// Benchmarks the full ASP.NET Core endpoint added by <see cref="GitHubWebhookExtensions.MapGitHubWebhooks"/>:
/// content type and event header validation, reading the request body, signature verification and dispatch.
/// </summary>
[MemoryDiagnoser]
public class GitHubWebhookEndpointBenchmarks
{
    private const string Secret = "benchmark-webhook-secret";

    private ServiceProvider serviceProvider = null!;
    private RequestDelegate requestDelegate = null!;

    private DefaultHttpContext pushContext = null!;
    private DefaultHttpContext issuesContext = null!;
    private DefaultHttpContext pullRequestContext = null!;

    [GlobalSetup]
    public async Task SetupAsync()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddRouting();
        services.AddSingleton<WebhookEventProcessor, BenchmarkWebhookEventProcessor>();

        this.serviceProvider = services.BuildServiceProvider();

        var routeBuilder = new BenchmarkEndpointRouteBuilder(this.serviceProvider);
        routeBuilder.MapGitHubWebhooks(secret: Secret);

        this.requestDelegate = routeBuilder.DataSources
            .SelectMany(dataSource => dataSource.Endpoints)
            .OfType<RouteEndpoint>()
            .Single()
            .RequestDelegate!;

        this.pushContext = await this.CreateContextAsync("push", "push/payload.json").ConfigureAwait(false);
        this.issuesContext = await this.CreateContextAsync("issues", "issues/opened.payload.json").ConfigureAwait(false);
        this.pullRequestContext = await this.CreateContextAsync("pull_request", "pull_request/opened.payload.json").ConfigureAwait(false);
    }

    [GlobalCleanup]
    public void Cleanup() => this.serviceProvider.Dispose();

    [Benchmark]
    public Task HandlePushWebhookAsync() => this.InvokeAsync(this.pushContext);

    [Benchmark]
    public Task HandleIssuesWebhookAsync() => this.InvokeAsync(this.issuesContext);

    [Benchmark]
    public Task HandlePullRequestWebhookAsync() => this.InvokeAsync(this.pullRequestContext);

    private static string ComputeSignature(string secret, byte[] body)
    {
        var hash = HMACSHA256.HashData(Encoding.UTF8.GetBytes(secret), body);
        return $"sha256={Convert.ToHexString(hash).ToLowerInvariant()}";
    }

    private Task InvokeAsync(DefaultHttpContext context)
    {
        context.Request.Body.Position = 0;
        context.Response.StatusCode = StatusCodes.Status200OK;
        return this.requestDelegate(context);
    }

    private async Task<DefaultHttpContext> CreateContextAsync(string eventName, string resource)
    {
        var body = Encoding.UTF8.GetBytes(ResourceUtils.ReadResource(resource));

        var context = new DefaultHttpContext
        {
            RequestServices = this.serviceProvider,
        };

        context.Request.Method = HttpMethods.Post;
        context.Request.ContentType = "application/json";
        context.Request.ContentLength = body.Length;
        context.Request.Headers["X-GitHub-Event"] = eventName;
        context.Request.Headers["X-GitHub-Delivery"] = Guid.NewGuid().ToString();
        context.Request.Headers["X-GitHub-Hook-ID"] = "12345";
        context.Request.Headers["X-Hub-Signature-256"] = ComputeSignature(Secret, body);
        context.Request.Body = new MemoryStream(body, writable: false);

        // Verify that the benchmark exercises the happy path rather than an error response
        await this.InvokeAsync(context).ConfigureAwait(false);

        if (context.Response.StatusCode != StatusCodes.Status200OK)
        {
            throw new InvalidOperationException($"The {eventName} benchmark request returned HTTP {context.Response.StatusCode}.");
        }

        return context;
    }

    private sealed class BenchmarkEndpointRouteBuilder(IServiceProvider serviceProvider) : IEndpointRouteBuilder
    {
        public ICollection<EndpointDataSource> DataSources { get; } = [];

        public IServiceProvider ServiceProvider { get; } = serviceProvider;

        public IApplicationBuilder CreateApplicationBuilder() => new ApplicationBuilder(this.ServiceProvider);
    }
}
