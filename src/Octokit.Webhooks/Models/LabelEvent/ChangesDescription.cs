namespace Octokit.Webhooks.Models.LabelEvent;

[PublicAPI]
public sealed record ChangesDescription
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
