namespace Octokit.Webhooks.Events.Discussion
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Models;

    [PublicAPI]
    [WebhookActionType(DiscussionActionValue.Labeled)]
    public sealed record DiscussionLabeledEvent : DiscussionEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DiscussionAction.Labeled;

        [JsonPropertyName("label")]
        public Label Label { get; init; } = null!;
    }
}
