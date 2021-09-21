namespace Octokit.Webhooks.Models.PullRequestReviewEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record ReviewLinks
    {
        [JsonPropertyName("html")]
        public Link Html { get; init; } = null!;

        [JsonPropertyName("pull_request")]
        public Link PullRequest { get; init; } = null!;
    }
}
