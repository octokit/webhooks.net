namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record Link
{
    [JsonPropertyName("href")]
    public string Href { get; init; } = null!;
}
