namespace Octokit.Webhooks.Test;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FluentAssertions;
using Octokit.Webhooks.Converter;
using Octokit.Webhooks.Events;
using Octokit.Webhooks.Models;
using Octokit.Webhooks.TestUtils;
using Xunit;

public class CanImplementEventsInClientCode
{
    private readonly TestWebhookEventProcessor testWebhookEventProcessor = new();

    [Fact]
    public void CanImplementCustomEvents()
    {
        var body = ResourceUtils.ReadExtensibilityResource("deployment_review\\payload.json");
        var header = new WebhookHeaders
        {
            Event = "deployment_review",
        };
        var result = this.testWebhookEventProcessor.DeserializeWebhookEvent(header, body);
        result.Should().BeOfType<DeploymentReviewRequestedEvent>();
    }

    public class TestWebhookEventProcessor : WebhookEventProcessor
    {
        public override WebhookEvent DeserializeWebhookEvent(WebhookHeaders headers, string body)
        {
            if (headers.Event == WebhookEventType.DeploymentReview)
            {
                return JsonSerializer.Deserialize<DeployReviewEvent>(body)!;
            }

            return base.DeserializeWebhookEvent(headers, body);
        }
    }

    [WebhookEventType(WebhookEventType.DeploymentReview)]
    [JsonConverter(typeof(WebhookConverter<DeployReviewEvent>))]
    public abstract record DeployReviewEvent : WebhookEvent
    {
        [JsonPropertyName("environment")]
        public string Environment { get; init; } = null!;

        [JsonPropertyName("workflow_run")]
        public WorkflowRun? WorkflowRun { get; init; } = null!;

        [JsonPropertyName("since")]
        public DateTimeOffset Since { get; init; } = default!;
    }

    [WebhookActionType(DeploymentReviewActionValue.Requested)]
    public sealed record DeploymentReviewRequestedEvent : DeployReviewEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DeploymentReviewAction.Requested;
    }

    [WebhookActionType(DeploymentReviewActionValue.Approved)]
    public sealed record DeploymentReviewApprovedEvent : DeployReviewEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DeploymentReviewAction.Approved;
    }

    [WebhookActionType(DeploymentReviewActionValue.Rejected)]
    public sealed record DeploymentReviewRejectedEvent : DeployReviewEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DeploymentReviewAction.Rejected;
    }

    public sealed record DeploymentReviewAction : WebhookEventAction
    {
        public static readonly DeploymentReviewAction Requested = new(DeploymentReviewActionValue.Requested);

        public static readonly DeploymentReviewAction Approved = new(DeploymentReviewActionValue.Approved);

        public static readonly DeploymentReviewAction Rejected = new(DeploymentReviewActionValue.Rejected);

        private DeploymentReviewAction(string value)
            : base(value)
        {
        }
    }

    public static class DeploymentReviewActionValue
    {
        public const string Requested = "requested";

        public const string Approved = "approved";
        public const string Rejected = "rejected";
    }
}
