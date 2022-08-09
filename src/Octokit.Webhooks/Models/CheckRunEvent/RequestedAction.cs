namespace Octokit.Webhooks.Models.CheckRunEvent;

[PublicAPI]
public sealed record RequestedAction
{
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }
}
