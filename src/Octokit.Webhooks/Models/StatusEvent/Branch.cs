namespace Octokit.Webhooks.Models.StatusEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Branch
    {
        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("commit")]
        public BranchCommit Commit { get; init; } = null!;

        [JsonPropertyName("protected")]
        public bool Protected { get; init; }
    }
}
