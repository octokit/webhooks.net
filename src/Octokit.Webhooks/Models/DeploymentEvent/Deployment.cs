namespace Octokit.Webhooks.Models.DeploymentEvent;

[PublicAPI]
public sealed record Deployment
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("sha")]
    public required string Sha { get; init; }

    [JsonPropertyName("ref")]
    public required string Ref { get; init; }

    [JsonPropertyName("task")]
    public required string Task { get; init; }

    [JsonPropertyName("payload")]
    public JsonElement? Payload { get; init; }

    [JsonPropertyName("original_environment")]
    public required string OriginalEnvironment { get; init; }

    [JsonPropertyName("environment")]
    public required string Environment { get; init; }

    [JsonPropertyName("transient_environment")]
    public bool? TransientEnvironment { get; init; }

    [JsonPropertyName("production_environment")]
    public bool? ProductionEnvironment { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("creator")]
    public required User Creator { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("statuses_url")]
    public required string StatusesUrl { get; init; }

    [JsonPropertyName("repository_url")]
    public required string RepositoryUrl { get; init; }

    [JsonPropertyName("performed_via_github_app")]
    public App? PerformedViaGithubApp { get; init; }
}
