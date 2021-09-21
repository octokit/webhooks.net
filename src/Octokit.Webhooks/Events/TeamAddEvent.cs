namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.TeamAdd)]
    public sealed record TeamAddEvent : WebhookEvent
    {
        [JsonPropertyName("team")]
        public Models.Team Team { get; init; } = null!;
    }
}
