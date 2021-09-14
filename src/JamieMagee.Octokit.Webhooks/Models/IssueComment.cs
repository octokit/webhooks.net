namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public sealed record IssueComment
    {
        [JsonPropertyName("url")]
        public string url { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string html_url { get; init; } = null!;

        [JsonPropertyName("issue_url")]
        public string issue_url { get; init; } = null!;

        [JsonPropertyName("id")]
        public int id { get; init; }

        [JsonPropertyName("node_id")]
        public string node_id { get; init; } = null!;

        [JsonPropertyName("user")]
        public User user { get; init; } = null!;

        [JsonPropertyName("created_at")]
        public string created_at { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string updated_at { get; init; } = null!;

        [JsonPropertyName("author_association")]
        public AuthorAssociation author_association { get; init; }

        [JsonPropertyName("body")]
        public string body { get; init; } = null!;

        [JsonPropertyName("performed_via_github_app")]
        public App? performed_via_github_app { get; init; }
    }
}
