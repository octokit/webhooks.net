namespace Octokit.Webhooks.Models.ProjectEvent;

[PublicAPI]
public sealed record ChangesBody
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
