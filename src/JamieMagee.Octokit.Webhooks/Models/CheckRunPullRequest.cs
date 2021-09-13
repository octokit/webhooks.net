namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models.CheckRunEvent;

    public sealed record CheckRunPullRequest
    {
        [JsonPropertyName("url")]
        public string Url { get; set; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("head")]
        public CheckRunPullRequestHead Head { get; set; } = null!;

        [JsonPropertyName("base")]
        public CheckRunPullRequestBase Base { get; set; } = null!;
    }
}
