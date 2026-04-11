namespace Octokit.Webhooks.Models.InstallationTargetEvent;

[PublicAPI]
public sealed record ChangesSlug
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
