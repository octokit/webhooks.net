namespace Octokit.Webhooks.Events.OrgBlock;

[PublicAPI]
public sealed record OrgBlockAction : WebhookEventAction
{
    public static readonly OrgBlockAction Blocked = new(OrgBlockActionValue.Blocked);

    public static readonly OrgBlockAction Unblocked = new(OrgBlockActionValue.Unblocked);

    private OrgBlockAction(string value)
        : base(value)
    {
    }
}
