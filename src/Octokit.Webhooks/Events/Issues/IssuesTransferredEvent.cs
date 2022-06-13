namespace Octokit.Webhooks.Events.Issues;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Models.IssuesEvent;

[PublicAPI]
[WebhookActionType(IssuesActionValue.Transferred)]
public sealed record IssuesTransferredEvent : IssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssuesAction.Transferred;

    [JsonPropertyName("changes")]
    public Changes? Changes { get; init; }
}