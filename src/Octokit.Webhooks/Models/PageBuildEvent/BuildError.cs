namespace Octokit.Webhooks.Models.PageBuildEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record BuildError
{
    [JsonPropertyName("message")]
    public string? Message { get; init; }
}
