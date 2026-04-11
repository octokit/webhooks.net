namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record Link
{
    [JsonPropertyName("href")]
    public required string Href { get; init; }
}
