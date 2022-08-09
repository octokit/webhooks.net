namespace Octokit.Webhooks.Models.MemberEvent;

[PublicAPI]
public sealed record ChangesOldPermission
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
