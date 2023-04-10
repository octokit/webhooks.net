namespace Octokit.Webhooks.Models.InstallationTargetEvent;

[PublicAPI]
public record ChangesLogin
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
