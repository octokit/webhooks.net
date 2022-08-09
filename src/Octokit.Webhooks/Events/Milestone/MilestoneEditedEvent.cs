namespace Octokit.Webhooks.Events.Milestone;

using Octokit.Webhooks.Models.MilestoneEvent;

[PublicAPI]
[WebhookActionType(MilestoneActionValue.Edited)]
public sealed record MilestoneEditedEvent : MilestoneEvent
{
    [JsonPropertyName("action")]
    public override string Action => MilestoneAction.Edited;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
