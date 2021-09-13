namespace JamieMagee.Octokit.Webhooks.Events.SecurityAdvisory
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(SecurityAdvisoryActionValue.Published)]
    public sealed record SecurityAdvisoryPublishedEvent : SecurityAdvisoryEvent
    {
        [JsonPropertyName("action")]
        public override string Action => SecurityAdvisoryAction.Published;
    }
}
