namespace Octokit.Webhooks.Events.CheckRun;

[PublicAPI]
[WebhookActionType(CheckRunActionValue.RequestedAction)]
public sealed record CheckRunRequestedActionEvent : CheckRunEvent
{
    [JsonPropertyName("action")]
    public override string Action => CheckRunAction.RequestedAction;
}
