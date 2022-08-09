namespace Octokit.Webhooks.Events.Organization;

using Octokit.Webhooks.Models.OrganizationEvent;

[PublicAPI]
[WebhookActionType(OrganizationActionValue.MemberInvited)]
public sealed record OrganizationMemberInvitedEvent : OrganizationEvent
{
    [JsonPropertyName("action")]
    public override string Action => OrganizationAction.MemberInvited;

    [JsonPropertyName("invitation")]
    public Invitation Invitation { get; init; } = null!;

    [JsonPropertyName("user")]
    public User User { get; init; } = null!;
}
