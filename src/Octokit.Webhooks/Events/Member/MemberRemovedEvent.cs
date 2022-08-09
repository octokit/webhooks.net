namespace Octokit.Webhooks.Events.Member;

[PublicAPI]
[WebhookActionType(MemberActionValue.Removed)]
public sealed record MemberRemovedEvent : MemberEvent
{
    [JsonPropertyName("action")]
    public override string Action => MemberAction.Removed;
}
