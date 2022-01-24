namespace Octokit.Webhooks.Models.SecretScanningAlertEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Alert
    {
        [JsonPropertyName("number")]
        public long Number { get; init; }

        [JsonPropertyName("secret_type")]
        public string SecretType { get; init; } = null!;

        [JsonPropertyName("resolution")]
        public AlertResolution? Resolution { get; init; }

        [JsonPropertyName("resolved_by")]
        public User? ResolvedBy { get; init; }

        [JsonPropertyName("resolved_at")]
        public string? ResolvedAt { get; init; }
    }
}
