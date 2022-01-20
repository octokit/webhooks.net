namespace Octokit.Webhooks.Models.DeployKeyEvent
{
    using System;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    [PublicAPI]
    public sealed record DeployKey
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("key")]
        public string Key { get; init; } = null!;

        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("title")]
        public string Title { get; init; } = null!;

        [JsonPropertyName("verified")]
        public bool Verified { get; init; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset CreatedAt { get; init; }

        [JsonPropertyName("read_only")]
        public bool ReadOnly { get; init; }
    }
}
