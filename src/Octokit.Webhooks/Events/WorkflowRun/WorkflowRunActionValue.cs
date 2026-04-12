namespace Octokit.Webhooks.Events.WorkflowRun;

[PublicAPI]
public static class WorkflowRunActionValue
{
    public const string Completed = "completed";

    public const string InProgress = "in_progress";

    public const string Requested = "requested";
}
