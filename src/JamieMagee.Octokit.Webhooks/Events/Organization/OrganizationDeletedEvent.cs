namespace JamieMagee.Octokit.Webhooks.Events.Organization
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(OrganizationActionValue.Deleted)]
    public sealed record OrganizationDeletedEvent : OrganizationEvent
    {
        [JsonPropertyName("action")]
        public override string Action => OrganizationAction.Deleted;

        [JsonPropertyName("membership")]
        public Membership Membership { get; init; } = null!;
    }
}
