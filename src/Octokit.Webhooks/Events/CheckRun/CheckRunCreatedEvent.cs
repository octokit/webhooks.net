namespace Octokit.Webhooks.Events.CheckRun;

[PublicAPI]
[WebhookActionType(CheckRunActionValue.Created)]
public sealed record CheckRunCreatedEvent : CheckRunEvent
{
    [JsonPropertyName("action")]
    public override string Action => CheckRunAction.Created;
}
