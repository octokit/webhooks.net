namespace JamieMagee.Octokit.Webhooks.Models.SecurityAdvisoryEvent
{
    using System.Text.Json.Serialization;

    public sealed record SecurityAdvisoryReference
    {
        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;
    }
}
