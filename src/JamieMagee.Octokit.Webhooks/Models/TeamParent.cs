namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class TeamParent
    {
        [JsonPropertyName("description")] public string? Description;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; } = null!;

        [JsonPropertyName("slug")]
        public string Slug { get; set; } = null!;

        [JsonPropertyName("privacy")]
        public TeamParentPrivacy Privacy { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; } = null!;

        [JsonPropertyName("members_url")]
        public string MembersUrl { get; set; } = null!;

        [JsonPropertyName("repositories_url")]
        public string RepositoriesUrl { get; set; } = null!;

        [JsonPropertyName("permission")]
        public string Permission { get; set; } = null!;
    }
}
