namespace Octokit.Webhooks.Events.Discussion;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(DiscussionActionValue.Deleted)]
public sealed record DiscussionDeletedEvent : DiscussionEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionAction.Deleted;
}