namespace JamieMagee.Octokit.Webhooks.Events.Discussion
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.DiscussionEvent;

    [WebhookActionType(DiscussionActionValue.Transferred)]
    public sealed record DiscussionTransferredEvent : DiscussionEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DiscussionAction.Transferred;

        [JsonPropertyName("changes")]
        public DiscussionChanges Changes { get; init; } = null!;
    }
}
