namespace Octokit.Webhooks.Events.Discussion
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models.DiscussionEvent;
    using JetBrains.Annotations;

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
