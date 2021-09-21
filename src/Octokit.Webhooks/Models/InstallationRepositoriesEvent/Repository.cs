namespace Octokit.Webhooks.Models.InstallationRepositoriesEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Repository
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("full_name")]
        public string FullName { get; init; } = null!;

        [JsonPropertyName("private")]
        public bool Private { get; init; }
    }
}
