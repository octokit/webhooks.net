namespace Octokit.Webhooks.Events.Release;

[PublicAPI]
[WebhookActionType(ReleaseActionValue.Prereleased)]
public sealed record ReleasePrereleasedEvent : ReleaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => ReleaseAction.Prereleased;
}
