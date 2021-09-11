namespace JamieMagee.Octokit.Webhooks.Events.Organization
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record OrganizationRenamedEvent : OrganizationEvent
    {
        [JsonPropertyName("action")]
        public override string Action => OrganizationAction.Renamed;
    }
}
