namespace Octokit.Webhooks.Events.Organization;

using Octokit.Webhooks.Models.OrganizationEvent;

[PublicAPI]
[WebhookActionType(OrganizationActionValue.MemberInvited)]
public sealed record OrganizationMemberInvitedEvent : OrganizationEvent
{
    [JsonPropertyName("action")]
    public override string Action => OrganizationAction.MemberInvited;

    [JsonPropertyName("invitation")]
    public required Invitation Invitation { get; init; }

    [JsonPropertyName("user")]
    public required User User { get; init; }
}
