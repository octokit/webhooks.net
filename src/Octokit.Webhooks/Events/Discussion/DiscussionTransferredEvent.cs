namespace Octokit.Webhooks.Events.Discussion;

using Octokit.Webhooks.Models.DiscussionEvent;

[PublicAPI]
[WebhookActionType(DiscussionActionValue.Transferred)]
public sealed record DiscussionTransferredEvent : DiscussionEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionAction.Transferred;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
