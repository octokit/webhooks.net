namespace JamieMagee.Octokit.Webhooks.Events.RepositoryDispatch
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record RepositoryDispatchOnDemandTestEvent : RepositoryDispatchEvent
    {
        [JsonPropertyName("action")]
        public override string Action => RepositoryDispatchAction.OnDemandTest;
    }
}
