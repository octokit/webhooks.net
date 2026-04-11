namespace Octokit.Webhooks.Events.DependabotAlert;

[PublicAPI]
public sealed record DependabotAlertAction : WebhookEventAction
{
    public static readonly DependabotAlertAction Created = new(DependabotAlertActionValue.Created);

    public static readonly DependabotAlertAction Dismissed = new(DependabotAlertActionValue.Dismissed);

    public static readonly DependabotAlertAction Reopened = new(DependabotAlertActionValue.Reopened);

    public static readonly DependabotAlertAction Fixed = new(DependabotAlertActionValue.Fixed);

    public static readonly DependabotAlertAction Reintroduced = new(DependabotAlertActionValue.Reintroduced);

    public static readonly DependabotAlertAction AssigneesChanged = new(DependabotAlertActionValue.AssigneesChanged);
    public static readonly DependabotAlertAction AutoDismissed = new(DependabotAlertActionValue.AutoDismissed);
    public static readonly DependabotAlertAction AutoReopened = new(DependabotAlertActionValue.AutoReopened);

    private DependabotAlertAction(string value)
        : base(value)
    {
    }
}
