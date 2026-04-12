namespace Octokit.Webhooks.Events.SecretScanningAlert;

[PublicAPI]
public static class SecretScanningAlertActionValue
{
    public const string Created = "created";

    public const string Reopened = "reopened";

    public const string Resolved = "resolved";

    public const string Revoked = "revoked";

    public const string Assigned = "assigned";

    public const string PubliclyLeaked = "publicly_leaked";

    public const string Unassigned = "unassigned";

    public const string Validated = "validated";
}
