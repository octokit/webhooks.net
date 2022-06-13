namespace Octokit.Webhooks.Models;

using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
public sealed record Milestone
{
    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("labels_url")]
    public string LabelsUrl { get; init; } = null!;

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("number")]
    public long Number { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; } = null!;

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("creator")]
    public User Creator { get; init; } = null!;

    [JsonPropertyName("open_issues")]
    public long OpenIssues { get; init; }

    [JsonPropertyName("closed_issues")]
    public long ClosedIssues { get; init; }

    [JsonPropertyName("state")]
    public MilestoneState State { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("due_on")]
    public string? DueOn { get; init; }

    [JsonPropertyName("closed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? ClosedAt { get; init; }
}