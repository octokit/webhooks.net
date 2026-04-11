namespace Octokit.Webhooks.Events.CustomPropertyPromotedToEnterprise;

[PublicAPI]
[WebhookActionType(CustomPropertyPromotedToEnterpriseActionValue.PromoteToEnterprise)]
public sealed record CustomPropertyPromotedToEnterprisePromoteToEnterpriseEvent : CustomPropertyPromotedToEnterpriseEvent
{
    [JsonPropertyName("action")]
    public override string Action => CustomPropertyPromotedToEnterpriseAction.PromoteToEnterprise;
}
