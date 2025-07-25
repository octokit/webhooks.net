namespace Octokit.Webhooks.Test;

using System;
using AwesomeAssertions;
using Xunit;

public class WebhookEventProcessorTests
{
    private readonly TestWebhookEventProcessor webhookEventProcessor = new();

    [Theory]
    [ClassData(typeof(WebhookEventProcessorTestsData))]
    public void CanDeserialize(string @event, string payload, Type expectedType)
    {
        var headers = new WebhookHeaders
        {
            Event = @event,
        };
        var result = this.webhookEventProcessor.DeserializeWebhookEvent(headers, payload);
        result.Should().BeAssignableTo(expectedType);
    }
}
