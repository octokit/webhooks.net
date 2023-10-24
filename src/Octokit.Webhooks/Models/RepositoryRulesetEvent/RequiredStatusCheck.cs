namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record RequiredStatusCheck
{
    [JsonPropertyName("context")]
    public string? Context { get; init; }

    [JsonPropertyName("integration_id")]
    public int IntegrationId { get; init; }
}
