namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
[WebhookEventType(WebhookEventType.Release)]
[JsonConverter(typeof(WebhookConverter<ReleaseEvent>))]
public abstract record ReleaseEvent : WebhookEvent
{
    [JsonPropertyName("release")]
    public Models.Release Release { get; init; } = null!;
}
