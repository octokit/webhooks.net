namespace Octokit.Webhooks.Events.RepositoryDispatch;

[PublicAPI]
[WebhookActionType(RepositoryDispatchActionValue.OnDemandTest)]
public sealed record RepositoryDispatchOnDemandTestEvent : RepositoryDispatchEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryDispatchAction.OnDemandTest;
}
