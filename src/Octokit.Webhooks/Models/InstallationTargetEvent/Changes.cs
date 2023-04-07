namespace Octokit.Webhooks.Models.InstallationTargetEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("login")]
    public ChangesLogin? Login { get; init; }

    [JsonPropertyName("slug")]
    public ChangesSlug? Slug { get; init; }
}
