namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.GollumEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.Gollum)]
public sealed record GollumEvent : WebhookEvent
{
    [JsonPropertyName("pages")]
    public IEnumerable<Page> Pages { get; init; } = null!;
}
