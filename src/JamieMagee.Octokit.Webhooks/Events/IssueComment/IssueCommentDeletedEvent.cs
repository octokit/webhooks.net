namespace JamieMagee.Octokit.Webhooks.Events.IssueComment
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(IssueCommentActionValue.Deleted)]
    public sealed record IssueCommentDeletedEvent : IssueCommentEvent
    {
        [JsonPropertyName("action")]
        public override string Action => IssueCommentAction.Deleted;
    }
}
