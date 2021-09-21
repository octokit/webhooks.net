namespace Octokit.Webhooks.Events.Discussion
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models.DiscussionEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(DiscussionActionValue.Transferred)]
    public sealed record DiscussionTransferredEvent : DiscussionEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DiscussionAction.Transferred;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
