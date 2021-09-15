namespace JamieMagee.Octokit.Webhooks.Models.StatusEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record BranchCommit
    {
        [JsonPropertyName("sha")]
        public string Sha { get; init; } = null!;

        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;
    }
}
