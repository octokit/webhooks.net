namespace JamieMagee.Octokit.Webhooks.Events.Team
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(TeamActionValue.Created)]
    public sealed record TeamCreatedEvent : TeamEvent
    {
        [JsonPropertyName("action")]
        public override string Action => TeamAction.Created;
    }
}
