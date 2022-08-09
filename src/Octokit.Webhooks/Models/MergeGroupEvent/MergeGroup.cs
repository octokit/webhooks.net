namespace Octokit.Webhooks.Models.MergeGroupEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record MergeGroup
{
    [JsonPropertyName("head_sha")]
    public string HeadSha { get; init; } = null!;

    [JsonPropertyName("head_ref")]
    public string HeadRef { get; init; } = null!;

    [JsonPropertyName("base_ref")]
    public string BaseRef { get; init; } = null!;
}
