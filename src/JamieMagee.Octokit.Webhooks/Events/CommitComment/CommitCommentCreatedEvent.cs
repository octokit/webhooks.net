namespace JamieMagee.Octokit.Webhooks.Events.CommitComment
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(CommitCommentActionValue.Created)]
    public sealed record CommitCommentCreatedEvent : CommitCommentEvent
    {
        [JsonPropertyName("action")]
        public override string Action => CommitCommentAction.Created;
    }
}
