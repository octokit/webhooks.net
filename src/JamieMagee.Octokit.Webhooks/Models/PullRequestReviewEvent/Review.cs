namespace JamieMagee.Octokit.Webhooks.Models.PullRequestReviewEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Review
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("user")]
        public User User { get; init; } = null!;

        [JsonPropertyName("body")]
        public string? Body { get; init; }

        [JsonPropertyName("commit_id")]
        public string CommitId { get; init; } = null!;

        [JsonPropertyName("submitted_at")]
        public string SubmittedAt { get; init; } = null!;

        // TODO: this should probably be an enum
        [JsonPropertyName("state")]
        public string State { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; } = null!;

        [JsonPropertyName("pull_request_url")]
        public string PullRequestUrl { get; init; } = null!;

        [JsonPropertyName("author_association")]
        public AuthorAssociation AuthorAssociation { get; init; }
    }
}
