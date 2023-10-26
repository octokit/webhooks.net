namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record Rule
{
    [JsonPropertyName("creation")]
    public Creation? Creation { get; init; }

    [JsonPropertyName("update")]
    public Update? Update { get; init; }

    [JsonPropertyName("deletion")]
    public Deletion? Deletion { get; init; }

    [JsonPropertyName("required_linear_history")]
    public RequiredLinearHistory? RequiredLinearHistory { get; init; }

    [JsonPropertyName("required_deployments")]
    public RequiredDeployments? RequiredDeployments { get; init; }

    [JsonPropertyName("required_signatures")]
    public RequiredSignatures? RequiredSignatures { get; init; }

    [JsonPropertyName("pull_request")]
    public PullRequest? PullRequest { get; init; }

    [JsonPropertyName("required_status_checks")]
    public RequiredStatusChecks? RequiredStatusChecks { get; init; }

    [JsonPropertyName("non_fast_forward")]
    public NonFastForward? NonFastForward { get; init; }

    [JsonPropertyName("commit_message_pattern ")]
    public Pattern? CommitMessagePattern { get; init; }

    [JsonPropertyName("commit_author_email_pattern ")]
    public Pattern? CommitAuthorEmailPattern { get; init; }

    [JsonPropertyName("committer_email_pattern")]
    public Pattern? CommitterEmailPattern { get; init; }

    [JsonPropertyName("branch_name_pattern")]
    public Pattern? BranchNamePattern { get; init; }

    [JsonPropertyName("tag_name_pattern")]
    public Pattern? TagNamePattern { get; init; }

    [JsonPropertyName("workflows")]
    public Workflows? Workflows { get; init; }
}
