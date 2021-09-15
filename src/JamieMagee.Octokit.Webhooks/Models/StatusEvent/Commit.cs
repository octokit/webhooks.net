namespace JamieMagee.Octokit.Webhooks.Models.StatusEvent
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Commit
    {
        [JsonPropertyName("sha")]
        public string Sha { get; init; } = null!;

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("commit")]
        public CommitDetails CommitDetails { get; init; } = null!;

        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; } = null!;

        [JsonPropertyName("comments_url")]
        public string CommentsUrl { get; init; } = null!;

        [JsonPropertyName("author")]
        public User? Author { get; init; }

        [JsonPropertyName("committer")]
        public User? Committer { get; init; }

        [JsonPropertyName("parents")]
        public IEnumerable<CommitParent> Parents { get; init; } = null!;
    }
}
