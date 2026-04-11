namespace Octokit.Webhooks.Models.LabelEvent;

[PublicAPI]
public sealed record ChangesColor
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
