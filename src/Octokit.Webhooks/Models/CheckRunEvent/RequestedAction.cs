namespace Octokit.Webhooks.Models.CheckRunEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record RequestedAction
{
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }
}