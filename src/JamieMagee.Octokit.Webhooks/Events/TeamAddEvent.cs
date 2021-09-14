namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;

    [WebhookEventType(WebhookEventType.TeamAdd)]
    public sealed record TeamAddEvent : WebhookEvent
    {
        [JsonPropertyName("team")]
        public Models.Team team { get; init; } = null!;
    }
}
