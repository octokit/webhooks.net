namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models.CheckRunEvent;

    public sealed record CheckRunPullRequest
    {
        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("number")]
        public int Number { get; init; }

        [JsonPropertyName("head")]
        public CheckRunPullRequestHead Head { get; init; } = null!;

        [JsonPropertyName("base")]
        public CheckRunPullRequestBase Base { get; init; } = null!;
    }
}
