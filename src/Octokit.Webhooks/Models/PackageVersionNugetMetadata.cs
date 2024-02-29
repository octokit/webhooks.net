namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record PackageVersionNugetMetadata
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("value")]
    public dynamic? Value { get; init; }
}
