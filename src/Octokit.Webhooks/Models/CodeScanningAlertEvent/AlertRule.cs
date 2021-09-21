namespace Octokit.Webhooks.Models.CodeScanningAlertEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record AlertRule
    {
        [JsonPropertyName("id")]
        public string Id { get; init; } = null!;

        [JsonPropertyName("severity")]
        public AlertRuleSeverity? Severity { get; init; }

        [JsonPropertyName("description")]
        public string Description { get; init; } = null!;

        [JsonPropertyName("full_description")]
        public string FullDescription { get; init; } = null!;

        [JsonPropertyName("tags")]
        public string Tags { get; init; } = null!;

        [JsonPropertyName("help")]
        public string Help { get; init; } = null!;
    }
}
