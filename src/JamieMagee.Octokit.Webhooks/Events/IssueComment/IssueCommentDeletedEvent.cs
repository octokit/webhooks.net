namespace JamieMagee.Octokit.Webhooks.Events.IssueComment
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record IssueCommentDeletedEvent : IssueCommentEvent
    {
        [JsonPropertyName("action")]
        public override string Action => IssueCommentAction.Deleted;
    }
}
