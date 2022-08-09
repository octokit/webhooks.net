namespace Octokit.Webhooks.Events.OrgBlock;

[PublicAPI]
[WebhookActionType(OrgBlockActionValue.Blocked)]
public sealed record OrgBlockBlockedEvent : OrgBlockEvent
{
    [JsonPropertyName("action")]
    public override string Action => OrgBlockAction.Blocked;
}
