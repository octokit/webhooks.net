namespace JamieMagee.Octokit.Webhooks.Models.DiscussionCommentEvent
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models.DiscussionEvent;

    public sealed record DiscussionCommentChanges
    {
        [JsonPropertyName("body")]
        public DiscussionCommentChanges? Body { get; init; }
    }
}
