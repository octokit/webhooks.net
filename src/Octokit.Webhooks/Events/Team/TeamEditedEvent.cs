namespace Octokit.Webhooks.Events.Team
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Models.TeamEvent;

    [PublicAPI]
    [WebhookActionType(TeamActionValue.Edited)]
    public sealed record TeamEditedEvent : TeamEvent
    {
        [JsonPropertyName("action")]
        public override string Action => TeamAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
