namespace Octokit.Webhooks.Events.Release;

[PublicAPI]
[WebhookActionType(ReleaseActionValue.Published)]
public sealed record ReleasePublishedEvent : ReleaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => ReleaseAction.Published;
}
