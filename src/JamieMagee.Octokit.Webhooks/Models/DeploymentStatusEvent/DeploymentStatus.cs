namespace JamieMagee.Octokit.Webhooks.Models.DeploymentStatusEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record DeploymentStatus
    {
        [JsonPropertyName("url")]
        public string Url { get; init; }

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; }

        [JsonPropertyName("state")]
        public DeploymentStatusState State { get; init; }

        [JsonPropertyName("creator")]
        public User Creator { get; init; }

        [JsonPropertyName("description")]
        public string Description { get; init; }

        [JsonPropertyName("environment")]
        public string Environment { get; init; }

        [JsonPropertyName("target_url")]
        public string TargetUrl { get; init; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; }

        [JsonPropertyName("deployment_url")]
        public string DeploymentUrl { get; init; }

        [JsonPropertyName("repository_url")]
        public string RepositoryUrl { get; init; }

        [JsonPropertyName("performed_via_github_app")]
        public App? PerformedViaGithubApp { get; init; }
    }
}
