namespace JamieMagee.Octokit.Webhooks.Events.Repository
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record RepositoryRenamedEvent : RepositoryEvent
    {
        [JsonPropertyName("action")]
        public override string Action => RepositoryAction.Renamed;
    }
}
