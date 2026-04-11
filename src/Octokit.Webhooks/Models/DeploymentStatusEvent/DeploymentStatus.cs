namespace Octokit.Webhooks.Models.DeploymentStatusEvent;

[PublicAPI]
public sealed record DeploymentStatus
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("state")]
    [JsonConverter(typeof(StringEnumConverter<DeploymentStatusState>))]
    public required StringEnum<DeploymentStatusState> State { get; init; }

    [JsonPropertyName("creator")]
    public required User Creator { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("environment")]
    public required string Environment { get; init; }

    [JsonPropertyName("environment_url")]
    public string? EnvironmentUrl { get; init; }

    [JsonPropertyName("log_url")]
    public string? LogUrl { get; init; }

    [JsonPropertyName("target_url")]
    public required string TargetUrl { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("deployment_url")]
    public required string DeploymentUrl { get; init; }

    [JsonPropertyName("repository_url")]
    public required string RepositoryUrl { get; init; }

    [JsonPropertyName("performed_via_github_app")]
    public App? PerformedViaGithubApp { get; init; }
}
