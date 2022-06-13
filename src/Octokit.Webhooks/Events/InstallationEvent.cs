namespace Octokit.Webhooks.Events;

using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;
using Octokit.Webhooks.Models;

[PublicAPI]
[WebhookEventType(WebhookEventType.Installation)]
[JsonConverter(typeof(WebhookConverter<InstallationEvent>))]
public abstract record InstallationEvent : WebhookEvent
{
    [JsonPropertyName("installation")]
    public new Models.Installation Installation { get; init; } = null!;

    [JsonPropertyName("repositories")]
    public IEnumerable<Models.InstallationEvent.Repository> Repositories { get; init; } = null!;

    [JsonPropertyName("requester")]
    public User? Requester { get; init; }
}