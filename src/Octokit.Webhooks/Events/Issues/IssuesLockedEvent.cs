namespace Octokit.Webhooks.Events.Issues;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(IssuesActionValue.Locked)]
public sealed record IssuesLockedEvent : IssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssuesAction.Locked;
}