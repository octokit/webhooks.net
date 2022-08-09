namespace Octokit.Webhooks.Events.Release;

[PublicAPI]
[WebhookActionType(ReleaseActionValue.Released)]
public sealed record ReleaseReleasedEvent : ReleaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => ReleaseAction.Released;
}
