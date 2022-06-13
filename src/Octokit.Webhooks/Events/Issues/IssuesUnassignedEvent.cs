namespace Octokit.Webhooks.Events.Issues;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Models;

[PublicAPI]
[WebhookActionType(IssuesActionValue.Unassigned)]
public sealed record IssuesUnassignedEvent : IssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssuesAction.Unassigned;

    [JsonPropertyName("assignee")]
    public User? Assignee { get; init; }
}
