namespace Octokit.Webhooks.Events.Issues;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Models;
using Octokit.Webhooks.Models.IssuesEvent;

[PublicAPI]
[WebhookActionType(IssuesActionValue.Edited)]
public sealed record IssuesEditedEvent : IssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssuesAction.Edited;

    [JsonPropertyName("label")]
    public Label? Label { get; init; }

    [JsonPropertyName("changes")]
    public Changes? Changes { get; init; }
}