namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[PublicAPI]
public sealed record ChangesFieldValueChange : ChangesFieldValueChangeBase
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("color")]
    public required string Color { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }
}
