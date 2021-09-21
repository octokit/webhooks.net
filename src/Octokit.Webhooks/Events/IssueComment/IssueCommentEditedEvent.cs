namespace Octokit.Webhooks.Events.IssueComment
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
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
}
