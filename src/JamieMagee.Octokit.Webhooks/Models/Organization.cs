namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class Organization
    {
        [JsonPropertyName("login")] public string Login { get; set; } = null!;

        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("node_id")] public string NodeId { get; set; } = null!;

        [JsonPropertyName("url")] public string Url { get; set; } = null!;

        [JsonPropertyName("html_url")] public string? HtmlUrl { get; set; }

        [JsonPropertyName("repos_url")] public string ReposUrl { get; set; } = null!;

        [JsonPropertyName("events_url")] public string EventsUrl { get; set; } = null!;

        [JsonPropertyName("hooks_url")] public string HooksUrl { get; set; } = null!;

        [JsonPropertyName("issues_url")] public string IssuesUrl { get; set; } = null!;

        [JsonPropertyName("members_url")] public string MembersUrl { get; set; } = null!;

        [JsonPropertyName("public_members_url")]
        public string PublicMembersUrl { get; set; } = null!;

        [JsonPropertyName("avatar_url")] public string AvatarUrl { get; set; } = null!;

        [JsonPropertyName("description")] public string? Description { get; set; }
    }
}
