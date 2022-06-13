namespace Octokit.Webhooks.Events.Discussion;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(DiscussionActionValue.Pinned)]
public sealed record DiscussionPinnedEvent : DiscussionEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionAction.Pinned;
}
