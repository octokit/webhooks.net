namespace Octokit.Webhooks.Events.Milestone;

[PublicAPI]
[WebhookActionType(MilestoneActionValue.Opened)]
public sealed record MilestoneOpenedEvent : MilestoneEvent
{
    [JsonPropertyName("action")]
    public override string Action => MilestoneAction.Opened;
}
