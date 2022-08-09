namespace Octokit.Webhooks.Models.MemberEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("permission")]
    public ChangesPermission? Permission { get; init; }

    [JsonPropertyName("old_permission")]
    public ChangesPermission? OldPermission { get; init; }
}
