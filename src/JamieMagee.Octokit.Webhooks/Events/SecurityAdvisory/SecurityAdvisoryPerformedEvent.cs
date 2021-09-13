namespace JamieMagee.Octokit.Webhooks.Events.SecurityAdvisory
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(SecurityAdvisoryActionValue.Performed)]
    public sealed record SecurityAdvisoryPerformedEvent : SecurityAdvisoryEvent
    {
        [JsonPropertyName("action")]
        public override string Action => SecurityAdvisoryAction.Performed;
    }
}
