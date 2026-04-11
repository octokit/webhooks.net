namespace Octokit.Webhooks.Events.Discussion;

[PublicAPI]
[WebhookActionType(DiscussionActionValue.Reopened)]
public sealed record DiscussionReopenedEvent : DiscussionEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionAction.Reopened;
}
