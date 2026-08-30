namespace Octokit.Webhooks.AspNetCore.Test;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AwesomeAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Xunit;

public class GitHubWebhookExtensionsTests
{
    [Fact]
    public async Task ProcessingException_WithoutHandler_ReturnsInternalServerError()
    {
        var exception = new InvalidOperationException();

        var context = await InvokeEndpointAsync(
            exception,
            cancellationToken: TestContext.Current.CancellationToken).ConfigureAwait(true);

        context.Response.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
    }

    [Fact]
    public async Task ProcessingException_HandlerReturnsFalse_ReturnsInternalServerError()
    {
        var exception = new InvalidOperationException();
        Exception? actualException = null;
        HttpContext? actualContext = null;

        var context = await InvokeEndpointAsync(
            exception,
            (caughtException, httpContext) =>
            {
                actualException = caughtException;
                actualContext = httpContext;
                return ValueTask.FromResult(false);
            },
            TestContext.Current.CancellationToken).ConfigureAwait(true);

        context.Response.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        actualException.Should().BeSameAs(exception);
        actualContext.Should().BeSameAs(context);
    }

    [Fact]
    public async Task ProcessingException_HandlerReturnsTrue_PreservesResponse()
    {
        var exception = new InvalidOperationException();

        var context = await InvokeEndpointAsync(
            exception,
            (_, httpContext) =>
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                return ValueTask.FromResult(true);
            },
            TestContext.Current.CancellationToken).ConfigureAwait(true);

        context.Response.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
    }

    [Fact]
    public async Task RequestCancelled_DoesNotInvokeHandler()
    {
        var handlerInvoked = false;
        using var cancellationTokenSource = new CancellationTokenSource();
        await cancellationTokenSource.CancelAsync().ConfigureAwait(true);

        _ = await InvokeEndpointAsync(
            new InvalidOperationException(),
            (_, _) =>
            {
                handlerInvoked = true;
                return ValueTask.FromResult(true);
            },
            cancellationTokenSource.Token).ConfigureAwait(true);

        handlerInvoked.Should().BeFalse();
    }

    private static async Task<DefaultHttpContext> InvokeEndpointAsync(
        Exception exception,
        Func<Exception, HttpContext, ValueTask<bool>>? exceptionHandler = null,
        CancellationToken cancellationToken = default)
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddRouting();
        services.AddSingleton<WebhookEventProcessor>(new ThrowingWebhookEventProcessor(exception));

        if (exceptionHandler is not null)
        {
            services.Configure<GitHubWebhookOptions>(options => options.ExceptionHandler = exceptionHandler);
        }

        await using var serviceProvider = services.BuildServiceProvider();
        var routeBuilder = new TestEndpointRouteBuilder(serviceProvider);
        routeBuilder.MapGitHubWebhooks();

        var endpoint = routeBuilder.DataSources
            .SelectMany(dataSource => dataSource.Endpoints)
            .OfType<RouteEndpoint>()
            .Single();

        var context = new DefaultHttpContext
        {
            RequestServices = serviceProvider,
        };
        context.Request.ContentType = "application/json";
        context.Request.Headers["X-GitHub-Event"] = "issues";
        context.Request.Body = new MemoryStream("{}"u8.ToArray());
        context.RequestAborted = cancellationToken;

        await endpoint.RequestDelegate!(context).ConfigureAwait(true);
        return context;
    }

    private sealed class ThrowingWebhookEventProcessor(Exception exception) : WebhookEventProcessor
    {
        public override ValueTask ProcessWebhookAsync(
            IDictionary<string, StringValues> headers,
            string body,
            CancellationToken cancellationToken = default) =>
            ValueTask.FromException(exception);
    }

    private sealed class TestEndpointRouteBuilder(IServiceProvider serviceProvider) : IEndpointRouteBuilder
    {
        public ICollection<EndpointDataSource> DataSources { get; } = [];

        public IServiceProvider ServiceProvider { get; } = serviceProvider;

        public IApplicationBuilder CreateApplicationBuilder() => new ApplicationBuilder(this.ServiceProvider);
    }
}
