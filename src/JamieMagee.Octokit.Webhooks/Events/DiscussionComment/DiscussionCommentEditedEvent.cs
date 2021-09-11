namespace JamieMagee.Octokit.Webhooks.Events.DiscussionComment
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record DiscussionCommentEditedEvent : DiscussionCommentEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DiscussionCommentAction.Edited;
    }
}
