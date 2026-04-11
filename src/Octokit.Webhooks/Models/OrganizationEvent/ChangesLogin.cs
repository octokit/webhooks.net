namespace Octokit.Webhooks.Models.OrganizationEvent;

[PublicAPI]
public record ChangesLogin
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
