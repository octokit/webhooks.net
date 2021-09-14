namespace JamieMagee.Octokit.Webhooks.Models.SecurityAdvisoryEvent
{
    using System.Text.Json.Serialization;

    public sealed record SecurityAdvisoryCvss
    {
        [JsonPropertyName("vector_string")]
        public string? VectorString { get; init; }

        [JsonPropertyName("score")]
        public int Score { get; init; }
    }
}
