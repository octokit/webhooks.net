namespace Octokit.Webhooks.Events.Label;

[PublicAPI]
[WebhookActionType(LabelActionValue.Created)]
public sealed record LabelCreatedEvent : LabelEvent
{
    [JsonPropertyName("action")]
    public override string Action => LabelAction.Created;
}
