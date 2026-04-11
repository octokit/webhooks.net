namespace Octokit.Webhooks.Events.Release;

using Octokit.Webhooks.Models.ReleaseEvent;

[PublicAPI]
[WebhookActionType(ReleaseActionValue.Edited)]
public sealed record ReleaseEditedEvent : ReleaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => ReleaseAction.Edited;

    [JsonPropertyName("changes")]
    public required Changes Changes { get; init; }
}
