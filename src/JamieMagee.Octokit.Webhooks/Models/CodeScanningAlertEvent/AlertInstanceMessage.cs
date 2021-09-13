namespace JamieMagee.Octokit.Webhooks.Models.CodeScanningAlertEvent
{
    using System.Text.Json.Serialization;

    public class AlertInstanceMessage
    {
        [JsonPropertyName("text")]
        public string? Text { get; init; }
    }
}
