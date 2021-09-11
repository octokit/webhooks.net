namespace JamieMagee.Octokit.Webhooks.Events.CommitComment
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record CommitCommentCreatedEvent : CommitCommentEvent
    {
        [JsonPropertyName("action")]
        public override string Action => CommitCommentAction.Created;
    }
}
