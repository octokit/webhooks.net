namespace Octokit.Webhooks.Models;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record Link
{
    [JsonPropertyName("href")]
    public string Href { get; init; } = null!;
}
