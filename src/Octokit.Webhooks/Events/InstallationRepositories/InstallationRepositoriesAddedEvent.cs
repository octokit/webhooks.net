namespace Octokit.Webhooks.Events.InstallationRepositories;

[PublicAPI]
[WebhookActionType(InstallationRepositoriesActionValue.Added)]
public sealed record InstallationRepositoriesAddedEvent : InstallationRepositoriesEvent
{
    [JsonPropertyName("action")]
    public override string Action => InstallationRepositoriesAction.Added;
}
