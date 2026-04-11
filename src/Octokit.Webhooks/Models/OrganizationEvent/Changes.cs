namespace Octokit.Webhooks.Models.OrganizationEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("login")]
    public required ChangesLogin Login { get; init; }
}
