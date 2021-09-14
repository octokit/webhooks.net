namespace JamieMagee.Octokit.Webhooks.Models.PageBuildEvent
{
    using System.Text.Json.Serialization;

    public sealed record Build
    {
        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("status")]
        public string Status { get; init; } = null!;

        [JsonPropertyName("error")]
        public BuildError Error { get; init; } = null!;

        [JsonPropertyName("pusher")]
        public User Pusher { get; init; } = null!;

        [JsonPropertyName("commit")]
        public string Commit { get; init; } = null!;

        [JsonPropertyName("duration")]
        public int Duration { get; init; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;
    }
}
