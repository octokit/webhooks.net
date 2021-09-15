namespace JamieMagee.Octokit.Webhooks.Events.RepositoryDispatch
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(RepositoryDispatchActionValue.OnDemandTest)]
    public sealed record RepositoryDispatchOnDemandTestEvent : RepositoryDispatchEvent
    {
        [JsonPropertyName("action")]
        public override string Action => RepositoryDispatchAction.OnDemandTest;
    }
}
