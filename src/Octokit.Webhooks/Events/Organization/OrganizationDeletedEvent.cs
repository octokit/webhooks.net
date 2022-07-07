namespace Octokit.Webhooks.Events.Organization;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Models;

[PublicAPI]
[WebhookActionType(OrganizationActionValue.Deleted)]
public sealed record OrganizationDeletedEvent : OrganizationEvent
{
    [JsonPropertyName("action")]
    public override string Action => OrganizationAction.Deleted;

    [JsonPropertyName("membership")]
    public Membership? Membership { get; init; }
}
