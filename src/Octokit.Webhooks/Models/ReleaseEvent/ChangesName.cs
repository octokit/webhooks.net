namespace Octokit.Webhooks.Models.ReleaseEvent;

[PublicAPI]
public sealed record ChangesName
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
