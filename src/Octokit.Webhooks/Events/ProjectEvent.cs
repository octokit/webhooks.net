namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
[WebhookEventType(WebhookEventType.Project)]
[JsonConverter(typeof(WebhookConverter<ProjectEvent>))]
public abstract record ProjectEvent : WebhookEvent
{
    [JsonPropertyName("project")]
    public Models.Project Project { get; init; } = null!;
}