namespace JamieMagee.Octokit.Webhooks.Events.InstallationRepositories
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(InstallationRepositoriesActionValue.Added)]
    public sealed record InstallationRepositoriesAddedEvent : InstallationRepositoriesEvent
    {
        [JsonPropertyName("action")]
        public override string Action => InstallationRepositoriesAction.Added;
    }
}
