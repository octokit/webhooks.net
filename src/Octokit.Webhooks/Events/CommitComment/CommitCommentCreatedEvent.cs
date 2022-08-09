namespace Octokit.Webhooks.Events.CommitComment;

[PublicAPI]
[WebhookActionType(CommitCommentActionValue.Created)]
public sealed record CommitCommentCreatedEvent : CommitCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => CommitCommentAction.Created;
}
