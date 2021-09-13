namespace JamieMagee.Octokit.Webhooks.Events.RepositoryDispatch
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(RepositoryDispatchActionValue.OnDemandTest)]
    public sealed record RepositoryDispatchOnDemandTestEvent : RepositoryDispatchEvent
    {
        [JsonPropertyName("action")]
        public override string Action => RepositoryDispatchAction.OnDemandTest;
    }
}
