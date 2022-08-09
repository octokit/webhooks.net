namespace Octokit.Webhooks.Events.Milestone;

[PublicAPI]
[WebhookActionType(MilestoneActionValue.Created)]
public sealed record MilestoneCreatedEvent : MilestoneEvent
{
    [JsonPropertyName("action")]
    public override string Action => MilestoneAction.Created;
}
