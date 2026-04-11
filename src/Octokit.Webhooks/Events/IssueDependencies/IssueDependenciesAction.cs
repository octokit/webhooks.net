namespace Octokit.Webhooks.Events.IssueDependencies;

[PublicAPI]
public sealed record IssueDependenciesAction : WebhookEventAction
{
    public static readonly IssueDependenciesAction BlockedByAdded = new(IssueDependenciesActionValue.BlockedByAdded);

    public static readonly IssueDependenciesAction BlockedByRemoved = new(IssueDependenciesActionValue.BlockedByRemoved);

    public static readonly IssueDependenciesAction BlockingAdded = new(IssueDependenciesActionValue.BlockingAdded);

    public static readonly IssueDependenciesAction BlockingRemoved = new(IssueDependenciesActionValue.BlockingRemoved);

    private IssueDependenciesAction(string value)
        : base(value)
    {
    }
}
