namespace Octokit.Webhooks.Events.CheckRun;

using JetBrains.Annotations;

[PublicAPI]
public sealed record CheckRunAction : WebhookEventAction
{
    public static readonly CheckRunAction Completed = new(CheckRunActionValue.Completed);

    public static readonly CheckRunAction Created = new(CheckRunActionValue.Created);

    public static readonly CheckRunAction RequestedAction = new(CheckRunActionValue.RequestedAction);

    public static readonly CheckRunAction Rerequested = new(CheckRunActionValue.Rerequested);

    private CheckRunAction(string value)
        : base(value)
    {
    }
}
