namespace Octokit.Webhooks.Events.InstallationRepositories;

[PublicAPI]
[WebhookActionType(InstallationRepositoriesActionValue.Removed)]
public sealed record InstallationRepositoriesRemovedEvent : InstallationRepositoriesEvent
{
    [JsonPropertyName("action")]
    public override string Action => InstallationRepositoriesAction.Removed;
}
