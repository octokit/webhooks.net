namespace JamieMagee.Octokit.Webhooks.Events.CodeScanningAlert
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record CodeScanningAlertReopenedByUserEvent : CodeScanningAlertEvent
    {
        [JsonPropertyName("action")]
        public override string Action => CodeScanningAlertAction.ReopenedByUser;
    }
}
