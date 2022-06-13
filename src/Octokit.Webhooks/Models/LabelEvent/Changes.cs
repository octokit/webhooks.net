namespace Octokit.Webhooks.Models.LabelEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("color")]
    public ChangesColor Color { get; init; } = null!;

    [JsonPropertyName("name")]
    public ChangesName Name { get; init; } = null!;

    [JsonPropertyName("description")]
    public ChangesDescription Description { get; init; } = null!;
}
