namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[PublicAPI]
public sealed record ChangesContentType
{
    [JsonPropertyName("from")]
    [JsonConverter(typeof(StringEnumConverter<ProjectsV2ItemContentType>))]
    public StringEnum<ProjectsV2ItemContentType> From { get; init; } = null!;

    [JsonPropertyName("to")]
    [JsonConverter(typeof(StringEnumConverter<ProjectsV2ItemContentType>))]
    public StringEnum<ProjectsV2ItemContentType> To { get; init; } = null!;
}
