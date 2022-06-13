namespace Octokit.Webhooks.Events;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;
using Octokit.Webhooks.Models.StatusEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.Status)]
public sealed record StatusEvent : WebhookEvent
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("sha")]
    public string Sha { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; init; }

    [JsonPropertyName("target_url")]
    public string? TargetUrl { get; init; }

    [JsonPropertyName("context")]
    public string Context { get; init; } = null!;

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("state")]
    public StatusState State { get; init; }

    [JsonPropertyName("commit")]
    public Commit Commit { get; init; } = null!;

    [JsonPropertyName("branch")]
    public IEnumerable<Branch> Branch { get; init; } = null!;

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }
}
