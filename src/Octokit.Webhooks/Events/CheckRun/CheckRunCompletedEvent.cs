namespace Octokit.Webhooks.Events.CheckRun;

[PublicAPI]
[WebhookActionType(CheckRunActionValue.Completed)]
public sealed record CheckRunCompletedEvent : CheckRunEvent
{
    [JsonPropertyName("action")]
    public override string Action => CheckRunAction.Completed;
}
