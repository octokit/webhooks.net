namespace Octokit.Webhooks.Events.Organization
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(OrganizationActionValue.Renamed)]
    public sealed record OrganizationRenamedEvent : OrganizationEvent
    {
        [JsonPropertyName("action")]
        public override string Action => OrganizationAction.Renamed;

        [JsonPropertyName("membership")]
        public Membership Membership { get; init; } = null!;
    }
}
