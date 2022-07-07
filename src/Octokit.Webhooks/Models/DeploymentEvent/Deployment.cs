namespace Octokit.Webhooks.Models.DeploymentEvent;

using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
public sealed record Deployment
{
    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("sha")]
    public string Sha { get; init; } = null!;

    [JsonPropertyName("ref")]
    public string Ref { get; init; } = null!;

    [JsonPropertyName("task")]
    public string Task { get; init; } = null!;

    [JsonPropertyName("payload")]
    public dynamic? Payload { get; init; }

    [JsonPropertyName("original_environment")]
    public string OriginalEnvironment { get; init; } = null!;

    [JsonPropertyName("environment")]
    public string Environment { get; init; } = null!;

    [JsonPropertyName("transient_environment")]
    public bool? TransientEnvironment { get; init; }

    [JsonPropertyName("production_environment")]
    public bool? ProductionEnvironment { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("creator")]
    public User Creator { get; init; } = null!;

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("statuses_url")]
    public string StatusesUrl { get; init; } = null!;

    [JsonPropertyName("repository_url")]
    public string RepositoryUrl { get; init; } = null!;

    [JsonPropertyName("performed_via_github_app")]
    public App? PerformedViaGithubApp { get; init; }
}
