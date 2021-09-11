namespace JamieMagee.Octokit.Webhooks.Events.Milestone
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record MilestoneEditedEvent : MilestoneEvent
    {
        [JsonPropertyName("action")]
        public override string Action => MilestoneAction.Edited;
    }
}
