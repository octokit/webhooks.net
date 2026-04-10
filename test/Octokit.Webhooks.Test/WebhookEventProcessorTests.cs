namespace Octokit.Webhooks.Test;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using AwesomeAssertions;
using Microsoft.Extensions.Primitives;
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
}
