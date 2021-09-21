namespace Octokit.Webhooks.Events.SecurityAdvisory
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(SecurityAdvisoryActionValue.Withdrawn)]
    public sealed record SecurityAdvisoryWithdrawnEvent : SecurityAdvisoryEvent
    {
        [JsonPropertyName("action")]
        public override string Action => SecurityAdvisoryAction.Withdrawn;
    }
}
