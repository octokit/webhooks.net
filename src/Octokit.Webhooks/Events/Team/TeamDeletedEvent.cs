namespace Octokit.Webhooks.Events.Team
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(TeamActionValue.Deleted)]
    public sealed record TeamDeletedEvent : TeamEvent
    {
        [JsonPropertyName("action")]
        public override string Action => TeamAction.Deleted;
    }
}
