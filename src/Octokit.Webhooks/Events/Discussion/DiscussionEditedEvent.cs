namespace Octokit.Webhooks.Events.Discussion
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Models.DiscussionEvent;

    [PublicAPI]
    [WebhookActionType(DiscussionActionValue.Edited)]
    public sealed record DiscussionEditedEvent : DiscussionEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DiscussionAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
