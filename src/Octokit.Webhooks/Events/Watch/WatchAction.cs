namespace Octokit.Webhooks.Events.Watch;

[PublicAPI]
public sealed record WatchAction : WebhookEventAction
{
    public static readonly WatchAction Started = new(WatchActionValue.Started);

    private WatchAction(string value)
        : base(value)
    {
    }
}
