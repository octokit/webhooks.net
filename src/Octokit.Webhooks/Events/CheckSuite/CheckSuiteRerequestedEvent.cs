namespace Octokit.Webhooks.Events.CheckSuite;

[PublicAPI]
[WebhookActionType(CheckSuiteActionValue.Rerequested)]
public sealed record CheckSuiteRerequestedEvent : CheckSuiteEvent
{
    [JsonPropertyName("action")]
    public override string Action => CheckSuiteAction.Rerequested;
}
