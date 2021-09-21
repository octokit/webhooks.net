namespace Octokit.Webhooks.Events.Discussion
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models.DiscussionEvent;
    using JetBrains.Annotations;

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
