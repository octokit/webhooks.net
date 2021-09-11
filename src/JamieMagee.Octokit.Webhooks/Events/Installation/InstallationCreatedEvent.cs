namespace JamieMagee.Octokit.Webhooks.Events.Installation
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record InstallationCreatedEvent : InstallationEvent
    {
        [JsonPropertyName("action")]
        public override string Action => InstallationAction.Created;
    }
}
