namespace Octokit.Webhooks.Test;

using System;
using AwesomeAssertions;
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
}
