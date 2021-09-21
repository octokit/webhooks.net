namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Package)]
    [JsonConverter(typeof(WebhookConverter<PackageEvent>))]
    public abstract record PackageEvent : WebhookEvent
    {
        [JsonPropertyName("package")]
        public Models.Package Package { get; init; } = null!;
    }
}
