namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record PullRequestReviewComment
{
    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("pull_request_review_id")]
    public long PullRequestReviewId { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("diff_hunk")]
    public string DiffHunk { get; init; } = null!;

    [JsonPropertyName("path")]
    public string Path { get; init; } = null!;

    [JsonPropertyName("position")]
    public int? Position { get; init; }

    [JsonPropertyName("original_position")]
    public long OriginalPosition { get; init; }

    [JsonPropertyName("commit_id")]
    public string CommitId { get; init; } = null!;

    [JsonPropertyName("original_commit_id")]
    public string OriginalCommitId { get; init; } = null!;

    [JsonPropertyName("user")]
    public User User { get; init; } = null!;

    [JsonPropertyName("body")]
    public string Body { get; init; } = null!;

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("pull_request_url")]
    public string PullRequestUrl { get; init; } = null!;

    [JsonPropertyName("author_association")]
    [JsonConverter(typeof(StringEnumConverter<AuthorAssociation>))]
    public StringEnum<AuthorAssociation> AuthorAssociation { get; init; } = null!;

    [JsonPropertyName("_links")]
    public PullRequestReviewCommentLinks Links { get; init; } = null!;

    [JsonPropertyName("reactions")]
    public Reactions Reactions { get; init; } = null!;

    [JsonPropertyName("start_line")]
    public int? StartLine { get; init; }

    [JsonPropertyName("original_start_line")]
    public int? OriginalStartLine { get; init; }

    [JsonPropertyName("start_side")]
    [JsonConverter(typeof(StringEnumConverter<Side>))]
    public StringEnum<Side>? StartSide { get; init; }

    [JsonPropertyName("line")]
    public int? Line { get; init; }

    [JsonPropertyName("original_line")]
    public long OriginalLine { get; init; }

    [JsonPropertyName("side")]
    [JsonConverter(typeof(StringEnumConverter<Side>))]
    public StringEnum<Side> Side { get; init; } = null!;

    [JsonPropertyName("in_reply_to_id")]
    public long? InReplyToId { get; init; }

    [JsonPropertyName("subject_type")]
    [JsonConverter(typeof(StringEnumConverter<PullRequestReviewCommentSubjectType>))]
    public StringEnum<PullRequestReviewCommentSubjectType>? SubjectType { get; init; }
}
