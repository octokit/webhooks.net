namespace Octokit.Webhooks.Events.Organization;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Models;

[PublicAPI]
[WebhookActionType(OrganizationActionValue.MemberAdded)]
public sealed record OrganizationMemberAddedEvent : OrganizationEvent
{
    [JsonPropertyName("action")]
    public override string Action => OrganizationAction.MemberAdded;

    [JsonPropertyName("membership")]
    public Membership Membership { get; init; } = null!;
}