namespace Octokit.Webhooks.Models.ReleaseEvent;

[PublicAPI]
public sealed record ChangesBody
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
