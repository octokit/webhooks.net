namespace JamieMagee.Octokit.Webhooks.Events.CodeScanningAlert
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(CodeScanningAlertActionValue.Created)]
    public sealed record CodeScanningAlertCreatedEvent : CodeScanningAlertEvent
    {
        [JsonPropertyName("action")]
        public override string Action => CodeScanningAlertAction.Created;
    }
}
