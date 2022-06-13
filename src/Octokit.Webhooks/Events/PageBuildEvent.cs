namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Models.PageBuildEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.PageBuild)]
public sealed record PageBuildEvent : WebhookEvent
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("build")]
    public Build Build { get; init; } = null!;
}