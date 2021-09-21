namespace Octokit.Webhooks.Events.Discussion
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(DiscussionActionValue.Unlabeled)]
    public sealed record DiscussionUnlabeledEvent : DiscussionEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DiscussionAction.Unlabeled;

        [JsonPropertyName("label")]
        public Label Label { get; init; } = null!;
    }
}
