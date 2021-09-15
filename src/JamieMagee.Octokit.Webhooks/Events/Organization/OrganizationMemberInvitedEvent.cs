namespace JamieMagee.Octokit.Webhooks.Events.Organization
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.OrganizationEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(OrganizationActionValue.MemberInvited)]
    public sealed record OrganizationMemberInvitedEvent : OrganizationEvent
    {
        [JsonPropertyName("action")]
        public override string Action => OrganizationAction.MemberInvited;

        [JsonPropertyName("invitation")]
        public Invitation Invitation { get; init; }

        [JsonPropertyName("user")]
        public User User { get; init; }
    }
}
