namespace Octokit.Webhooks.Models.OrganizationEvent;

[PublicAPI]
public sealed record ChangesLogin
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
