namespace Octokit.Webhooks.Events.CheckSuite;

[PublicAPI]
[WebhookActionType(CheckSuiteActionValue.Requested)]
public sealed record CheckSuiteRequestedEvent : CheckSuiteEvent
{
    [JsonPropertyName("action")]
    public override string Action => CheckSuiteAction.Requested;
}
