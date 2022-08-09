namespace Octokit.Webhooks.Events.DeployKey;

[PublicAPI]
[WebhookActionType(DeployKeyActionValue.Deleted)]
public sealed record DeployKeyDeletedEvent : DeployKeyEvent
{
    [JsonPropertyName("action")]
    public override string Action => DeployKeyAction.Deleted;
}
