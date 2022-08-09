namespace Octokit.Webhooks.Events.Watch;

[PublicAPI]
[WebhookActionType(WatchActionValue.Started)]
public sealed record WatchStartedEvent : WatchEvent
{
    [JsonPropertyName("action")]
    public override string Action => WatchAction.Started;
}
