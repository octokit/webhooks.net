namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[PublicAPI]
public sealed record ChangesContentType
{
    [JsonPropertyName("from")]
    [JsonConverter(typeof(StringEnumConverter<ProjectsV2ItemContentType>))]
    public required StringEnum<ProjectsV2ItemContentType> From { get; init; }

    [JsonPropertyName("to")]
    [JsonConverter(typeof(StringEnumConverter<ProjectsV2ItemContentType>))]
    public required StringEnum<ProjectsV2ItemContentType> To { get; init; }
}
