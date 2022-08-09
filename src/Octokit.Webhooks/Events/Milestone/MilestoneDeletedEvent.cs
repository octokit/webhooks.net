namespace Octokit.Webhooks.Events.Milestone;

[PublicAPI]
[WebhookActionType(MilestoneActionValue.Deleted)]
public sealed record MilestoneDeletedEvent : MilestoneEvent
{
    [JsonPropertyName("action")]
    public override string Action => MilestoneAction.Deleted;
}
