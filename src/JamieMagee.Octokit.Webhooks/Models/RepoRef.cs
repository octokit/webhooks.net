namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class RepoRef
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
    }
}
