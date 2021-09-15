namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Milestone)]
    [JsonConverter(typeof(WebhookConverter<MilestoneEvent>))]
    public abstract record MilestoneEvent : WebhookEvent
    {
        [JsonPropertyName("milestone")]
        public Models.Milestone Milestone { get; init; } = null!;
    }
}
