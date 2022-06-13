namespace Octokit.Webhooks.Events.Issues;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Models;

[PublicAPI]
[WebhookActionType(IssuesActionValue.Milestoned)]
public sealed record IssuesMilestonedEvent : IssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssuesAction.Milestoned;

    [JsonPropertyName("milestone")]
    public Milestone Milestone { get; init; } = null!;
}