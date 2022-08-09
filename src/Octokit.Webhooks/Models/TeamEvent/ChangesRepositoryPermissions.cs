namespace Octokit.Webhooks.Models.TeamEvent;

[PublicAPI]
public sealed record ChangesRepositoryPermissions
{
    [JsonPropertyName("from")]
    public ChangesRepositoryPermissionsFrom From { get; init; } = null!;
}
