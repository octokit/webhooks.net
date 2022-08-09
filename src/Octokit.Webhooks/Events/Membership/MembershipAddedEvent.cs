namespace Octokit.Webhooks.Events.Membership;

[PublicAPI]
[WebhookActionType(MembershipActionValue.Added)]
public sealed record MembershipAddedEvent : MembershipEvent
{
    [JsonPropertyName("action")]
    public override string Action => MembershipAction.Added;
}
