namespace JamieMagee.Octokit.Webhooks.Events.Milestone
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record MilestoneCreatedEvent : MilestoneEvent
    {
        [JsonPropertyName("action")]
        public override string Action => MilestoneAction.Created;
    }
}
