namespace Octokit.Webhooks.Models.TeamEvent;

[PublicAPI]
public sealed record ChangesRepository
{
    [JsonPropertyName("permissions")]
    public required ChangesRepositoryPermissions Permissions { get; init; }
}
