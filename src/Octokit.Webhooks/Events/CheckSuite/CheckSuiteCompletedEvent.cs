namespace Octokit.Webhooks.Events.CheckSuite;

[PublicAPI]
[WebhookActionType(CheckSuiteActionValue.Completed)]
public sealed record CheckSuiteCompletedEvent : CheckSuiteEvent
{
    [JsonPropertyName("action")]
    public override string Action => CheckSuiteAction.Completed;
}
