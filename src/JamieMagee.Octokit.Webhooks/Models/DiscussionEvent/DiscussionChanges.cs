namespace JamieMagee.Octokit.Webhooks.Models.DiscussionEvent
{
    using System.Text.Json.Serialization;

    public sealed record DiscussionChanges
    {
        [JsonPropertyName("category")]
        public DiscussionChangesCategory? Category { get; init; }

        [JsonPropertyName("title")]
        public DiscussionChangesTitle? Title { get; init; }

        [JsonPropertyName("body")]
        public DiscussionChangesBody? Body { get; init; }

        [JsonPropertyName("new_discussion")]
        public Discussion? NewDiscussion { get; init; }

        [JsonPropertyName("new_repository")]
        public Repository? NewRepository { get; init; }
    }
}
