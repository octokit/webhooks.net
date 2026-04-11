namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public sealed record DependabotAlertReference
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }
}
