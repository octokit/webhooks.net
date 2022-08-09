namespace Octokit.Webhooks.Events.IssueComment;

using Octokit.Webhooks.Models.IssueCommentEvent;

[PublicAPI]
[WebhookActionType(IssueCommentActionValue.Edited)]
public sealed record IssueCommentEditedEvent : IssueCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssueCommentAction.Edited;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
