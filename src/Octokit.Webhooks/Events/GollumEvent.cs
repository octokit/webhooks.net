namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.GollumEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.Gollum)]
public sealed record GollumEvent : WebhookEvent
{
    [JsonPropertyName("pages")]
    public required IReadOnlyList<Page> Pages { get; init; }
}
