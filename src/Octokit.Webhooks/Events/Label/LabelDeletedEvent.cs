namespace Octokit.Webhooks.Events.Label;

[PublicAPI]
[WebhookActionType(LabelActionValue.Deleted)]
public sealed record LabelDeletedEvent : LabelEvent
{
    [JsonPropertyName("action")]
    public override string Action => LabelAction.Deleted;
}
