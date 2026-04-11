namespace Octokit.Webhooks.Models.SecurityAdvisoryEvent;

[PublicAPI]
public sealed record SecurityAdvisoryReference
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }
}
