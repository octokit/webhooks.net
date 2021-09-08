namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class Repository
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("node_id")] public string NodeId { get; set; } = null!;

        [JsonPropertyName("name")] public string Name { get; set; } = null!;

        [JsonPropertyName("full_name")] public string FullName { get; set; } = null!;

        [JsonPropertyName("private")] public bool Private { get; set; }

        [JsonPropertyName("owner")] public User Owner { get; set; } = null!;

        [JsonPropertyName("html_url")] public string HtmlUrl { get; set; } = null!;

        [JsonPropertyName("description")] public string? Description { get; set; }

        [JsonPropertyName("fork")] public bool Fork { get; set; }

        [JsonPropertyName("url")] public string Url { get; set; } = null!;

        [JsonPropertyName("forks_url")] public string ForksUrl { get; set; } = null!;

        [JsonPropertyName("keys_url")] public string KeysUrl { get; set; } = null!;

        [JsonPropertyName("collaborators_url")]
        public string CollaboratorsUrl { get; set; } = null!;

        [JsonPropertyName("teams_url")] public string TeamsUrl { get; set; } = null!;

        [JsonPropertyName("hooks_url")] public string HooksUrl { get; set; } = null!;

        [JsonPropertyName("issue_events_url")] public string IssueEventsUrl { get; set; } = null!;

        [JsonPropertyName("events_url")] public string EventsUrl { get; set; } = null!;

        [JsonPropertyName("assignees_url")] public string AssigneesUrl { get; set; } = null!;

        [JsonPropertyName("branches_url")] public string BranchesUrl { get; set; } = null!;

        [JsonPropertyName("tags_url")] public string TagsUrl { get; set; } = null!;

        [JsonPropertyName("blobs_url")] public string BlobsUrl { get; set; } = null!;

        [JsonPropertyName("git_tags_url")] public string GitTagsUrl { get; set; } = null!;

        [JsonPropertyName("git_refs_url")] public string GitRefsUrl { get; set; } = null!;

        [JsonPropertyName("trees_url")] public string TreesUrl { get; set; } = null!;

        [JsonPropertyName("statuses_url")] public string StatusesUrl { get; set; } = null!;

        [JsonPropertyName("languages_url")] public string LanguagesUrl { get; set; } = null!;

        [JsonPropertyName("stargazers_url")] public string StargazersUrl { get; set; } = null!;

        [JsonPropertyName("contributors_url")] public string ContributorsUrl { get; set; } = null!;

        [JsonPropertyName("subscribers_url")] public string SubscribersUrl { get; set; } = null!;

        [JsonPropertyName("subscription_url")] public string SubscriptionUrl { get; set; } = null!;

        [JsonPropertyName("commits_url")] public string CommitsUrl { get; set; } = null!;

        [JsonPropertyName("git_commits_url")] public string GitCommitsUrl { get; set; } = null!;

        [JsonPropertyName("comments_url")] public string CommentsUrl { get; set; } = null!;

        [JsonPropertyName("issue_comment_url")]
        public string IssueCommentUrl { get; set; } = null!;

        [JsonPropertyName("contents_url")] public string ContentsUrl { get; set; } = null!;

        [JsonPropertyName("compare_url")] public string CompareUrl { get; set; } = null!;

        [JsonPropertyName("merges_url")] public string MergesUrl { get; set; } = null!;

        [JsonPropertyName("archive_url")] public string ArchiveUrl { get; set; } = null!;

        [JsonPropertyName("downloads_url")] public string DownloadsUrl { get; set; } = null!;

        [JsonPropertyName("issues_url")] public string IssuesUrl { get; set; } = null!;

        [JsonPropertyName("pulls_url")] public string PullsUrl { get; set; } = null!;

        [JsonPropertyName("milestones_url")] public string MilestonesUrl { get; set; } = null!;

        [JsonPropertyName("notifications_url")]
        public string NotificationsUrl { get; set; } = null!;

        [JsonPropertyName("labels_url")] public string LabelsUrl { get; set; } = null!;

        [JsonPropertyName("releases_url")] public string ReleasesUrl { get; set; } = null!;

        [JsonPropertyName("deployments_url")] public string DeploymentsUrl { get; set; } = null!;

        [JsonPropertyName("created_at")] public string? CreatedAt { get; set; }

        [JsonPropertyName("updated_at")] public string UpdatedAt { get; set; } = null!;

        [JsonPropertyName("pushed_at")] public string? PushedAt { get; set; }

        [JsonPropertyName("git_url")] public string GitUrl { get; set; } = null!;

        [JsonPropertyName("ssh_url")] public string SshUrl { get; set; } = null!;

        [JsonPropertyName("clone_url")] public string CloneUrl { get; set; } = null!;

        [JsonPropertyName("svn_url")] public string SvnUrl { get; set; } = null!;

        [JsonPropertyName("homepage")] public string? Homepage { get; set; }

        [JsonPropertyName("size")] public int Size { get; set; }

        [JsonPropertyName("stargazers_count")] public int StargazersCount { get; set; }

        [JsonPropertyName("watchers_count")] public int WatchersCount { get; set; }

        [JsonPropertyName("language")] public string? Language { get; set; }

        [JsonPropertyName("has_issues")] public bool HasIssues { get; set; }

        [JsonPropertyName("has_projects")] public bool HasProjects { get; set; }

        [JsonPropertyName("has_downloads")] public bool HasDownloads { get; set; }

        [JsonPropertyName("has_wiki")] public bool HasWiki { get; set; }

        [JsonPropertyName("has_pages")] public bool HasPages { get; set; }

        [JsonPropertyName("forks_count")] public int ForksCount { get; set; }

        [JsonPropertyName("mirror_url")] public string? MirrorUrl { get; set; }

        [JsonPropertyName("archived")] public bool Archived { get; set; }

        [JsonPropertyName("disabled")] public bool? Disabled { get; set; }

        [JsonPropertyName("open_issues_count")]
        public int OpenIssuesCount { get; set; }

        [JsonPropertyName("license")] public License? License { get; set; }

        [JsonPropertyName("forks")] public int Forks { get; set; }

        [JsonPropertyName("open_issues")] public int OpenIssues { get; set; }

        [JsonPropertyName("watchers")] public int Watchers { get; set; }

        [JsonPropertyName("stargazers")] public int? Stargazers { get; set; }

        [JsonPropertyName("default_branch")] public string DefaultBranch { get; set; } = null!;

        [JsonPropertyName("allow_squash_merge")]
        public bool? AllowSquashMerge { get; set; }

        [JsonPropertyName("allow_merge_commit")]
        public bool? AllowMergeCommit { get; set; }

        [JsonPropertyName("allow_rebase_merge")]
        public bool? AllowRebaseMerge { get; set; }

        [JsonPropertyName("delete_branch_on_merge")]
        public bool? DeleteBranchOnMerge { get; set; }

        [JsonPropertyName("master_branch")] public string? MasterBranch { get; set; }

        [JsonPropertyName("permissions")] public RepositoryPermissions Permissions { get; set; } = null!;

        [JsonPropertyName("public")] public bool? Public { get; set; }

        [JsonPropertyName("organization")] public string Organization { get; set; } = null!;
    }
}
