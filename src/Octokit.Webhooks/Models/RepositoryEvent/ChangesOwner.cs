namespace Octokit.Webhooks.Models.RepositoryEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record ChangesOwner
{
    [JsonPropertyName("from")]
    public ChangesOwnerFrom? From { get; init; }
}