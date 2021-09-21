namespace Octokit.Webhooks.Models.CommitCommentEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Comment
    {
        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("user")]
        public User User { get; init; } = null!;

        [JsonPropertyName("position")]
        public int? Position { get; init; }

        [JsonPropertyName("line")]
        public int? Line { get; init; }

        [JsonPropertyName("path")]
        public string? Path { get; init; }

        [JsonPropertyName("commit_id")]
        public string CommitId { get; init; } = null!;

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;

        [JsonPropertyName("author_association")]
        public AuthorAssociation AuthorAssociation { get; init; }

        [JsonPropertyName("body")]
        public string Body { get; init; }
    }
}
