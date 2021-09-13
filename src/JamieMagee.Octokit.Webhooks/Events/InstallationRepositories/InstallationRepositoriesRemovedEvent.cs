namespace JamieMagee.Octokit.Webhooks.Events.InstallationRepositories
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(InstallationRepositoriesActionValue.Removed)]
    public sealed record InstallationRepositoriesRemovedEvent : InstallationRepositoriesEvent
    {
        [JsonPropertyName("action")]
        public override string Action => InstallationRepositoriesAction.Removed;
    }
}
