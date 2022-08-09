namespace Octokit.Webhooks.Models.ReleaseEvent;

[PublicAPI]
public sealed record ChangesBody
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
