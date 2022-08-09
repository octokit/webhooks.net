namespace Octokit.Webhooks.Events.Release;

[PublicAPI]
[WebhookActionType(ReleaseActionValue.Unpublished)]
public sealed record ReleaseUnpublishedEvent : ReleaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => ReleaseAction.Unpublished;
}
