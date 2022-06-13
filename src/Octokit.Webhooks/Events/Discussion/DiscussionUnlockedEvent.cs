namespace Octokit.Webhooks.Events.Discussion;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(DiscussionActionValue.Unlocked)]
public sealed record DiscussionUnlockedEvent : DiscussionEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionAction.Unlocked;
}
