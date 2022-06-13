namespace Octokit.Webhooks.Models.ProjectCardEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record ChangesColumnId
{
    [JsonPropertyName("from")]
    public long From { get; init; }
}