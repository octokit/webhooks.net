namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record Repository
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("full_name")]
    public required string FullName { get; init; }

    [JsonPropertyName("private")]
    public bool Private { get; init; }

    [JsonPropertyName("owner")]
    public required User Owner { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("fork")]
    public bool Fork { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("forks_url")]
    public string? ForksUrl { get; init; }

    [JsonPropertyName("keys_url")]
    public string? KeysUrl { get; init; }

    [JsonPropertyName("collaborators_url")]
    public string? CollaboratorsUrl { get; init; }

    [JsonPropertyName("teams_url")]
    public string? TeamsUrl { get; init; }

    [JsonPropertyName("hooks_url")]
    public string? HooksUrl { get; init; }

    [JsonPropertyName("issue_events_url")]
    public string? IssueEventsUrl { get; init; }

    [JsonPropertyName("events_url")]
    public string? EventsUrl { get; init; }

    [JsonPropertyName("assignees_url")]
    public string? AssigneesUrl { get; init; }

    [JsonPropertyName("branches_url")]
    public string? BranchesUrl { get; init; }

    [JsonPropertyName("tags_url")]
    public string? TagsUrl { get; init; }

    [JsonPropertyName("blobs_url")]
    public string? BlobsUrl { get; init; }

    [JsonPropertyName("git_tags_url")]
    public string? GitTagsUrl { get; init; }

    [JsonPropertyName("git_refs_url")]
    public string? GitRefsUrl { get; init; }

    [JsonPropertyName("trees_url")]
    public string? TreesUrl { get; init; }

    [JsonPropertyName("statuses_url")]
    public string? StatusesUrl { get; init; }

    [JsonPropertyName("languages_url")]
    public string? LanguagesUrl { get; init; }

    [JsonPropertyName("stargazers_url")]
    public string? StargazersUrl { get; init; }

    [JsonPropertyName("contributors_url")]
    public string? ContributorsUrl { get; init; }

    [JsonPropertyName("subscribers_url")]
    public string? SubscribersUrl { get; init; }

    [JsonPropertyName("subscription_url")]
    public string? SubscriptionUrl { get; init; }

    [JsonPropertyName("commits_url")]
    public string? CommitsUrl { get; init; }

    [JsonPropertyName("git_commits_url")]
    public string? GitCommitsUrl { get; init; }

    [JsonPropertyName("comments_url")]
    public string? CommentsUrl { get; init; }

    [JsonPropertyName("issue_comment_url")]
    public string? IssueCommentUrl { get; init; }

    [JsonPropertyName("contents_url")]
    public string? ContentsUrl { get; init; }

    [JsonPropertyName("compare_url")]
    public string? CompareUrl { get; init; }

    [JsonPropertyName("merges_url")]
    public string? MergesUrl { get; init; }

    [JsonPropertyName("archive_url")]
    public string? ArchiveUrl { get; init; }

    [JsonPropertyName("downloads_url")]
    public string? DownloadsUrl { get; init; }

    [JsonPropertyName("issues_url")]
    public string? IssuesUrl { get; init; }

    [JsonPropertyName("pulls_url")]
    public string? PullsUrl { get; init; }

    [JsonPropertyName("milestones_url")]
    public string? MilestonesUrl { get; init; }

    [JsonPropertyName("notifications_url")]
    public string? NotificationsUrl { get; init; }

    [JsonPropertyName("labels_url")]
    public string? LabelsUrl { get; init; }

    [JsonPropertyName("releases_url")]
    public string? ReleasesUrl { get; init; }

    [JsonPropertyName("deployments_url")]
    public string? DeploymentsUrl { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("pushed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? PushedAt { get; init; }

    [JsonPropertyName("git_url")]
    public string? GitUrl { get; init; }

    [JsonPropertyName("ssh_url")]
    public string? SshUrl { get; init; }

    [JsonPropertyName("clone_url")]
    public string? CloneUrl { get; init; }

    [JsonPropertyName("svn_url")]
    public string? SvnUrl { get; init; }

    [JsonPropertyName("homepage")]
    public string? Homepage { get; init; }

    [JsonPropertyName("size")]
    public long Size { get; init; }

    [JsonPropertyName("stargazers_count")]
    public long StargazersCount { get; init; }

    [JsonPropertyName("watchers_count")]
    public long WatchersCount { get; init; }

    [JsonPropertyName("language")]
    public string? Language { get; init; }

    [JsonPropertyName("has_issues")]
    public bool HasIssues { get; init; }

    [JsonPropertyName("has_projects")]
    public bool HasProjects { get; init; }

    [JsonPropertyName("has_downloads")]
    public bool HasDownloads { get; init; }

    [JsonPropertyName("has_wiki")]
    public bool HasWiki { get; init; }

    [JsonPropertyName("has_pages")]
    public bool HasPages { get; init; }

    [JsonPropertyName("has_discussions")]
    public bool? HasDiscussions { get; init; }

    [JsonPropertyName("forks_count")]
    public long ForksCount { get; init; }

    [JsonPropertyName("mirror_url")]
    public string? MirrorUrl { get; init; }

    [JsonPropertyName("archived")]
    public bool Archived { get; init; }

    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }

    [JsonPropertyName("open_issues_count")]
    public long OpenIssuesCount { get; init; }

    [JsonPropertyName("license")]
    public License? License { get; init; }

    [JsonPropertyName("forks")]
    public long Forks { get; init; }

    [JsonPropertyName("open_issues")]
    public long OpenIssues { get; init; }

    [JsonPropertyName("watchers")]
    public long Watchers { get; init; }

    [JsonPropertyName("stargazers")]
    public int? Stargazers { get; init; }

    [JsonPropertyName("default_branch")]
    public string? DefaultBranch { get; init; }

    [JsonPropertyName("allow_squash_merge")]
    public bool? AllowSquashMerge { get; init; }

    [JsonPropertyName("allow_merge_commit")]
    public bool? AllowMergeCommit { get; init; }

    [JsonPropertyName("allow_rebase_merge")]
    public bool? AllowRebaseMerge { get; init; }

    [JsonPropertyName("allow_auto_merge")]
    public bool? AllowAutoMerge { get; init; }

    [JsonPropertyName("allow_forking")]
    public bool? AllowForking { get; init; }

    [JsonPropertyName("allow_update_branch")]
    public bool? AllowUpdateBranch { get; init; }

    [JsonPropertyName("use_squash_pr_title_as_default")]
    public bool? UseSquashPrTitleAsDefault { get; init; }

    [JsonPropertyName("squash_merge_commit_message")]
    public string? SquashMergeCommitMessage { get; init; }

    [JsonPropertyName("squash_merge_commit_title")]
    public string? SquashMergeCommitTitle { get; init; }

    [JsonPropertyName("merge_commit_message")]
    public string? MergeCommitMessage { get; init; }

    [JsonPropertyName("merge_commit_title")]
    public string? MergeCommitTitle { get; init; }

    [JsonPropertyName("is_template")]
    public bool IsTemplate { get; init; }

    [JsonPropertyName("web_commit_signoff_required")]
    public bool WebCommitSignoffRequired { get; init; }

    [JsonPropertyName("topics")]
    public IReadOnlyList<string>? Topics { get; init; }

    [JsonPropertyName("visibility")]
    [JsonConverter(typeof(StringEnumConverter<RepositoryVisibility>))]
    public StringEnum<RepositoryVisibility>? Visibility { get; init; }

    [JsonPropertyName("delete_branch_on_merge")]
    public bool? DeleteBranchOnMerge { get; init; }

    [JsonPropertyName("master_branch")]
    public string? MasterBranch { get; init; }

    [JsonPropertyName("permissions")]
    public RepositoryPermissions? Permissions { get; init; }

    [JsonPropertyName("public")]
    public bool? Public { get; init; }

    [JsonPropertyName("organization")]
    public string? Organization { get; init; }

    [JsonPropertyName("custom_properties")]
    public IDictionary<string, object>? CustomProperties { get; init; }
}
