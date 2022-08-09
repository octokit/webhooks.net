namespace Octokit.Webhooks.Events.Discussion;

[PublicAPI]
[WebhookActionType(DiscussionActionValue.Unanswered)]
public sealed record DiscussionUnansweredEvent : DiscussionEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionAction.Unanswered;

    [JsonPropertyName("old_answer")]
    public DiscussionAnswer OldAnswer { get; init; } = null!;
}
