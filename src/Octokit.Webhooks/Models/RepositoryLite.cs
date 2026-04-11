namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record RepositoryLite
{
    [JsonPropertyName("archive_url")]
    public required string ArchiveUrl { get; init; }

    [JsonPropertyName("assignees_url")]
    public required string AssigneesUrl { get; init; }

    [JsonPropertyName("blobs_url")]
    public required string BlobsUrl { get; init; }

    [JsonPropertyName("branches_url")]
    public required string BranchesUrl { get; init; }

    [JsonPropertyName("collaborators_url")]
    public required string CollaboratorsUrl { get; init; }

    [JsonPropertyName("comments_url")]
    public required string CommentsUrl { get; init; }

    [JsonPropertyName("commits_url")]
    public required string CommitsUrl { get; init; }

    [JsonPropertyName("compare_url")]
    public required string CompareUrl { get; init; }

    [JsonPropertyName("contents_url")]
    public required string ContentsUrl { get; init; }

    [JsonPropertyName("contributors_url")]
    public required string ContributorsUrl { get; init; }

    [JsonPropertyName("deployments_url")]
    public required string DeploymentsUrl { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("downloads_url")]
    public required string DownloadsUrl { get; init; }

    [JsonPropertyName("events_url")]
    public required string EventsUrl { get; init; }

    [JsonPropertyName("fork")]
    public bool Fork { get; init; }

    [JsonPropertyName("forks_url")]
    public required string ForksUrl { get; init; }

    [JsonPropertyName("full_name")]
    public required string FullName { get; init; }

    [JsonPropertyName("git_commits_url")]
    public required string GitCommitsUrl { get; init; }

    [JsonPropertyName("git_refs_url")]
    public required string GitRefsUrl { get; init; }

    [JsonPropertyName("git_tags_url")]
    public required string GitTagsUrl { get; init; }

    [JsonPropertyName("hooks_url")]
    public required string HooksUrl { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("issue_comment_url")]
    public required string IssueCommentUrl { get; init; }

    [JsonPropertyName("issue_events_url")]
    public required string IssueEventsUrl { get; init; }

    [JsonPropertyName("issues_url")]
    public required string IssuesUrl { get; init; }

    [JsonPropertyName("keys_url")]
    public required string KeysUrl { get; init; }

    [JsonPropertyName("labels_url")]
    public required string LabelsUrl { get; init; }

    [JsonPropertyName("languages_url")]
    public required string LanguagesUrl { get; init; }

    [JsonPropertyName("merges_url")]
    public required string MergesUrl { get; init; }

    [JsonPropertyName("milestones_url")]
    public required string MilestonesUrl { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("notifications_url")]
    public required string NotificationsUrl { get; init; }

    [JsonPropertyName("owner")]
    public required User Owner { get; init; }

    [JsonPropertyName("private")]
    public bool Private { get; init; }

    [JsonPropertyName("pulls_url")]
    public required string PullsUrl { get; init; }

    [JsonPropertyName("releases_url")]
    public required string ReleasesUrl { get; init; }

    [JsonPropertyName("stargazers_url")]
    public required string StargazersUrl { get; init; }

    [JsonPropertyName("statuses_url")]
    public required string StatusesUrl { get; init; }

    [JsonPropertyName("subscribers_url")]
    public required string SubscribersUrl { get; init; }

    [JsonPropertyName("subscription_url")]
    public required string SubscriptionUrl { get; init; }

    [JsonPropertyName("tags_url")]
    public required string TagsUrl { get; init; }

    [JsonPropertyName("teams_url")]
    public required string TeamsUrl { get; init; }

    [JsonPropertyName("trees_url")]
    public required string TreesUrl { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }
}
