namespace Octokit.Webhooks.Events.SecurityAdvisory;

[PublicAPI]
[WebhookActionType(SecurityAdvisoryActionValue.Withdrawn)]
public sealed record SecurityAdvisoryWithdrawnEvent : SecurityAdvisoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => SecurityAdvisoryAction.Withdrawn;
}
