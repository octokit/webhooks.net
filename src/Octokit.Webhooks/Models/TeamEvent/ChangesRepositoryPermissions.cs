namespace Octokit.Webhooks.Models.TeamEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record ChangesRepositoryPermissions
{
    [JsonPropertyName("from")]
    public ChangesRepositoryPermissionsFrom From { get; init; } = null!;
}
