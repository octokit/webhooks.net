namespace Octokit.Webhooks.Events.Organization;

using Octokit.Webhooks.Models.OrganizationEvent;

[PublicAPI]
[WebhookActionType(OrganizationActionValue.Renamed)]
public sealed record OrganizationRenamedEvent : OrganizationEvent
{
    [JsonPropertyName("action")]
    public override string Action => OrganizationAction.Renamed;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
