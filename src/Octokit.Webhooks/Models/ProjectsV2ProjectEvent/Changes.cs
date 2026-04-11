namespace Octokit.Webhooks.Models.ProjectsV2ProjectEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("description")]
    public ChangesField<string>? Description { get; init; }

    [JsonPropertyName("public")]
    public ChangesField<bool>? Public { get; init; }

    [JsonPropertyName("short_description")]
    public ChangesField<string>? ShortDescription { get; init; }

    [JsonPropertyName("title")]
    public ChangesField<string>? Title { get; init; }
}
