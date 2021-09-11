namespace JamieMagee.Octokit.Webhooks.Events.InstallationRepositories
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record InstallationRepositoriesAddedEvent : InstallationRepositoriesEvent
    {
        [JsonPropertyName("action")]
        public override string Action => InstallationRepositoriesAction.Added;
    }
}
