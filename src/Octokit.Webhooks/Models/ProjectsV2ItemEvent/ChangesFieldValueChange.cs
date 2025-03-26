namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[PublicAPI]
public sealed record ChangesFieldValueChange
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("color")]
    public string Color { get; init; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; init; } = null!;
}
