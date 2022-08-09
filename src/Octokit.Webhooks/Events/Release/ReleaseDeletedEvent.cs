namespace Octokit.Webhooks.Events.Release;

[PublicAPI]
[WebhookActionType(ReleaseActionValue.Deleted)]
public sealed record ReleaseDeletedEvent : ReleaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => ReleaseAction.Deleted;
}
