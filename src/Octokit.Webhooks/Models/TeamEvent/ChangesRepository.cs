namespace Octokit.Webhooks.Models.TeamEvent;

[PublicAPI]
public sealed record ChangesRepository
{
    [JsonPropertyName("permissions")]
    public ChangesRepositoryPermissions Permissions { get; init; } = null!;
}
