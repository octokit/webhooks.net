namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum AppEvent
{
    [EnumMember(Value = "*")]
    All,
    [EnumMember(Value = "branch_protection_rule")]
    BranchProtectionRule,
    [EnumMember(Value = "check_run")]
    CheckRun,
    [EnumMember(Value = "check_suite")]
    CheckSuite,
    [EnumMember(Value = "code_scanning_alert")]
    CodeScanningAlert,
    [EnumMember(Value = "commit_comment")]
    CommitComment,
    [EnumMember(Value = "content_reference")]
    ContentReference,
    [EnumMember(Value = "create")]
    Create,
    [EnumMember(Value = "delete")]
    Delete,
    [EnumMember(Value = "deploy_key")]
    DeployKey,
    [EnumMember(Value = "deployment")]
    Deployment,
    [EnumMember(Value = "deployment_review")]
    DeploymentReview,
    [EnumMember(Value = "deployment_status")]
    DeploymentStatus,
    [EnumMember(Value = "discussion")]
    Discussion,
    [EnumMember(Value = "discussion_comment")]
    DiscussionComment,
    [EnumMember(Value = "fork")]
    Fork,
    [EnumMember(Value = "gollum")]
    Gollum,
    [EnumMember(Value = "issue_comment")]
    IssueComment,
    [EnumMember(Value = "issues")]
    Issues,
    [EnumMember(Value = "label")]
    Label,
    [EnumMember(Value = "member")]
    Member,
    [EnumMember(Value = "membership")]
    Membership,
    [EnumMember(Value = "merge_group")]
    MergeGroup,
    [EnumMember(Value = "merge_queue_entry")]
    MergeQueueEntry,
    [EnumMember(Value = "meta")]
    Meta,
    [EnumMember(Value = "milestone")]
    Milestone,
    [EnumMember(Value = "org_block")]
    OrgBlock,
    [EnumMember(Value = "organization")]
    Organization,
    [EnumMember(Value = "page_build")]
    PageBuild,
    [EnumMember(Value = "project")]
    Project,
    [EnumMember(Value = "projects_v2_item")]
    ProjectsV2Item,
    [EnumMember(Value = "project_card")]
    ProjectCard,
    [EnumMember(Value = "project_column")]
    ProjectColumn,
    [EnumMember(Value = "public")]
    Public,
    [EnumMember(Value = "pull_request")]
    PullRequest,
    [EnumMember(Value = "pull_request_review")]
    PullRequestReview,
    [EnumMember(Value = "pull_request_review_comment")]
    PullRequestReviewComment,
    [EnumMember(Value = "pull_request_review_thread")]
    PullRequestReviewThread,
    [EnumMember(Value = "push")]
    Push,
    [EnumMember(Value = "registry_package")]
    RegistryPackage,
    [EnumMember(Value = "release")]
    Release,
    [EnumMember(Value = "repository")]
    Repository,
    [EnumMember(Value = "repository_dispatch")]
    RepositoryDispatch,
    [EnumMember(Value = "repository_import")]
    RepositoryImport,
    [EnumMember(Value = "repository_vulnerability_alert")]
    RepositoryVulnerabilityAlert,
    [EnumMember(Value = "secret_scanning_alert")]
    SecretScanningAlert,
    [EnumMember(Value = "secret_scanning_alert_location")]
    SecretScanningAlertLocation,
    [EnumMember(Value = "security_and_analysis")]
    SecurityAndAnalysis,
    [EnumMember(Value = "star")]
    Star,
    [EnumMember(Value = "status")]
    Status,
    [EnumMember(Value = "team")]
    Team,
    [EnumMember(Value = "team_add")]
    TeamAdd,
    [EnumMember(Value = "watch")]
    Watch,
    [EnumMember(Value = "workflow_dispatch")]
    WorkflowDispatch,
    [EnumMember(Value = "workflow_job")]
    WorkflowJob,
    [EnumMember(Value = "workflow_run")]
    WorkflowRun,
}
