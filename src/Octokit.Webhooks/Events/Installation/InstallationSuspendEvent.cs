namespace Octokit.Webhooks.Events.Installation
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(InstallationActionValue.Suspend)]
    public sealed record InstallationSuspendEvent : InstallationEvent
    {
        [JsonPropertyName("action")]
        public override string Action => InstallationAction.Suspend;
    }
}
