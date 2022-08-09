namespace Octokit.Webhooks.Events.Discussion;

[PublicAPI]
[WebhookActionType(DiscussionActionValue.Labeled)]
public sealed record DiscussionLabeledEvent : DiscussionEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionAction.Labeled;

    [JsonPropertyName("label")]
    public Octokit.Webhooks.Models.Label Label { get; init; } = null!;
}
