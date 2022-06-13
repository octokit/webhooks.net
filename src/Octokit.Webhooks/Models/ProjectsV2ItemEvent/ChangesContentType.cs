namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record ChangesContentType
{
    [JsonPropertyName("from")]
    public ProjectsV2ItemContentType From { get; init; }

    [JsonPropertyName("to")]
    public ProjectsV2ItemContentType To { get; init; }
}