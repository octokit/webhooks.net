namespace Octokit.Webhooks.Models;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
public sealed record Repository
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("full_name")]
    public string FullName { get; init; } = null!;

    [JsonPropertyName("private")]
    public bool Private { get; init; }

    [JsonPropertyName("owner")]
    public User Owner { get; init; } = null!;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("fork")]
    public bool Fork { get; init; }

    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("forks_url")]
    public string ForksUrl { get; init; } = null!;

    [JsonPropertyName("keys_url")]
    public string KeysUrl { get; init; } = null!;

    [JsonPropertyName("collaborators_url")]
    public string CollaboratorsUrl { get; init; } = null!;

    [JsonPropertyName("teams_url")]
    public string TeamsUrl { get; init; } = null!;

    [JsonPropertyName("hooks_url")]
    public string HooksUrl { get; init; } = null!;

    [JsonPropertyName("issue_events_url")]
    public string IssueEventsUrl { get; init; } = null!;

    [JsonPropertyName("events_url")]
    public string EventsUrl { get; init; } = null!;

    [JsonPropertyName("assignees_url")]
    public string AssigneesUrl { get; init; } = null!;

    [JsonPropertyName("branches_url")]
    public string BranchesUrl { get; init; } = null!;

    [JsonPropertyName("tags_url")]
    public string TagsUrl { get; init; } = null!;

    [JsonPropertyName("blobs_url")]
    public string BlobsUrl { get; init; } = null!;

    [JsonPropertyName("git_tags_url")]
    public string GitTagsUrl { get; init; } = null!;

    [JsonPropertyName("git_refs_url")]
    public string GitRefsUrl { get; init; } = null!;

    [JsonPropertyName("trees_url")]
    public string TreesUrl { get; init; } = null!;

    [JsonPropertyName("statuses_url")]
    public string StatusesUrl { get; init; } = null!;

    [JsonPropertyName("languages_url")]
    public string LanguagesUrl { get; init; } = null!;

    [JsonPropertyName("stargazers_url")]
    public string StargazersUrl { get; init; } = null!;

    [JsonPropertyName("contributors_url")]
    public string ContributorsUrl { get; init; } = null!;

    [JsonPropertyName("subscribers_url")]
    public string SubscribersUrl { get; init; } = null!;

    [JsonPropertyName("subscription_url")]
    public string SubscriptionUrl { get; init; } = null!;

    [JsonPropertyName("commits_url")]
    public string CommitsUrl { get; init; } = null!;

    [JsonPropertyName("git_commits_url")]
    public string GitCommitsUrl { get; init; } = null!;

    [JsonPropertyName("comments_url")]
    public string CommentsUrl { get; init; } = null!;

    [JsonPropertyName("issue_comment_url")]
    public string IssueCommentUrl { get; init; } = null!;

    [JsonPropertyName("contents_url")]
    public string ContentsUrl { get; init; } = null!;

    [JsonPropertyName("compare_url")]
    public string CompareUrl { get; init; } = null!;

    [JsonPropertyName("merges_url")]
    public string MergesUrl { get; init; } = null!;

    [JsonPropertyName("archive_url")]
    public string ArchiveUrl { get; init; } = null!;

    [JsonPropertyName("downloads_url")]
    public string DownloadsUrl { get; init; } = null!;

    [JsonPropertyName("issues_url")]
    public string IssuesUrl { get; init; } = null!;

    [JsonPropertyName("pulls_url")]
    public string PullsUrl { get; init; } = null!;

    [JsonPropertyName("milestones_url")]
    public string MilestonesUrl { get; init; } = null!;

    [JsonPropertyName("notifications_url")]
    public string NotificationsUrl { get; init; } = null!;

    [JsonPropertyName("labels_url")]
    public string LabelsUrl { get; init; } = null!;

    [JsonPropertyName("releases_url")]
    public string ReleasesUrl { get; init; } = null!;

    [JsonPropertyName("deployments_url")]
    public string DeploymentsUrl { get; init; } = null!;

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
    public string GitUrl { get; init; } = null!;

    [JsonPropertyName("ssh_url")]
    public string SshUrl { get; init; } = null!;

    [JsonPropertyName("clone_url")]
    public string CloneUrl { get; init; } = null!;

    [JsonPropertyName("svn_url")]
    public string SvnUrl { get; init; } = null!;

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
    public string DefaultBranch { get; init; } = null!;

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

    [JsonPropertyName("is_template")]
    public bool IsTemplate { get; init; }

    [JsonPropertyName("web_commit_signoff_required")]
    public bool WebCommitSignoffRequired { get; init; }

    [JsonPropertyName("topics")]
    public IEnumerable<string> Topics { get; init; } = null!;

    [JsonPropertyName("visibility")]
    public RepositoryVisibility Visibility { get; init; }

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
}
