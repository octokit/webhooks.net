namespace Octokit.Webhooks.Models.LabelEvent;

[PublicAPI]
public sealed record ChangesName
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
