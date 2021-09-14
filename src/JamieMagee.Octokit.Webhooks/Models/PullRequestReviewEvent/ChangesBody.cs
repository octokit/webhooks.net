namespace JamieMagee.Octokit.Webhooks.Models.PullRequestReviewEvent
{
    using System.Text.Json.Serialization;

    public sealed record ChangesBody
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    };
}
