namespace Octokit.Webhooks.Events.Membership;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(MembershipActionValue.Removed)]
public sealed record MembershipRemovedEvent : MembershipEvent
{
    [JsonPropertyName("action")]
    public override string Action => MembershipAction.Removed;
}
