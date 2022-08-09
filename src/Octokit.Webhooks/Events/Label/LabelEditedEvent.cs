namespace Octokit.Webhooks.Events.Label;

using Octokit.Webhooks.Models.LabelEvent;

[PublicAPI]
[WebhookActionType(LabelActionValue.Edited)]
public sealed record LabelEditedEvent : LabelEvent
{
    [JsonPropertyName("action")]
    public override string Action => LabelAction.Edited;

    [JsonPropertyName("changes")]
    public Changes? Changes { get; init; }
}
