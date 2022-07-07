namespace Octokit.Webhooks.Models;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
public sealed record SimplePullRequest
{
    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("diff_url")]
    public string DiffUrl { get; init; } = null!;

    [JsonPropertyName("patch_url")]
    public string PatchUrl { get; init; } = null!;

    [JsonPropertyName("issue_url")]
    public string IssueUrl { get; init; } = null!;

    [JsonPropertyName("number")]
    public long Number { get; init; }

    [JsonPropertyName("state")]
    public SimplePullRequestState State { get; init; }

    [JsonPropertyName("locked")]
    public bool Locked { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; } = null!;

    [JsonPropertyName("user")]
    public User User { get; init; } = null!;

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
    public IEnumerable<User> Assignees { get; init; } = null!;

    [JsonPropertyName("requested_reviewers")]
    public IEnumerable<User> RequestedReviewers { get; init; } = null!;

    [JsonPropertyName("requested_teams")]
    public IEnumerable<Team> RequestedTeams { get; init; } = null!;

    [JsonPropertyName("labels")]
    public IEnumerable<Label> Labels { get; init; } = null!;

    [JsonPropertyName("milestone")]
    public Milestone? Milestone { get; init; }

    [JsonPropertyName("draft")]
    public bool Draft { get; init; }

    [JsonPropertyName("commits_url")]
    public string CommitsUrl { get; init; } = null!;

    [JsonPropertyName("review_comments_url")]
    public string ReviewCommentsUrl { get; init; } = null!;

    [JsonPropertyName("review_comment_url")]
    public string ReviewCommentUrl { get; init; } = null!;

    [JsonPropertyName("comments_url")]
    public string CommentsUrl { get; init; } = null!;

    [JsonPropertyName("statuses_url")]
    public string StatusesUrl { get; init; } = null!;

    [JsonPropertyName("head")]
    public SimplePullRequestHead Head { get; init; } = null!;

    [JsonPropertyName("base")]
    public SimplePullRequestBase Base { get; init; } = null!;

    [JsonPropertyName("_links")]
    public SimplePullRequestLinks? Links { get; init; }

    [JsonPropertyName("author_association")]
    public AuthorAssociation AuthorAssociation { get; init; }

    [JsonPropertyName("auto_merge")]
    public PullRequestAutoMerge? AutoMerge { get; init; }

    [JsonPropertyName("active_lock_reason")]
    public ActiveLockReason? ActiveLockReason { get; init; }
}
