namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.Package)]
    [JsonConverter(typeof(WebhookConverter<PackageEvent>))]
    public abstract record PackageEvent : WebhookEvent
    {
        [JsonPropertyName("package")]
        public Models.Package Package { get; init; }
    }
}
