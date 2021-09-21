namespace Octokit.Webhooks.Events.Organization
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(OrganizationActionValue.MemberAdded)]
    public sealed record OrganizationMemberAddedEvent : OrganizationEvent
    {
        [JsonPropertyName("action")]
        public override string Action => OrganizationAction.MemberAdded;

        [JsonPropertyName("membership")]
        public Membership Membership { get; init; } = null!;
    }
}
