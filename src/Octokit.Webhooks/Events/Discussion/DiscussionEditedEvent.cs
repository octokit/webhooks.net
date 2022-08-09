namespace Octokit.Webhooks.Events.Discussion;

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
