namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record BranchProtectionRule
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("repository_id")]
    public long RepositoryId { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

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
    public required StringEnum<EnforcementLevel> AllowDeletionsEnforcementLevel { get; init; }

    [JsonPropertyName("allow_force_pushes_enforcement_level")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public required StringEnum<EnforcementLevel> AllowForcePushesEnforcementLevel { get; init; }

    [JsonPropertyName("authorized_actor_names")]
    public required IReadOnlyList<string> AuthorizedActorNames { get; init; }

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
    public required StringEnum<EnforcementLevel> LinearHistoryRequirementEnforcementLevel { get; init; }

    [JsonPropertyName("merge_queue_enforcement_level")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public required StringEnum<EnforcementLevel> MergeQueueEnforcementLevel { get; init; }

    [JsonPropertyName("pull_request_reviews_enforcement_level")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public required StringEnum<EnforcementLevel> PullRequestReviewsEnforcementLevel { get; init; }

    [JsonPropertyName("require_code_owner_review")]
    public bool RequireCodeOwnerReview { get; init; }

    [JsonPropertyName("require_last_push_approval")]
    public bool RequireLastPushApproval { get; init; }

    [JsonPropertyName("required_approving_review_count")]
    public long RequiredApprovingReviewCount { get; init; }

    [JsonPropertyName("required_conversation_resolution_level")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public required StringEnum<EnforcementLevel> RequiredConversationResolutionLevel { get; init; }

    [JsonPropertyName("required_deployments_enforcement_level")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public required StringEnum<EnforcementLevel> RequiredDeploymentsEnforcementLevel { get; init; }

    [JsonPropertyName("required_status_checks")]
    public required IReadOnlyList<string> RequiredStatusChecks { get; init; }

    [JsonPropertyName("required_status_checks_enforcement_level")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public required StringEnum<EnforcementLevel> RequiredStatusChecksEnforcementLevel { get; init; }

    [JsonPropertyName("signature_requirement_enforcement_level")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public required StringEnum<EnforcementLevel> SignatureRequirementEnforcementLevel { get; init; }

    [JsonPropertyName("strict_required_status_checks_policy")]
    public bool StrictRequiredStatusChecksPolicy { get; init; }
}
