namespace Octokit.Webhooks.Events.DependabotAlert;

[PublicAPI]
public sealed record DependabotAlertAction : WebhookEventAction
{
    public static readonly DependabotAlertAction Created = new(DependabotAlertActionValue.Created);

    public static readonly DependabotAlertAction Dismissed = new(DependabotAlertActionValue.Dismissed);

    public static readonly DependabotAlertAction Reopened = new(DependabotAlertActionValue.Reopened);

    public static readonly DependabotAlertAction Fixed = new(DependabotAlertActionValue.Fixed);

    public static readonly DependabotAlertAction Reintroduced = new(DependabotAlertActionValue.Reintroduced);

    private DependabotAlertAction(string value)
        : base(value)
    {
    }
}
