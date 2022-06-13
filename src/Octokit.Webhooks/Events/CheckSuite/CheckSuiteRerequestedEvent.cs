namespace Octokit.Webhooks.Events.CheckSuite;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(CheckSuiteActionValue.Rerequested)]
public sealed record CheckSuiteRerequestedEvent : CheckSuiteEvent
{
    [JsonPropertyName("action")]
    public override string Action => CheckSuiteAction.Rerequested;
}