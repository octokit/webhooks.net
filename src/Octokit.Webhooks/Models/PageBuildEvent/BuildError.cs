namespace Octokit.Webhooks.Models.PageBuildEvent;

[PublicAPI]
public sealed record BuildError
{
    [JsonPropertyName("message")]
    public string? Message { get; init; }
}
