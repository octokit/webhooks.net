namespace JamieMagee.Octokit.Webhooks.Events.Installation
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(InstallationActionValue.NewPermissionsAccepted)]
    public sealed record InstallationNewPermissionsAcceptedEvent : InstallationEvent
    {
        [JsonPropertyName("action")]
        public override string Action => InstallationAction.NewPermissionsAccepted;
    }
}
