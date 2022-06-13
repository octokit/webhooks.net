namespace Octokit.Webhooks.Events.OrgBlock;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(OrgBlockActionValue.Blocked)]
public sealed record OrgBlockBlockedEvent : OrgBlockEvent
{
    [JsonPropertyName("action")]
    public override string Action => OrgBlockAction.Blocked;
}