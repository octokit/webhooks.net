namespace JamieMagee.Octokit.Webhooks.Models.SecurityAdvisoryEvent
{
    using System.Text.Json.Serialization;

    public sealed record SecurityAdvisoryCwe
    {
        [JsonPropertyName("cwe_id")]
        public string CweId { get; init; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;
    }
}
