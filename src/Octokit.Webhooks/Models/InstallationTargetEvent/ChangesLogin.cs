namespace Octokit.Webhooks.Models.InstallationTargetEvent;

[PublicAPI]
public sealed record ChangesLogin
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
