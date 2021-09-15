namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record PullRequestReviewComment
    {
        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("pull_request_review_id")]
        public int PullRequestReviewId { get; init; }

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("diff_hunk")]
        public string DiffHunk { get; init; } = null!;

        [JsonPropertyName("path")]
        public string Path { get; init; } = null!;

        [JsonPropertyName("position")]
        public int? Position { get; init; }

        [JsonPropertyName("original_position")]
        public int OriginalPosition { get; init; }

        [JsonPropertyName("commit_id")]
        public string CommitId { get; init; } = null!;

        [JsonPropertyName("original_commit_id")]
        public string OriginalCommitId { get; init; } = null!;

        [JsonPropertyName("user")]
        public User User { get; init; } = null!;

        [JsonPropertyName("body")]
        public string Body { get; init; } = null!;

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; } = null!;

        [JsonPropertyName("pull_request_url")]
        public string PullRequestUrl { get; init; } = null!;

        [JsonPropertyName("author_association")]
        public AuthorAssociation AuthorAssociation { get; init; }

        [JsonPropertyName("_links")]
        public PullRequestReviewCommentLinks Links { get; init; } = null!;

        [JsonPropertyName("start_line")]
        public int? StartLine { get; init; }

        [JsonPropertyName("original_start_line")]
        public int? OriginalStartLine { get; init; }

        [JsonPropertyName("start_side")]
        public Side? StartSide { get; init; }

        [JsonPropertyName("line")]
        public int? Line { get; init; }

        [JsonPropertyName("original_line")]
        public int OriginalLine { get; init; }

        [JsonPropertyName("side")]
        public Side Side { get; init; }

        [JsonPropertyName("in_reply_to_id")]
        public int? InReplyToId { get; init; }
    }
}
