namespace Octokit.Webhooks.Models.DeploymentStatusEvent
{
    using System;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    [PublicAPI]
    public sealed record DeploymentStatus
    {
        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("state")]
        public DeploymentStatusState State { get; init; }

        [JsonPropertyName("creator")]
        public User Creator { get; init; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; init; } = null!;

        [JsonPropertyName("environment")]
        public string Environment { get; init; } = null!;

        [JsonPropertyName("target_url")]
        public string TargetUrl { get; init; } = null!;

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset CreatedAt { get; init; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset UpdatedAt { get; init; }

        [JsonPropertyName("deployment_url")]
        public string DeploymentUrl { get; init; } = null!;

        [JsonPropertyName("repository_url")]
        public string RepositoryUrl { get; init; } = null!;

        [JsonPropertyName("performed_via_github_app")]
        public App? PerformedViaGithubApp { get; init; }
    }
}
