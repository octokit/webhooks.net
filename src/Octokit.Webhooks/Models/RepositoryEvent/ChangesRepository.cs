namespace Octokit.Webhooks.Models.RepositoryEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record ChangesRepository
{
    [JsonPropertyName("name")]
    public ChangesRepositoryName? Name { get; init; }
}
