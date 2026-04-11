namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Package)]
[JsonConverter(typeof(WebhookConverter<PackageEvent>))]
public abstract record PackageEvent : WebhookEvent
{
    [JsonPropertyName("package")]
    public required Models.Package Package { get; init; }
}
