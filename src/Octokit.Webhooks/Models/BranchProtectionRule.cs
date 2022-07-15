namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record BranchProtectionRule
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("repository_id")]
    public long RepositoryId { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("admin_enforced")]
    public bool AdminEnforced { get; init; }

    [JsonPropertyName("create_protected")]
    public bool? CreateProtected { get; init; }

    [JsonPropertyName("allow_deletions_enforcement_level")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public StringEnum<EnforcementLevel> AllowDeletionsEnforcementLevel { get; init; } = null!;

    [JsonPropertyName("allow_force_pushes_enforcement_level")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public StringEnum<EnforcementLevel> AllowForcePushesEnforcementLevel { get; init; } = null!;

    [JsonPropertyName("authorized_actor_names")]
    public IEnumerable<string> AuthorizedActorNames { get; init; } = null!;

    [JsonPropertyName("authorized_actors_only")]
    public bool AuthorizedActorsOnly { get; init; }

    [JsonPropertyName("authorized_dismissal_actors_only")]
    public bool AuthorizedDismissalActorsOnly { get; init; }

    [JsonPropertyName("dismiss_stale_reviews_on_push")]
    public bool DismissStaleReviewsOnPush { get; init; }

    [JsonPropertyName("ignore_approvals_from_contributors")]
    public bool IgnoreApprovalsFromContributors { get; init; }

    [JsonPropertyName("linear_history_requirement_enforcement_level")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public StringEnum<EnforcementLevel> LinearHistoryRequirementEnforcementLevel { get; init; } = null!;

    [JsonPropertyName("merge_queue_enforcement_level")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public StringEnum<EnforcementLevel> MergeQueueEnforcementLevel { get; init; } = null!;

    [JsonPropertyName("pull_request_reviews_enforcement_level")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public StringEnum<EnforcementLevel> PullRequestReviewsEnforcementLevel { get; init; } = null!;

    [JsonPropertyName("require_code_owner_review")]
    public bool RequireCodeOwnerReview { get; init; }

    [JsonPropertyName("require_last_push_approval")]
    public bool RequireLastPushApproval { get; init; }

    [JsonPropertyName("required_approving_review_count")]
    public long RequiredApprovingReviewCount { get; init; }

    [JsonPropertyName("required_conversation_resolution_level")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public StringEnum<EnforcementLevel> RequiredConversationResolutionLevel { get; init; } = null!;

    [JsonPropertyName("required_deployments_enforcement_level")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public StringEnum<EnforcementLevel> RequiredDeploymentsEnforcementLevel { get; init; } = null!;

    [JsonPropertyName("required_status_checks")]
    public IEnumerable<string> RequiredStatusChecks { get; init; } = null!;

    [JsonPropertyName("required_status_checks_enforcement_level")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public StringEnum<EnforcementLevel> RequiredStatusChecksEnforcementLevel { get; init; } = null!;

    [JsonPropertyName("signature_requirement_enforcement_level")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public StringEnum<EnforcementLevel> SignatureRequirementEnforcementLevel { get; init; } = null!;

    [JsonPropertyName("strict_required_status_checks_policy")]
    public bool StrictRequiredStatusChecksPolicy { get; init; }
}
