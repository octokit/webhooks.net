namespace Octokit.Webhooks.Models.InstallationTargetEvent;

[PublicAPI]
public record ChangesLogin
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
