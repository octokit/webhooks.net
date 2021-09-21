namespace Octokit.Webhooks.Events.Discussion
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(DiscussionActionValue.Created)]
    public sealed record DiscussionCreatedEvent : DiscussionEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DiscussionAction.Created;
    }
}
