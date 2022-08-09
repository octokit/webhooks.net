namespace Octokit.Webhooks.Events.CheckRun;

[PublicAPI]
[WebhookActionType(CheckRunActionValue.Rerequested)]
public sealed record CheckRunRerequestedEvent : CheckRunEvent
{
    [JsonPropertyName("action")]
    public override string Action => CheckRunAction.Rerequested;
}
