namespace Octokit.Webhooks.Models.TeamEvent;

[PublicAPI]
public sealed record ChangesRepositoryPermissions
{
    [JsonPropertyName("from")]
    public required ChangesRepositoryPermissionsFrom From { get; init; }
}
