namespace Octokit.Webhooks.Models.MemberEvent;

[PublicAPI]
public sealed record ChangesPermission
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
