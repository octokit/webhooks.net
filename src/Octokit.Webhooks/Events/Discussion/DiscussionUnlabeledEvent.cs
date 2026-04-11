namespace Octokit.Webhooks.Events.Discussion;

[PublicAPI]
[WebhookActionType(DiscussionActionValue.Unlabeled)]
public sealed record DiscussionUnlabeledEvent : DiscussionEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionAction.Unlabeled;

    [JsonPropertyName("label")]
    public required Octokit.Webhooks.Models.Label Label { get; init; }
}
