namespace Octokit.Webhooks.Models.MemberEvent;

[PublicAPI]
public sealed record ChangesPermission
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
