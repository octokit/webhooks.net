namespace Octokit.Webhooks.Events.CheckSuite;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(CheckSuiteActionValue.Completed)]
public sealed record CheckSuiteCompletedEvent : CheckSuiteEvent
{
    [JsonPropertyName("action")]
    public override string Action => CheckSuiteAction.Completed;
}