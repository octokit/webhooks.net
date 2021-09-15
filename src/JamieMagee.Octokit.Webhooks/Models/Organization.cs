namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Organization
    {
        [JsonPropertyName("login")]
        public string Login { get; init; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string? HtmlUrl { get; init; }

        [JsonPropertyName("repos_url")]
        public string ReposUrl { get; init; } = null!;

        [JsonPropertyName("events_url")]
        public string EventsUrl { get; init; } = null!;

        [JsonPropertyName("hooks_url")]
        public string HooksUrl { get; init; } = null!;

        [JsonPropertyName("issues_url")]
        public string IssuesUrl { get; init; } = null!;

        [JsonPropertyName("members_url")]
        public string MembersUrl { get; init; } = null!;

        [JsonPropertyName("public_members_url")]
        public string PublicMembersUrl { get; init; } = null!;

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; init; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; init; }
    }
}
