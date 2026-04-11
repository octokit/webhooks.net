namespace Octokit.Webhooks.Events.Discussion;

[PublicAPI]
[WebhookActionType(DiscussionActionValue.Closed)]
public sealed record DiscussionClosedEvent : DiscussionEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionAction.Closed;
}
