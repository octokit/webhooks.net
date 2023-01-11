namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public sealed record DependabotAlertReference
{
    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;
}
