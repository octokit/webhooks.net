namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;
using Octokit.Webhooks.Models;

[PublicAPI]
[WebhookEventType(WebhookEventType.OrgBlock)]
[JsonConverter(typeof(WebhookConverter<OrgBlockEvent>))]
public abstract record OrgBlockEvent : WebhookEvent
{
    [JsonPropertyName("blocked_user")]
    public User BlockedUser { get; init; } = null!;
}