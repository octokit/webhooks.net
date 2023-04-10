namespace Octokit.Webhooks.Models.InstallationTargetEvent;

[PublicAPI]
public sealed record ChangesSlug
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
