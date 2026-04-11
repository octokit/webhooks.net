namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.PageBuildEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.PageBuild)]
public sealed record PageBuildEvent : WebhookEvent
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("build")]
    public required Build Build { get; init; }
}
