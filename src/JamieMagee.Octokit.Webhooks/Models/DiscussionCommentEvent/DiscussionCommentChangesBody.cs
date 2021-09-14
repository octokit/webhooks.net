namespace JamieMagee.Octokit.Webhooks.Models.DiscussionCommentEvent
{
    using System.Text.Json.Serialization;

    public sealed record DiscussionCommentChangesBody
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    }
}
