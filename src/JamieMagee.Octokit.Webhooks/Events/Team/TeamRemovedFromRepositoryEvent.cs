namespace JamieMagee.Octokit.Webhooks.Events.Team
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(TeamActionValue.RemovedFromRepository)]
    public sealed record TeamRemovedFromRepositoryEvent : TeamEvent
    {
        [JsonPropertyName("action")]
        public override string Action => TeamAction.RemovedFromRepository;
    }
}