namespace JamieMagee.Octokit.Webhooks.Events.CodeScanningAlert
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(CodeScanningAlertActionValue.ClosedByUser)]
    public sealed record CodeScanningAlertClosedByUserEvent : CodeScanningAlertEvent
    {
        [JsonPropertyName("action")]
        public override string Action => CodeScanningAlertAction.ClosedByUser;
    }
}
