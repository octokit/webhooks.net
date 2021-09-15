namespace JamieMagee.Octokit.Webhooks.Events.IssueComment
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models.IssueCommentEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(IssueCommentActionValue.Edited)]
    public sealed record IssueCommentEditedEvent : IssueCommentEvent
    {
        [JsonPropertyName("action")]
        public override string Action => IssueCommentAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; }
    }
}
