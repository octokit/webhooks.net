namespace Octokit.Webhooks.Events.Organization;

[PublicAPI]
[WebhookActionType(OrganizationActionValue.Renamed)]
public sealed record OrganizationRenamedEvent : OrganizationEvent
{
    [JsonPropertyName("action")]
    public override string Action => OrganizationAction.Renamed;

    [JsonPropertyName("membership")]
    public Octokit.Webhooks.Models.Membership Membership { get; init; } = null!;
}
