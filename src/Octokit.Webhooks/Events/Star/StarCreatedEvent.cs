namespace Octokit.Webhooks.Events.Star;

[PublicAPI]
[WebhookActionType(StarActionValue.Created)]
public sealed record StarCreatedEvent : StarEvent
{
    [JsonPropertyName("action")]
    public override string Action => StarAction.Created;
}
