namespace JamieMagee.Octokit.Webhooks.Events.SecretScanningAlert
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record SecretScanningAlertCreatedEvent : SecretScanningAlertEvent
    {
        [JsonPropertyName("action")]
        public override string Action => SecretScanningAlertAction.Created;
    }
}
