namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
[WebhookEventType(WebhookEventType.SecurityAdvisory)]
[JsonConverter(typeof(WebhookConverter<SecurityAdvisoryEvent>))]
public abstract record SecurityAdvisoryEvent : WebhookEvent
{
    [JsonPropertyName("security_advisory")]
    public Models.SecurityAdvisoryEvent.SecurityAdvisory SecurityAdvisory { get; init; } = null!;
}