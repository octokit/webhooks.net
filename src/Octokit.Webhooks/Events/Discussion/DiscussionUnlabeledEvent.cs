namespace Octokit.Webhooks.Events.Discussion;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Models;

[PublicAPI]
[WebhookActionType(DiscussionActionValue.Unlabeled)]
public sealed record DiscussionUnlabeledEvent : DiscussionEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionAction.Unlabeled;

    [JsonPropertyName("label")]
    public Label Label { get; init; } = null!;
}
