namespace Octokit.Webhooks.Models.DeployKeyEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record DeployKey
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("key")]
        public string Key { get; init; }

        [JsonPropertyName("url")]
        public string Url { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("verified")]
        public bool Verified { get; init; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; }

        [JsonPropertyName("read_only")]
        public bool ReadOnly { get; init; }
    }
}
