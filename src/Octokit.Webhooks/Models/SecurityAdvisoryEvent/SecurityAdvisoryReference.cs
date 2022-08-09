namespace Octokit.Webhooks.Models.SecurityAdvisoryEvent;

[PublicAPI]
public sealed record SecurityAdvisoryReference
{
    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;
}
