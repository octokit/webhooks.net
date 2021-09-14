namespace JamieMagee.Octokit.Webhooks.Models.CodeScanningAlertEvent
{
    using System.Text.Json.Serialization;

    public sealed record AlertInstanceMessage
    {
        [JsonPropertyName("text")]
        public string? Text { get; init; }
    }
}
