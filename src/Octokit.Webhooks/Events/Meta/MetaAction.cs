namespace Octokit.Webhooks.Events.Meta;

[PublicAPI]
public sealed record MetaAction : WebhookEventAction
{
    public static readonly MetaAction Deleted = new(MetaActionValue.Deleted);

    private MetaAction(string value)
        : base(value)
    {
    }
}
