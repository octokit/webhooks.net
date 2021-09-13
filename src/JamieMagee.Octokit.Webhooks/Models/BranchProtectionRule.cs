namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public sealed record BranchProtectionRule
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("repository_id")]
        public int RepositoryId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonPropertyName("admin_enforced")]
        public bool AdminEnforced { get; set; }

        [JsonPropertyName("allow_deletions_enforcement_level")]
        public EnforcementLevel AllowDeletionsEnforcementLevel { get; set; }

        [JsonPropertyName("allow_force_pushes_enforcement_level")]
        public EnforcementLevel AllowForcePushesEnforcementLevel { get; set; }

        [JsonPropertyName("authorized_actor_names")]
        public IEnumerable<string> AuthorizedActorNames { get; set; } = null!;

        [JsonPropertyName("authorized_actors_only")]
        public bool AuthorizedActorsOnly { get; set; }

        [JsonPropertyName("authorized_dismissal_actors_only")]
        public bool AuthorizedDismissalActorsOnly { get; set; }

        [JsonPropertyName("dismiss_stale_reviews_on_push")]
        public bool DismissStaleReviewsOnPush { get; set; }

        [JsonPropertyName("ignore_approvals_from_contributors")]
        public bool IgnoreApprovalsFromContributors { get; set; }

        [JsonPropertyName("linear_history_requirement_enforcement_level")]
        public EnforcementLevel LinearHistoryRequirementEnforcementLevel { get; set; }

        [JsonPropertyName("merge_queue_enforcement_level")]
        public EnforcementLevel MergeQueueEnforcementLevel { get; set; }

        [JsonPropertyName("pull_request_reviews_enforcement_level")]
        public EnforcementLevel PullRequestReviewsEnforcementLevel { get; set; }

        [JsonPropertyName("require_code_owner_review")]
        public bool RequireCodeOwnerReview { get; set; }

        [JsonPropertyName("required_approving_review_count")]
        public int RequiredApprovingReviewCount { get; set; }

        [JsonPropertyName("required_conversation_resolution_level")]
        public EnforcementLevel RequiredConversationResolutionLevel { get; set; }

        [JsonPropertyName("required_deployments_enforcement_level")]
        public EnforcementLevel RequiredDeploymentsEnforcementLevel { get; set; }

        [JsonPropertyName("required_status_checks")]
        public IEnumerable<string> RequiredStatusChecks { get; set; } = null!;

        [JsonPropertyName("required_status_checks_enforcement_level")]
        public EnforcementLevel RequiredStatusChecksEnforcementLevel { get; set; }

        [JsonPropertyName("signature_requirement_enforcement_level")]
        public EnforcementLevel SignatureRequirementEnforcementLevel { get; set; }

        [JsonPropertyName("strict_required_status_checks_policy")]
        public bool StrictRequiredStatusChecksPolicy { get; set; }
    }
}
