namespace Octokit.Webhooks.Test;

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AwesomeAssertions;
using Microsoft.Extensions.Primitives;
using Octokit.Webhooks.TestUtils;
using Xunit;

public class WebhookEventProcessorTests
{
    private readonly TestWebhookEventProcessor webhookEventProcessor = new();

    [Theory]
    [ClassData(typeof(WebhookEventProcessorTestsData))]
    public void CanDeserialize(string @event, string testName, string payload, Type expectedType)
    {
        // Only used to make it easier to differentiate test cases for the same event without looking at whole payload
        _ = testName;
        var headers = new WebhookHeaders
        {
            Event = @event,
        };
        var result = this.webhookEventProcessor.DeserializeWebhookEvent(headers, payload);
        result.Should().BeAssignableTo(expectedType);
    }

    [Fact]
    public async Task ProcessWebhookAsync_EmptyEventHeader_ThrowsArgumentException()
    {
        var headers = new Dictionary<string, StringValues>(StringComparer.OrdinalIgnoreCase)
        {
            ["X-GitHub-Event"] = string.Empty,
        };

        var act = () => this.webhookEventProcessor.ProcessWebhookAsync(headers, "{}").AsTask();

        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage("X-GitHub-Event header is missing or empty.*")
            .ConfigureAwait(true);
    }

    [Fact]
    public async Task ProcessWebhookAsync_WhitespaceEventHeader_ThrowsArgumentException()
    {
        var headers = new Dictionary<string, StringValues>(StringComparer.OrdinalIgnoreCase)
        {
            ["X-GitHub-Event"] = "   ",
        };

        var act = () => this.webhookEventProcessor.ProcessWebhookAsync(headers, "{}").AsTask();

        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage("X-GitHub-Event header is missing or empty.*")
            .ConfigureAwait(true);
    }

    [Fact]
    public async Task ProcessWebhookAsync_MissingEventHeader_ThrowsArgumentException()
    {
        var headers = new Dictionary<string, StringValues>(StringComparer.OrdinalIgnoreCase);

        var act = () => this.webhookEventProcessor.ProcessWebhookAsync(headers, "{}").AsTask();

        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage("X-GitHub-Event header is missing or empty.*")
            .ConfigureAwait(true);
    }

    [Fact]
    public void DeserializeWebhookEvent_UnknownEventType_ThrowsJsonExceptionWithEventName()
    {
        var headers = new WebhookHeaders
        {
            Event = "unknown_event_type",
        };

        var act = () => this.webhookEventProcessor.DeserializeWebhookEvent(headers, "{}");

        act.Should().Throw<JsonException>()
            .WithMessage("*'unknown_event_type'*");
    }

    [Fact]
    public async Task ProcessWebhookBytesAsync_DeserializesKnownEvent()
    {
        var payload = ResourceUtils.ReadResource("issues/opened.payload.json");
        var bodyBytes = Encoding.UTF8.GetBytes(payload);
        var headers = new Dictionary<string, StringValues>(StringComparer.OrdinalIgnoreCase)
        {
            ["X-GitHub-Event"] = "issues",
            ["X-GitHub-Delivery"] = Guid.NewGuid().ToString(),
        };

        await this.webhookEventProcessor.ProcessWebhookAsync(headers, (ReadOnlyMemory<byte>)bodyBytes, TestContext.Current.CancellationToken)
            .ConfigureAwait(true);
    }

    [Fact]
    public async Task ProcessWebhookBytesAsync_FallsBackToStringPath_WhenOverrideExists()
    {
        var overridingProcessor = new OverridingWebhookEventProcessor();
        var payload = ResourceUtils.ReadResource("issues/opened.payload.json");
        var bodyBytes = Encoding.UTF8.GetBytes(payload);
        var headers = new Dictionary<string, StringValues>(StringComparer.OrdinalIgnoreCase)
        {
            ["X-GitHub-Event"] = "issues",
            ["X-GitHub-Delivery"] = Guid.NewGuid().ToString(),
        };

        await overridingProcessor.ProcessWebhookAsync(headers, (ReadOnlyMemory<byte>)bodyBytes, TestContext.Current.CancellationToken)
            .ConfigureAwait(true);

        overridingProcessor.StringDeserializeCalled.Should().BeTrue();
    }

    [Fact]
    public async Task ProcessWebhookBytesAsync_EmptyEventHeader_ThrowsArgumentException()
    {
        var headers = new Dictionary<string, StringValues>(StringComparer.OrdinalIgnoreCase)
        {
            ["X-GitHub-Event"] = string.Empty,
        };

        var act = () => this.webhookEventProcessor.ProcessWebhookAsync(
            headers, (ReadOnlyMemory<byte>)Encoding.UTF8.GetBytes("{}")).AsTask();

        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage("X-GitHub-Event header is missing or empty.*")
            .ConfigureAwait(true);
    }

    private sealed class OverridingWebhookEventProcessor : WebhookEventProcessor
    {
        public bool StringDeserializeCalled { get; private set; }

        public override WebhookEvent DeserializeWebhookEvent(WebhookHeaders headers, string body)
        {
            this.StringDeserializeCalled = true;
            return base.DeserializeWebhookEvent(headers, body);
        }
    }
}
