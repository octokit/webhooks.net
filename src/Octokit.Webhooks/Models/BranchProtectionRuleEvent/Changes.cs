namespace Octokit.Webhooks.Models.BranchProtectionRuleEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("admin_enforced")]
    public ChangesBoolean? AdminEnforced { get; init; }

    [JsonPropertyName("allow_deletions_enforcement_level")]
    public ChangesEnforcementLevel? AllowDeletionsEnforcementLevel { get; init; }

    [JsonPropertyName("allow_force_pushes_enforcement_level")]
    public ChangesEnforcementLevel? AllowForcePushesEnforcementLevel { get; init; }

    [JsonPropertyName("authorized_actors_only")]
    public ChangesBoolean? AuthorizedActorsOnly { get; init; }

    [JsonPropertyName("authorized_actor_names")]
    public ChangesArray? AuthorizedActorNames { get; init; }

    [JsonPropertyName("authorized_dismissal_actors_only")]
    public ChangesBoolean? AuthorizedDismissalActorsOnly { get; init; }

    [JsonPropertyName("dismiss_stale_reviews_on_push")]
    public ChangesBoolean? DismissStaleReviewsOnPush { get; init; }

    [JsonPropertyName("pull_request_reviews_enforcement_level")]
    public ChangesEnforcementLevel? PullRequestReviewsEnforcementLevel { get; init; }

    [JsonPropertyName("require_code_owner_review")]
    public ChangesBoolean? RequireCodeOwnerReview { get; init; }

    [JsonPropertyName("required_approving_review_count")]
    public ChangesInteger? RequiredApprovingReviewCount { get; init; }

    [JsonPropertyName("required_conversation_resolution_level")]
    public ChangesEnforcementLevel? RequiredConversationResolutionLevel { get; init; }

    [JsonPropertyName("required_status_checks")]
    public ChangesArray? RequiredStatusChecks { get; init; }

    [JsonPropertyName("required_status_checks_enforcement_level")]
    public ChangesEnforcementLevel? RequiredStatusChecksEnforcementLevel { get; init; }

    [JsonPropertyName("signature_requirement_enforcement_level")]
    public ChangesEnforcementLevel? SignatureRequirementEnforcementLevel { get; init; }

    [JsonPropertyName("linear_history_requirement_enforcement_level")]
    public ChangesEnforcementLevel? LinearHistoryRequirementEnforcementLevel { get; init; }
}
