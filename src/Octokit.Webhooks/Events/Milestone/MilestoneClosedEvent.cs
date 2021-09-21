namespace Octokit.Webhooks.Events.Milestone
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(MilestoneActionValue.Closed)]
    public sealed record MilestoneClosedEvent : MilestoneEvent
    {
        [JsonPropertyName("action")]
        public override string Action => MilestoneAction.Closed;
    }
}
