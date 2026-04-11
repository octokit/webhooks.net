namespace Octokit.Webhooks.Events.CustomPropertyPromotedToEnterprise;

[PublicAPI]
public sealed record CustomPropertyPromotedToEnterpriseAction : WebhookEventAction
{
    public static readonly CustomPropertyPromotedToEnterpriseAction PromoteToEnterprise = new(CustomPropertyPromotedToEnterpriseActionValue.PromoteToEnterprise);

    private CustomPropertyPromotedToEnterpriseAction(string value)
        : base(value)
    {
    }
}
