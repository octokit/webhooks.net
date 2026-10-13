namespace Octokit.Webhooks.AspNetCore.Test;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AwesomeAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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

    [Theory]
    [InlineData("application/json")]
    [InlineData("application/json;")]
    [InlineData("application/json; charset=utf-8")]
    [InlineData("application/json;charset=utf-8")]
    [InlineData("application/json; charset=\"utf-8\"")]
    [InlineData("application/json; charset=utf-8; boundary=something")]
    [InlineData("Application/JSON")]
    [InlineData(" application/json ;charset=utf-8")]
    public async Task ValidRequest_ReturnsOk(string contentType)
    {
        var processor = new RecordingWebhookEventProcessor();
        var body = CreateBody(100);

        var context = await InvokeEndpointAsync(
            processor,
            request =>
            {
                request.ContentType = contentType;
                SetBody(request, body);
            },
            cancellationToken: TestContext.Current.CancellationToken).ConfigureAwait(true);

        context.Response.StatusCode.Should().Be(StatusCodes.Status200OK);
        processor.Bodies.Should().ContainSingle().Which.Should().Be(body);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("text/plain")]
    [InlineData("application/jsonp")]
    [InlineData("application/problem+json")]
    [InlineData("application/")]
    [InlineData("/json")]
    [InlineData("not a content type")]
    [InlineData("application/json;;")]
    [InlineData("application/json; charset")]
    [InlineData("application/json; charset=")]
    [InlineData("application/json; charset=\"unterminated")]
    [InlineData("application/json; charset=utf 8")]
    [InlineData("application/json; =utf-8")]
    public async Task InvalidContentType_ReturnsBadRequest(string? contentType)
    {
        var processor = new RecordingWebhookEventProcessor();

        var context = await InvokeEndpointAsync(
            processor,
            request =>
            {
                request.ContentType = contentType;
                SetBody(request, CreateBody(100));
            },
            cancellationToken: TestContext.Current.CancellationToken).ConfigureAwait(true);

        context.Response.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        processor.Bodies.Should().BeEmpty();
    }

    [Fact]
    public async Task ValidSignature_ReturnsOk()
    {
        const string secret = "my-webhook-secret";
        var processor = new RecordingWebhookEventProcessor();
        var body = CreateBody(100);

        var context = await InvokeEndpointAsync(
            processor,
            request =>
            {
                SetBody(request, body);
                request.Headers["X-Hub-Signature-256"] = ComputeSignature(secret, body);
            },
            secret: secret,
            cancellationToken: TestContext.Current.CancellationToken).ConfigureAwait(true);

        context.Response.StatusCode.Should().Be(StatusCodes.Status200OK);
        processor.Bodies.Should().ContainSingle().Which.Should().Be(body);
    }

    [Fact]
    public async Task InvalidSignature_ReturnsBadRequest()
    {
        var processor = new RecordingWebhookEventProcessor();
        var body = CreateBody(100);

        var context = await InvokeEndpointAsync(
            processor,
            request =>
            {
                SetBody(request, body);
                request.Headers["X-Hub-Signature-256"] = ComputeSignature("wrong-secret", body);
            },
            secret: "my-webhook-secret",
            cancellationToken: TestContext.Current.CancellationToken).ConfigureAwait(true);

        context.Response.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        processor.Bodies.Should().BeEmpty();
    }

    [Fact]
    public async Task SecretFromOptions_IsReadForEachRequest()
    {
        var processor = new RecordingWebhookEventProcessor();
        var body = CreateBody(100);
        var optionsMonitor = new TestOptionsMonitor(new GitHubWebhookOptions { Secret = "first-secret" });

        await using var endpoint = TestEndpoint.Create(
            processor,
            services => services.AddSingleton<IOptionsMonitor<GitHubWebhookOptions>>(optionsMonitor));

        var first = await endpoint.InvokeAsync(
            request => SignRequest(request, body, "first-secret"),
            TestContext.Current.CancellationToken).ConfigureAwait(true);

        first.Response.StatusCode.Should().Be(StatusCodes.Status200OK);

        optionsMonitor.CurrentValue = new GitHubWebhookOptions { Secret = "second-secret" };

        var stale = await endpoint.InvokeAsync(
            request => SignRequest(request, body, "first-secret"),
            TestContext.Current.CancellationToken).ConfigureAwait(true);

        stale.Response.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

        var second = await endpoint.InvokeAsync(
            request => SignRequest(request, body, "second-secret"),
            TestContext.Current.CancellationToken).ConfigureAwait(true);

        second.Response.StatusCode.Should().Be(StatusCodes.Status200OK);
        processor.Bodies.Should().HaveCount(2);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(100_000)]
    public async Task Body_WithoutContentLength_IsRead(int payloadLength)
    {
        var processor = new RecordingWebhookEventProcessor();
        var body = CreateBody(payloadLength);

        var context = await InvokeEndpointAsync(
            processor,
            request =>
            {
                SetBody(request, body);
                request.ContentLength = null;
            },
            cancellationToken: TestContext.Current.CancellationToken).ConfigureAwait(true);

        context.Response.StatusCode.Should().Be(StatusCodes.Status200OK);
        processor.Bodies.Should().ContainSingle().Which.Should().Be(body);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(65_535)]
    [InlineData(65_536)]
    [InlineData(65_537)]
    [InlineData(300_000)]
    public async Task Body_WithAccurateContentLength_IsRead(int payloadLength)
    {
        var processor = new RecordingWebhookEventProcessor();
        var body = CreateBody(payloadLength);

        var context = await InvokeEndpointAsync(
            processor,
            request => SetBody(request, body),
            cancellationToken: TestContext.Current.CancellationToken).ConfigureAwait(true);

        context.Response.StatusCode.Should().Be(StatusCodes.Status200OK);
        processor.Bodies.Should().ContainSingle().Which.Should().Be(body);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1_000_000)]
    [InlineData(int.MaxValue)]
    [InlineData(long.MaxValue)]
    public async Task Body_WithIncorrectContentLength_IsRead(long contentLength)
    {
        var processor = new RecordingWebhookEventProcessor();
        var body = CreateBody(50_000);

        var context = await InvokeEndpointAsync(
            processor,
            request =>
            {
                SetBody(request, body);
                request.ContentLength = contentLength;
            },
            cancellationToken: TestContext.Current.CancellationToken).ConfigureAwait(true);

        context.Response.StatusCode.Should().Be(StatusCodes.Status200OK);
        processor.Bodies.Should().ContainSingle().Which.Should().Be(body);
    }

    private static Task<DefaultHttpContext> InvokeEndpointAsync(
        Exception exception,
        Func<Exception, HttpContext, ValueTask<bool>>? exceptionHandler = null,
        CancellationToken cancellationToken = default)
        => InvokeEndpointAsync(
            new ThrowingWebhookEventProcessor(exception),
            request => SetBody(request, "{}"),
            exceptionHandler,
            cancellationToken: cancellationToken);

    private static async Task<DefaultHttpContext> InvokeEndpointAsync(
        WebhookEventProcessor processor,
        Action<HttpRequest> configureRequest,
        Func<Exception, HttpContext, ValueTask<bool>>? exceptionHandler = null,
        string? secret = null,
        CancellationToken cancellationToken = default)
    {
        Action<IServiceCollection>? configureServices = exceptionHandler is null
            ? null
            : services => services.Configure<GitHubWebhookOptions>(options => options.ExceptionHandler = exceptionHandler);

        await using var endpoint = TestEndpoint.Create(processor, configureServices, secret);

        return await endpoint.InvokeAsync(configureRequest, cancellationToken).ConfigureAwait(true);
    }

    private static void SignRequest(HttpRequest request, string body, string secret)
    {
        SetBody(request, body);
        request.Headers["X-Hub-Signature-256"] = ComputeSignature(secret, body);
    }

    private static void SetBody(HttpRequest request, string body)
    {
        var bytes = Encoding.UTF8.GetBytes(body);
        request.Body = new MemoryStream(bytes);
        request.ContentLength = bytes.Length;
    }

    private static string CreateBody(int length)
    {
        const string prefix = "{\"action\":\"";
        const string suffix = "\"}";
        return prefix + new string('a', Math.Max(0, length - prefix.Length - suffix.Length)) + suffix;
    }

    private static string ComputeSignature(string secret, string body)
    {
        var hash = HMACSHA256.HashData(Encoding.UTF8.GetBytes(secret), Encoding.UTF8.GetBytes(body));
        return $"sha256={Convert.ToHexString(hash).ToLowerInvariant()}";
    }

    private sealed class RecordingWebhookEventProcessor : WebhookEventProcessor
    {
        public List<string> Bodies { get; } = [];

        public override ValueTask ProcessWebhookAsync(
            IDictionary<string, StringValues> headers,
            string body,
            CancellationToken cancellationToken = default)
        {
            this.Bodies.Add(body);
            return ValueTask.CompletedTask;
        }
    }

    private sealed class ThrowingWebhookEventProcessor(Exception exception) : WebhookEventProcessor
    {
        public override ValueTask ProcessWebhookAsync(
            IDictionary<string, StringValues> headers,
            string body,
            CancellationToken cancellationToken = default) =>
            ValueTask.FromException(exception);
    }

    private sealed class TestOptionsMonitor(GitHubWebhookOptions options) : IOptionsMonitor<GitHubWebhookOptions>
    {
        public GitHubWebhookOptions CurrentValue { get; set; } = options;

        public GitHubWebhookOptions Get(string? name) => this.CurrentValue;

        public IDisposable? OnChange(Action<GitHubWebhookOptions, string?> listener) => null;
    }

    private sealed class TestEndpoint(ServiceProvider serviceProvider, RequestDelegate requestDelegate) : IAsyncDisposable
    {
        public static TestEndpoint Create(
            WebhookEventProcessor processor,
            Action<IServiceCollection>? configureServices = null,
            string? secret = null)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddRouting();
            services.AddSingleton(processor);
            configureServices?.Invoke(services);

            var serviceProvider = services.BuildServiceProvider();
            var routeBuilder = new TestEndpointRouteBuilder(serviceProvider);
            routeBuilder.MapGitHubWebhooks(secret: secret);

            var endpoint = routeBuilder.DataSources
                .SelectMany(dataSource => dataSource.Endpoints)
                .OfType<RouteEndpoint>()
                .Single();

            return new(serviceProvider, endpoint.RequestDelegate!);
        }

        public async Task<DefaultHttpContext> InvokeAsync(Action<HttpRequest> configureRequest, CancellationToken cancellationToken = default)
        {
            var context = new DefaultHttpContext
            {
                RequestServices = serviceProvider,
            };
            context.Request.ContentType = "application/json";
            context.Request.Headers["X-GitHub-Event"] = "issues";
            context.RequestAborted = cancellationToken;
            configureRequest(context.Request);

            await requestDelegate(context).ConfigureAwait(true);
            return context;
        }

        public ValueTask DisposeAsync() => serviceProvider.DisposeAsync();
    }

    private sealed class TestEndpointRouteBuilder(IServiceProvider serviceProvider) : IEndpointRouteBuilder
    {
        public ICollection<EndpointDataSource> DataSources { get; } = [];

        public IServiceProvider ServiceProvider { get; } = serviceProvider;

        public IApplicationBuilder CreateApplicationBuilder() => new ApplicationBuilder(this.ServiceProvider);
    }
}
