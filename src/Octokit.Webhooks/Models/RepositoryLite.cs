namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record RepositoryLite
{
    [JsonPropertyName("archive_url")]
    public string ArchiveUrl { get; init; } = null!;

    [JsonPropertyName("assignees_url")]
    public string AssigneesUrl { get; init; } = null!;

    [JsonPropertyName("blobs_url")]
    public string BlobsUrl { get; init; } = null!;

    [JsonPropertyName("branches_url")]
    public string BranchesUrl { get; init; } = null!;

    [JsonPropertyName("collaborators_url")]
    public string CollaboratorsUrl { get; init; } = null!;

    [JsonPropertyName("comments_url")]
    public string CommentsUrl { get; init; } = null!;

    [JsonPropertyName("commits_url")]
    public string CommitsUrl { get; init; } = null!;

    [JsonPropertyName("compare_url")]
    public string CompareUrl { get; init; } = null!;

    [JsonPropertyName("contents_url")]
    public string ContentsUrl { get; init; } = null!;

    [JsonPropertyName("contributors_url")]
    public string ContributorsUrl { get; init; } = null!;

    [JsonPropertyName("deployments_url")]
    public string DeploymentsUrl { get; init; } = null!;

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("downloads_url")]
    public string DownloadsUrl { get; init; } = null!;

    [JsonPropertyName("events_url")]
    public string EventsUrl { get; init; } = null!;

    [JsonPropertyName("fork")]
    public bool Fork { get; init; }

    [JsonPropertyName("forks_url")]
    public string ForksUrl { get; init; } = null!;

    [JsonPropertyName("full_name")]
    public string FullName { get; init; } = null!;

    [JsonPropertyName("git_commits_url")]
    public string GitCommitsUrl { get; init; } = null!;

    [JsonPropertyName("git_refs_url")]
    public string GitRefsUrl { get; init; } = null!;

    [JsonPropertyName("git_tags_url")]
    public string GitTagsUrl { get; init; } = null!;

    [JsonPropertyName("hooks_url")]
    public string HooksUrl { get; init; } = null!;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("issue_comment_url")]
    public string IssueCommentUrl { get; init; } = null!;

    [JsonPropertyName("issue_events_url")]
    public string IssueEventsUrl { get; init; } = null!;

    [JsonPropertyName("issues_url")]
    public string IssuesUrl { get; init; } = null!;

    [JsonPropertyName("keys_url")]
    public string KeysUrl { get; init; } = null!;

    [JsonPropertyName("labels_url")]
    public string LabelsUrl { get; init; } = null!;

    [JsonPropertyName("languages_url")]
    public string LanguagesUrl { get; init; } = null!;

    [JsonPropertyName("merges_url")]
    public string MergesUrl { get; init; } = null!;

    [JsonPropertyName("milestones_url")]
    public string MilestonesUrl { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("notifications_url")]
    public string NotificationsUrl { get; init; } = null!;

    [JsonPropertyName("owner")]
    public User Owner { get; init; } = null!;

    [JsonPropertyName("private")]
    public bool Private { get; init; }

    [JsonPropertyName("pulls_url")]
    public string PullsUrl { get; init; } = null!;

    [JsonPropertyName("releases_url")]
    public string ReleasesUrl { get; init; } = null!;

    [JsonPropertyName("stargazers_url")]
    public string StargazersUrl { get; init; } = null!;

    [JsonPropertyName("statuses_url")]
    public string StatusesUrl { get; init; } = null!;

    [JsonPropertyName("subscribers_url")]
    public string SubscribersUrl { get; init; } = null!;

    [JsonPropertyName("subscription_url")]
    public string SubscriptionUrl { get; init; } = null!;

    [JsonPropertyName("tags_url")]
    public string TagsUrl { get; init; } = null!;

    [JsonPropertyName("teams_url")]
    public string TeamsUrl { get; init; } = null!;

    [JsonPropertyName("trees_url")]
    public string TreesUrl { get; init; } = null!;

    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;
}
