namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.InstallationRepositories)]
[JsonConverter(typeof(WebhookConverter<InstallationRepositoriesEvent>))]
public abstract record InstallationRepositoriesEvent : WebhookEvent
{
    [JsonPropertyName("installation")]
    public new Models.Installation Installation { get; init; } = null!;

    [JsonPropertyName("repository_selection")]
    [JsonConverter(typeof(StringEnumConverter<InstallationRepositorySelection>))]
    public required StringEnum<InstallationRepositorySelection> RepositorySelection { get; init; }

    [JsonPropertyName("repositories_added")]
    public required IReadOnlyList<Models.InstallationRepositoriesEvent.Repository> RepositoriesAdded { get; init; }

    [JsonPropertyName("repositories_removed")]
    public required IReadOnlyList<Models.InstallationRepositoriesEvent.Repository> RepositoriesRemoved { get; init; }

    [JsonPropertyName("requester")]
    public User? Requester { get; init; }
}
