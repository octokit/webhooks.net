namespace Octokit.Webhooks.Models.OrganizationEvent;

[PublicAPI]
public record ChangesLogin
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
