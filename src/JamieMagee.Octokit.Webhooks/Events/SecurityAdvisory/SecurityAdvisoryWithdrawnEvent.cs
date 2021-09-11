namespace JamieMagee.Octokit.Webhooks.Events.SecurityAdvisory
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record SecurityAdvisoryWithdrawnEvent : SecurityAdvisoryEvent
    {
        [JsonPropertyName("action")]
        public override string Action => SecurityAdvisoryAction.Withdrawn;
    }
}
