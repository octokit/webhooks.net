namespace Octokit.Webhooks.Events.Discussion;

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
