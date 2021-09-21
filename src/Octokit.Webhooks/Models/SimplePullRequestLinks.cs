namespace Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record SimplePullRequestLinks
    {
        [JsonPropertyName("self")]
        public Link Self { get; init; } = null!;

        [JsonPropertyName("html")]
        public Link Html { get; init; } = null!;

        [JsonPropertyName("issue")]
        public Link Issue { get; init; } = null!;

        [JsonPropertyName("comments")]
        public Link Comments { get; init; } = null!;

        [JsonPropertyName("review_comments")]
        public Link ReviewComments { get; init; } = null!;

        [JsonPropertyName("review_comment")]
        public Link ReviewComment { get; init; } = null!;

        [JsonPropertyName("commits")]
        public Link Commits { get; init; } = null!;

        [JsonPropertyName("statuses")]
        public Link Statuses { get; init; } = null!;
    }
}
