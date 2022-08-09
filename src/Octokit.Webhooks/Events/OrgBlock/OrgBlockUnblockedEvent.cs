namespace Octokit.Webhooks.Events.OrgBlock;

[PublicAPI]
[WebhookActionType(OrgBlockActionValue.Unblocked)]
public sealed record OrgBlockUnblockedEvent : OrgBlockEvent
{
    [JsonPropertyName("action")]
    public override string Action => OrgBlockAction.Unblocked;
}
