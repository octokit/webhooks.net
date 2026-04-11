namespace Octokit.Webhooks.Events.Organization;

[PublicAPI]
[WebhookActionType(OrganizationActionValue.MemberAdded)]
public sealed record OrganizationMemberAddedEvent : OrganizationEvent
{
    [JsonPropertyName("action")]
    public override string Action => OrganizationAction.MemberAdded;

    [JsonPropertyName("membership")]
    public required Octokit.Webhooks.Models.Membership Membership { get; init; }
}
