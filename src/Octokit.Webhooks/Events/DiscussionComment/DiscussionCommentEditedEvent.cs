namespace Octokit.Webhooks.Events.DiscussionComment
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models.DiscussionCommentEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(DiscussionCommentActionValue.Edited)]
    public sealed record DiscussionCommentEditedEvent : DiscussionCommentEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DiscussionCommentAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; }
    }
}
