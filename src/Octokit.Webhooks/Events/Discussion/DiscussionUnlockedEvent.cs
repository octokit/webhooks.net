namespace Octokit.Webhooks.Events.Discussion;

[PublicAPI]
[WebhookActionType(DiscussionActionValue.Unlocked)]
public sealed record DiscussionUnlockedEvent : DiscussionEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionAction.Unlocked;
}
