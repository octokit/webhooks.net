namespace Octokit.Webhooks.Models.LabelEvent;

[PublicAPI]
public sealed record ChangesDescription
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
