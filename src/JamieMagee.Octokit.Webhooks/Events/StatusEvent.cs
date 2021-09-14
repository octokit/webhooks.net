namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models.StatusEvent;

    [WebhookEventType(WebhookEventType.Status)]
    public sealed record StatusEvent : WebhookEvent
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("sha")]
        public string Sha { get; init; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("avatar_url")]
        public string? AvatarUrl { get; init; }

        [JsonPropertyName("target_url")]
        public string? TargetUrl { get; init; }

        [JsonPropertyName("context")]
        public string Context { get; init; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; init; }

        [JsonPropertyName("state")]
        public StatusState State { get; init; }

        [JsonPropertyName("commit")]
        public Commit Commit { get; init; }

        [JsonPropertyName("branch")]
        public IEnumerable<Branch> Branch { get; init; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;
    }
}
