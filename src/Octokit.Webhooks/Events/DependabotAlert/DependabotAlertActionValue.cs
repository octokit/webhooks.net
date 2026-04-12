namespace Octokit.Webhooks.Events.DependabotAlert;

[PublicAPI]
public static class DependabotAlertActionValue
{
    public const string Created = "created";

    public const string Dismissed = "dismissed";

    public const string Fixed = "fixed";

    public const string Reintroduced = "reintroduced";

    public const string Reopened = "reopened";

    public const string AssigneesChanged = "assignees_changed";

    public const string AutoDismissed = "auto_dismissed";

    public const string AutoReopened = "auto_reopened";
}
