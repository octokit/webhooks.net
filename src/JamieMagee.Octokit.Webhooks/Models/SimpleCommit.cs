namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public sealed record SimpleCommit
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("tree_id")]
        public string TreeId { get; set; } = null!;

        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;

        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; } = null!;

        [JsonPropertyName("author")]
        public Committer Author { get; set; } = null!;

        [JsonPropertyName("committer")]
        public Committer Committer { get; set; } = null!;
    }
}
