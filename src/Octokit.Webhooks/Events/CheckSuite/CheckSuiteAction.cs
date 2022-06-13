namespace Octokit.Webhooks.Events.CheckSuite;

using JetBrains.Annotations;

[PublicAPI]
public sealed record CheckSuiteAction : WebhookEventAction
{
    public static readonly CheckSuiteAction Completed = new(CheckSuiteActionValue.Completed);

    public static readonly CheckSuiteAction Requested = new(CheckSuiteActionValue.Requested);

    public static readonly CheckSuiteAction Rerequested = new(CheckSuiteActionValue.Rerequested);

    private CheckSuiteAction(string value)
        : base(value)
    {
    }
}