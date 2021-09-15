namespace JamieMagee.Octokit.Webhooks.Events.SecretScanningAlert
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(SecretScanningAlertActionValue.Created)]
    public sealed record SecretScanningAlertCreatedEvent : SecretScanningAlertEvent
    {
        [JsonPropertyName("action")]
        public override string Action => SecretScanningAlertAction.Created;
    }
}
