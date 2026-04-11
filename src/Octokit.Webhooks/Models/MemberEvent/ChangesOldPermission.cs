namespace Octokit.Webhooks.Models.MemberEvent;

[PublicAPI]
public sealed record ChangesOldPermission
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
