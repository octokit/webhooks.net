namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Package)]
    [JsonConverter(typeof(WebhookConverter<PackageEvent>))]
    public abstract record PackageEvent : WebhookEvent
    {
        [JsonPropertyName("package")]
        public Models.Package Package { get; init; }
    }
}
