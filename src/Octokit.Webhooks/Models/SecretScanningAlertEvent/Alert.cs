namespace Octokit.Webhooks.Models.SecretScanningAlertEvent
{
    using System;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    [PublicAPI]
    public sealed record Alert
    {
        [JsonPropertyName("number")]
        public int Number { get; init; }

        [JsonPropertyName("secret_type")]
        public string SecretType { get; init; } = null!;

        [JsonPropertyName("resolution")]
        public AlertResolution? Resolution { get; init; }

        [JsonPropertyName("resolved_by")]
        public User? ResolvedBy { get; init; }

        [JsonPropertyName("resolved_at")]
        [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
        public DateTimeOffset? ResolvedAt { get; init; }
    }
}
