namespace JamieMagee.Octokit.Webhooks.Models.PingEvent
{
    using System.Text.Json.Serialization;

    public class HookLastResponse
    {
        [JsonPropertyName("code")]
        public string? Code { get; init; }

        [JsonPropertyName("status")]
        public string Status { get; init; } = null!;

        [JsonPropertyName("message")]
        public string? Message { get; init; }
    }
}
