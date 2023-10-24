namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record PullRequest
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("dismiss_stale_reviews_on_push")]
    public bool DismissStaleReviewsOnPush { get; init; }

    [JsonPropertyName("require_code_owner_review")]
    public bool RequireCodeOwnerReview { get; init; }

    [JsonPropertyName("require_last_push_approval")]
    public bool RequireLastPushApproval { get; init; }

    [JsonPropertyName("required_approving_review_count")]
    public bool RequiredApprovingReviewCount { get; init; }

    [JsonPropertyName("required_review_thread_resolution")]
    public bool RequiredReviewThreadResolution { get; init; }
}
