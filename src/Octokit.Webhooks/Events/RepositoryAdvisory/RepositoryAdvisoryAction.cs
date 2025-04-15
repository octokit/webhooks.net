namespace Octokit.Webhooks.Events.RepositoryAdvisory;

[PublicAPI]
public sealed record RepositoryAdvisoryAction : WebhookEventAction
{
    public static readonly RepositoryAdvisoryAction Reported = new(RepositoryAdvisoryActionValue.Reported);

    public static readonly RepositoryAdvisoryAction Published = new(RepositoryAdvisoryActionValue.Published);

    private RepositoryAdvisoryAction(string value)
        : base(value)
    {
    }
}
