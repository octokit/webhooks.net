namespace Octokit.Webhooks.Events.Organization;

[PublicAPI]
[WebhookActionType(OrganizationActionValue.MemberRemoved)]
public sealed record OrganizationMemberRemovedEvent : OrganizationEvent
{
    [JsonPropertyName("action")]
    public override string Action => OrganizationAction.MemberRemoved;

    [JsonPropertyName("membership")]
    public Octokit.Webhooks.Models.Membership Membership { get; init; } = null!;
}
