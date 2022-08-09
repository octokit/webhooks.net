namespace Octokit.Webhooks.Events.SecurityAdvisory;

[PublicAPI]
[WebhookActionType(SecurityAdvisoryActionValue.Performed)]
public sealed record SecurityAdvisoryPerformedEvent : SecurityAdvisoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => SecurityAdvisoryAction.Performed;
}
