namespace Octokit.Webhooks.Models.ProjectEvent;

[PublicAPI]
public sealed record ChangesBody
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
