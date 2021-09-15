namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Project)]
    [JsonConverter(typeof(WebhookConverter<ProjectEvent>))]
    public abstract record ProjectEvent : WebhookEvent
    {
        [JsonPropertyName("project")]
        public Models.Project Project { get; init; } = null!;
    }
}
