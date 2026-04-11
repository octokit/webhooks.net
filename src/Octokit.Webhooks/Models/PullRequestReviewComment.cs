namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record PullRequestReviewComment
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("pull_request_review_id")]
    public long PullRequestReviewId { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("diff_hunk")]
    public required string DiffHunk { get; init; }

    [JsonPropertyName("path")]
    public required string Path { get; init; }

    [JsonPropertyName("position")]
    public int? Position { get; init; }

    [JsonPropertyName("original_position")]
    public long OriginalPosition { get; init; }

    [JsonPropertyName("commit_id")]
    public required string CommitId { get; init; }

    [JsonPropertyName("original_commit_id")]
    public required string OriginalCommitId { get; init; }

    [JsonPropertyName("user")]
    public required User User { get; init; }

    [JsonPropertyName("body")]
    public required string Body { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("pull_request_url")]
    public required string PullRequestUrl { get; init; }

    [JsonPropertyName("author_association")]
    [JsonConverter(typeof(StringEnumConverter<AuthorAssociation>))]
    public required StringEnum<AuthorAssociation> AuthorAssociation { get; init; }

    [JsonPropertyName("_links")]
    public required PullRequestReviewCommentLinks Links { get; init; }

    [JsonPropertyName("reactions")]
    public required Reactions Reactions { get; init; }

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
    public required StringEnum<Side> Side { get; init; }

    [JsonPropertyName("in_reply_to_id")]
    public long? InReplyToId { get; init; }

    [JsonPropertyName("subject_type")]
    [JsonConverter(typeof(StringEnumConverter<PullRequestReviewCommentSubjectType>))]
    public StringEnum<PullRequestReviewCommentSubjectType>? SubjectType { get; init; }
}
