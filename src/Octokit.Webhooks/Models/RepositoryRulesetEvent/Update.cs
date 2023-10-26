namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record Update
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("parameters")]
    public Parameter? Parameters { get; init; }
}
