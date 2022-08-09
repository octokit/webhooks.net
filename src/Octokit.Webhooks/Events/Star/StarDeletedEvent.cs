namespace Octokit.Webhooks.Events.Star;

[PublicAPI]
[WebhookActionType(StarActionValue.Deleted)]
public sealed record StarDeletedEvent : StarEvent
{
    [JsonPropertyName("action")]
    public override string Action => StarAction.Deleted;
}
