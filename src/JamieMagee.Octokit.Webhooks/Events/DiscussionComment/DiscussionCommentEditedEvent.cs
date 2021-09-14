namespace JamieMagee.Octokit.Webhooks.Events.DiscussionComment
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.DiscussionCommentEvent;

    [WebhookActionType(DiscussionCommentActionValue.Edited)]
    public sealed record DiscussionCommentEditedEvent : DiscussionCommentEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DiscussionCommentAction.Edited;

        [JsonPropertyName("changes")]
        public DiscussionCommentChanges Changes { get; init; }
    }
}
