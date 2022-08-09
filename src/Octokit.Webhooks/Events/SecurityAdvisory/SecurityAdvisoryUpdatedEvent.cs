namespace Octokit.Webhooks.Events.SecurityAdvisory;

[PublicAPI]
[WebhookActionType(SecurityAdvisoryActionValue.Updated)]
public sealed record SecurityAdvisoryUpdatedEvent : SecurityAdvisoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => SecurityAdvisoryAction.Updated;
}
