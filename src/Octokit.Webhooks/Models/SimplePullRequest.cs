namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record SimplePullRequest
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("diff_url")]
    public required string DiffUrl { get; init; }

    [JsonPropertyName("patch_url")]
    public required string PatchUrl { get; init; }

    [JsonPropertyName("issue_url")]
    public required string IssueUrl { get; init; }

    [JsonPropertyName("number")]
    public long Number { get; init; }

    [JsonPropertyName("state")]
    [JsonConverter(typeof(StringEnumConverter<SimplePullRequestState>))]
    public required StringEnum<SimplePullRequestState> State { get; init; }

    [JsonPropertyName("locked")]
    public bool Locked { get; init; }

    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("user")]
    public required User User { get; init; }

    [JsonPropertyName("body")]
    public string? Body { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("closed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? ClosedAt { get; init; }

    [JsonPropertyName("merged_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? MergedAt { get; init; }

    [JsonPropertyName("merge_commit_sha")]
    public string? MergeCommitSha { get; init; }

    [JsonPropertyName("assignee")]
    public User? Assignee { get; init; }

    [JsonPropertyName("assignees")]
    public required IReadOnlyList<User> Assignees { get; init; }

    [JsonPropertyName("requested_reviewers")]
    public required IReadOnlyList<User> RequestedReviewers { get; init; }

    [JsonPropertyName("requested_teams")]
    public required IReadOnlyList<Team> RequestedTeams { get; init; }

    [JsonPropertyName("labels")]
    public required IReadOnlyList<Label> Labels { get; init; }

    [JsonPropertyName("milestone")]
    public Milestone? Milestone { get; init; }

    [JsonPropertyName("draft")]
    public bool Draft { get; init; }

    [JsonPropertyName("commits_url")]
    public required string CommitsUrl { get; init; }

    [JsonPropertyName("review_comments_url")]
    public required string ReviewCommentsUrl { get; init; }

    [JsonPropertyName("review_comment_url")]
    public required string ReviewCommentUrl { get; init; }

    [JsonPropertyName("comments_url")]
    public required string CommentsUrl { get; init; }

    [JsonPropertyName("statuses_url")]
    public required string StatusesUrl { get; init; }

    [JsonPropertyName("head")]
    public required SimplePullRequestHead Head { get; init; }

    [JsonPropertyName("base")]
    public required SimplePullRequestBase Base { get; init; }

    [JsonPropertyName("_links")]
    public SimplePullRequestLinks? Links { get; init; }

    [JsonPropertyName("author_association")]
    [JsonConverter(typeof(StringEnumConverter<AuthorAssociation>))]
    public required StringEnum<AuthorAssociation> AuthorAssociation { get; init; }

    [JsonPropertyName("auto_merge")]
    public PullRequestAutoMerge? AutoMerge { get; init; }

    [JsonPropertyName("active_lock_reason")]
    [JsonConverter(typeof(StringEnumConverter<ActiveLockReason>))]
    public StringEnum<ActiveLockReason>? ActiveLockReason { get; init; }
}
