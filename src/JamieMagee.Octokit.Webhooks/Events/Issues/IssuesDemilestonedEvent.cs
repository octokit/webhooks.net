namespace JamieMagee.Octokit.Webhooks.Events.Issues
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(IssuesActionValue.Demilestoned)]
    public sealed record IssuesDemilestonedEvent : IssuesEvent
    {
        [JsonPropertyName("action")]
        public override string Action => IssuesAction.Demilestoned;

        [JsonPropertyName("milestone")]
        public Milestone Milestone { get; init; }
    }
}
