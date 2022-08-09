namespace Octokit.Webhooks.Models.LabelEvent;

[PublicAPI]
public sealed record ChangesColor
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
