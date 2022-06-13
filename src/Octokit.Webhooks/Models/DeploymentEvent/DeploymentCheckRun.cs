namespace Octokit.Webhooks.Models.DeploymentEvent;

using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
public sealed record DeploymentCheckRun
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("head_sha")]
    public string HeadSha { get; init; } = null!;

    [JsonPropertyName("external_id")]
    public string ExternalId { get; init; } = null!;

    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("details_url")]
    public string DetailsUrl { get; init; } = null!;

    [JsonPropertyName("status")]
    public DeploymentCheckRunStatus Status { get; init; }

    [JsonPropertyName("conclusion")]
    public DeploymentCheckRunConclusion? Conclusion { get; init; }

    [JsonPropertyName("started_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset StartedAt { get; init; }

    [JsonPropertyName("completed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? CompletedAt { get; init; }
}
