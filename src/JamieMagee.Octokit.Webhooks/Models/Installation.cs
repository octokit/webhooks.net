namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Installation
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("account")]
        public User Account { get; init; } = null!;

        [JsonPropertyName("repository_selection")]
        public InstallationRepositorySelection RepositorySelection { get; init; }

        [JsonPropertyName("access_tokens_url")]
        public string AccessTokensUrl { get; init; } = null!;

        [JsonPropertyName("repositories_url")]
        public string RepositoriesUrl { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; } = null!;

        [JsonPropertyName("app_id")]
        public int AppId { get; init; }

        [JsonPropertyName("app_slug")]
        public string? AppSlug { get; init; }

        [JsonPropertyName("target_id")]
        public int TargetId { get; init; }

        [JsonPropertyName("target_type")]
        public InstallationTargetType TargetType { get; init; }

        [JsonPropertyName("permissions")]
        public AppPermissions? Permissions { get; init; }

        [JsonPropertyName("events")]
        public IEnumerable<AppEvent>? Events { get; init; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;

        [JsonPropertyName("single_file_name")]
        public string? SingleFileName { get; init; }

        [JsonPropertyName("has_multiple_single_files")]
        public bool? HasMultipleSingleFiles { get; init; }

        [JsonPropertyName("single_file_paths")]
        public IEnumerable<string>? SingleFilePaths { get; init; }

        [JsonPropertyName("suspended_by")]
        public User? SuspendedBy { get; init; }

        [JsonPropertyName("suspended_at")]
        public string? SuspendedAt { get; init; }
    }
}
