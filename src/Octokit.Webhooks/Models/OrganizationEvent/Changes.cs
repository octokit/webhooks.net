namespace Octokit.Webhooks.Models.OrganizationEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("login")]
    public ChangesLogin Login { get; init; } = null!;
}
