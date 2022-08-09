namespace Octokit.Webhooks.Events.Membership;

[PublicAPI]
[WebhookActionType(MembershipActionValue.Removed)]
public sealed record MembershipRemovedEvent : MembershipEvent
{
    [JsonPropertyName("action")]
    public override string Action => MembershipAction.Removed;
}
