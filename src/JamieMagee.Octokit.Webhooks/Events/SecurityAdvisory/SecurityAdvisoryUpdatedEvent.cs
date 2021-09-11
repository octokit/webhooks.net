namespace JamieMagee.Octokit.Webhooks.Events.SecurityAdvisory
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record SecurityAdvisoryUpdatedEvent : SecurityAdvisoryEvent
    {
        [JsonPropertyName("action")]
        public override string Action => SecurityAdvisoryAction.Updated;
    }
}
