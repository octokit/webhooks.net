namespace Octokit.Webhooks.Events.Discussion
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Models.DiscussionEvent;

    [PublicAPI]
    [WebhookActionType(DiscussionActionValue.CategoryChanged)]
    public sealed record DiscussionCategoryChangedEvent : DiscussionEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DiscussionAction.CategoryChanged;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
