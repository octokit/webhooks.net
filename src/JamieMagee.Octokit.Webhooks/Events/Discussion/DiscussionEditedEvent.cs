namespace JamieMagee.Octokit.Webhooks.Events.Discussion
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.DiscussionEvent;

    [WebhookActionType(DiscussionActionValue.Edited)]
    public sealed record DiscussionEditedEvent : DiscussionEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DiscussionAction.Edited;

        [JsonPropertyName("changes")]
        public DiscussionChanges Changes { get; init; } = null!;
    }
}
