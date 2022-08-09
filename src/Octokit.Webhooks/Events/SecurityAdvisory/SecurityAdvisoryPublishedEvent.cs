namespace Octokit.Webhooks.Events.SecurityAdvisory;

[PublicAPI]
[WebhookActionType(SecurityAdvisoryActionValue.Published)]
public sealed record SecurityAdvisoryPublishedEvent : SecurityAdvisoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => SecurityAdvisoryAction.Published;
}
