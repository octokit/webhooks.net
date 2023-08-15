namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.DeploymentReview)]
[JsonConverter(typeof(WebhookConverter<DeploymentReviewEvent>))]
public abstract record DeploymentReviewEvent : WebhookEvent
{
    [JsonPropertyName("workflow_run")]
    public Models.WorkflowRun? WorkflowRun { get; init; }

    [JsonPropertyName("since")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset Since { get; init; }

    [JsonPropertyName("workflow_job_run")]
    public WorkflowJobRun? WorkflowJobRun { get; init; }

    [JsonPropertyName("workflow_job_runs")]
    public IEnumerable<WorkflowJobRun>? WorkflowJobRuns { get; init; }

    [JsonPropertyName("reviewers")]
    public IEnumerable<DeploymentReviewReviewer>? Reviewers { get; init; }

    [JsonPropertyName("approver")]
    public User? Approver { get; init; }

    [JsonPropertyName("comment")]
    public string? Comment { get; init; }
}
