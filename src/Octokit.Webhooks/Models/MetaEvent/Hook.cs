namespace Octokit.Webhooks.Models.MetaEvent
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
        public long Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("active")]
        public bool Active { get; init; }

        [JsonPropertyName("events")]
        public IEnumerable<AppEvent> Events { get; init; } = null!;

        [JsonPropertyName("config")]
        public HookConfig Config { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;
    }
}
