namespace Octokit.Webhooks.Events.InstallationRepositories
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(InstallationRepositoriesActionValue.Removed)]
    public sealed record InstallationRepositoriesRemovedEvent : InstallationRepositoriesEvent
    {
        [JsonPropertyName("action")]
        public override string Action => InstallationRepositoriesAction.Removed;
    }
}
