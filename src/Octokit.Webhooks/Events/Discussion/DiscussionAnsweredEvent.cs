namespace Octokit.Webhooks.Events.Discussion;

[PublicAPI]
[WebhookActionType(DiscussionActionValue.Answered)]
public sealed record DiscussionAnsweredEvent : DiscussionEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionAction.Answered;

    [JsonPropertyName("answer")]
    public DiscussionAnswer Answer { get; init; } = null!;
}
