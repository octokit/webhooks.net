namespace Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record TeamParent
    {
        [JsonPropertyName("description")]
        public string? Description { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("slug")]
        public string Slug { get; init; } = null!;

        [JsonPropertyName("privacy")]
        public TeamParentPrivacy Privacy { get; init; }

        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; } = null!;

        [JsonPropertyName("members_url")]
        public string MembersUrl { get; init; } = null!;

        [JsonPropertyName("repositories_url")]
        public string RepositoriesUrl { get; init; } = null!;

        [JsonPropertyName("permission")]
        public string Permission { get; init; } = null!;
    }
}
