namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class PullRequest
    {
        [JsonPropertyName("body")] public string? Body;

        [JsonPropertyName("url")] public string Url { get; set; } = null!;

        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("node_id")] public string NodeId { get; set; } = null!;

        [JsonPropertyName("html_url")] public string HtmlUrl { get; set; } = null!;

        [JsonPropertyName("diff_url")] public string DiffUrl { get; set; } = null!;

        [JsonPropertyName("patch_url")] public string PatchUrl { get; set; } = null!;

        [JsonPropertyName("issue_url")] public string IssueUrl { get; set; } = null!;

        [JsonPropertyName("number")] public int Number { get; set; }

        [JsonPropertyName("state")] public PullRequestState State { get; set; }

        [JsonPropertyName("locked")] public bool Locked { get; set; }

        [JsonPropertyName("title")] public string Title { get; set; } = null!;

        [JsonPropertyName("user")] public User User { get; set; } = null!;

        [JsonPropertyName("created_at")] public string CreatedAt { get; set; } = null!;

        [JsonPropertyName("updated_at")] public string UpdatedAt { get; set; } = null!;

        [JsonPropertyName("closed_at")] public string? ClosedAt { get; set; }

        [JsonPropertyName("merged_at")] public string? MergedAt { get; set; }

        [JsonPropertyName("merge_commit_sha")] public string? MergeCommitSha { get; set; }

        [JsonPropertyName("assignee")] public User? Assignee { get; set; }

        [JsonPropertyName("assignees")] public IEnumerable<User> Assignees { get; set; } = null!;

        // requested_reviewers: (User | Team)[];

        [JsonPropertyName("requested_teams")] public IEnumerable<Team> RequestedTeams { get; set; } = null!;

        [JsonPropertyName("labels")] public IEnumerable<Label> Labels { get; set; } = null!;

        [JsonPropertyName("milestone")] public Milestone? Milestone { get; set; }

        [JsonPropertyName("commits_url")] public string CommitsUrl { get; set; } = null!;

        [JsonPropertyName("review_comments_url")]
        public string ReviewCommentsUrl { get; set; } = null!;

        [JsonPropertyName("review_comment_url")]
        public string ReviewCommentUrl { get; set; } = null!;

        [JsonPropertyName("comments_url")] public string CommentsUrl { get; set; } = null!;

        [JsonPropertyName("statuses_url")] public string StatusesUrl { get; set; } = null!;

        [JsonPropertyName("head")] public PullRequestHead Head { get; set; } = null!;

        [JsonPropertyName("base")] public PullRequestBase Base { get; set; } = null!;

        [JsonPropertyName("_links")] public PullRequestLinks Links { get; set; } = null!;

        [JsonPropertyName("author_association")]
        public AuthorAssociation AuthorAssociation { get; set; }

        [JsonPropertyName("auto_merge")] public bool? AutoMerge { get; set; }

        [JsonPropertyName("active_lock_reason")]
        public PullRequestActiveLockReason? ActiveLockReason { get; set; }

        [JsonPropertyName("draft")] public bool Draft { get; set; }

        [JsonPropertyName("merged")] public bool? Merged { get; set; }

        [JsonPropertyName("mergeable")] public bool? Mergeable { get; set; }

        [JsonPropertyName("rebaseable")] public bool? Rebaseable { get; set; }

        [JsonPropertyName("mergeable_state")] public string MergeableState { get; set; } = null!;

        [JsonPropertyName("merged_by")] public User? MergedBy { get; set; }

        [JsonPropertyName("comments")] public int Comments { get; set; }

        [JsonPropertyName("review_comments")] public int ReviewComments { get; set; }

        [JsonPropertyName("maintainer_can_modify")]
        public bool MaintainerCanModify { get; set; }

        [JsonPropertyName("commits")] public int Commits { get; set; }

        [JsonPropertyName("additions")] public int Additions { get; set; }

        [JsonPropertyName("deletions")] public int Deletions { get; set; }

        [JsonPropertyName("changed_files")] public int ChangedFiles { get; set; }
    }
}
