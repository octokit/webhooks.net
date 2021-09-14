namespace JamieMagee.Octokit.Webhooks.Models.StatusEvent
{
    using System.Text.Json.Serialization;

    public sealed record CommitDetailsTree
    {
        [JsonPropertyName("sha")]
        public string Sha { get; init; } = null!;
        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;
    }
}
