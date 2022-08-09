namespace Octokit.Webhooks.Events.Milestone;

[PublicAPI]
[WebhookActionType(MilestoneActionValue.Closed)]
public sealed record MilestoneClosedEvent : MilestoneEvent
{
    [JsonPropertyName("action")]
    public override string Action => MilestoneAction.Closed;
}
