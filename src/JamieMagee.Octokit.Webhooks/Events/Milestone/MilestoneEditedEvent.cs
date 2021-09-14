namespace JamieMagee.Octokit.Webhooks.Events.Milestone
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.MilestoneEvent;

    [WebhookActionType(MilestoneActionValue.Edited)]
    public sealed record MilestoneEditedEvent : MilestoneEvent
    {
        [JsonPropertyName("action")]
        public override string Action => MilestoneAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; }
    }
}
