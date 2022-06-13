namespace Octokit.Webhooks.Events.Membership;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(MembershipActionValue.Added)]
public sealed record MembershipAddedEvent : MembershipEvent
{
    [JsonPropertyName("action")]
    public override string Action => MembershipAction.Added;
}