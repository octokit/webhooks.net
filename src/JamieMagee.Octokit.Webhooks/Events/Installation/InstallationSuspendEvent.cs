namespace JamieMagee.Octokit.Webhooks.Events.Installation
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(InstallationActionValue.Suspend)]
    public sealed record InstallationSuspendEvent : InstallationEvent
    {
        [JsonPropertyName("action")]
        public override string Action => InstallationAction.Suspend;
    }
}
