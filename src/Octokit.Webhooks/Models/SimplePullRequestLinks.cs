namespace Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record SimplePullRequestLinks
    {
        [JsonPropertyName("self")]
        public Link self { get; init; } = null!;

        [JsonPropertyName("html")]
        public Link html { get; init; } = null!;

        [JsonPropertyName("issue")]
        public Link issue { get; init; } = null!;

        [JsonPropertyName("comments")]
        public Link comments { get; init; } = null!;

        [JsonPropertyName("review_comments")]
        public Link review_comments { get; init; } = null!;

        [JsonPropertyName("review_comment")]
        public Link review_comment { get; init; } = null!;

        [JsonPropertyName("commits")]
        public Link commits { get; init; } = null!;

        [JsonPropertyName("statuses")]
        public Link statuses { get; init; } = null!;
    }
}
