namespace JamieMagee.Octokit.Webhooks.Events.Organization
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(OrganizationActionValue.MemberRemoved)]
    public sealed record OrganizationMemberRemovedEvent : OrganizationEvent
    {
        [JsonPropertyName("action")]
        public override string Action => OrganizationAction.MemberRemoved;

        [JsonPropertyName("membership")]
        public Membership Membership { get; init; } = null!;
    }
}
