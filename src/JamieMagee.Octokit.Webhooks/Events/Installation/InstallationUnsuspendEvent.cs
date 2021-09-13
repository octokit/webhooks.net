namespace JamieMagee.Octokit.Webhooks.Events.Installation
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(InstallationActionValue.Unsuspend)]
    public sealed record InstallationUnsuspendEvent : InstallationEvent
    {
        [JsonPropertyName("action")]
        public override string Action => InstallationAction.Unsuspend;
    }
}
