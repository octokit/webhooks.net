namespace Octokit.Webhooks.Models.PullRequestReviewThreadEvent
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Thread
    {
        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("comments")]
        public IEnumerable<PullRequestReviewComment> Comments { get; init; } = null!;
    }
}
