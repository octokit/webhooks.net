namespace Octokit.Webhooks.Models.PingEvent
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Hook
    {
        [JsonPropertyName("type")]
        public string Type { get; init; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("active")]
        public bool Active { get; init; }

        [JsonPropertyName("app_id")]
        public int? AppId { get; init; } = null!;

        [JsonPropertyName("events")]
        public IEnumerable<AppEvent> Events { get; init; } = null!;

        [JsonPropertyName("config")]
        public HookConfig Config { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("test_url")]
        public string? TestUrl { get; init; } = null!;

        [JsonPropertyName("ping_url")]
        public string PingUrl { get; init; } = null!;

        [JsonPropertyName("last_response")]
        public HookLastResponse LastResponse { get; init; } = null!;
    }
}
