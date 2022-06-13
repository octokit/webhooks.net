namespace Octokit.Webhooks.Models.TeamEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("description")]
    public ChangesDescription? Description { get; init; }

    [JsonPropertyName("name")]
    public ChangesName? Name { get; init; }

    [JsonPropertyName("privacy")]
    public ChangesPrivacy? Privacy { get; init; }

    [JsonPropertyName("repository")]
    public ChangesRepository? Repository { get; init; }
}