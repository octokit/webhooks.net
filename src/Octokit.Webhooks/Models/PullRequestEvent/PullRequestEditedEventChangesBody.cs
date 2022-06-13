namespace Octokit.Webhooks.Models.PullRequestEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record PullRequestEditedEventChangesBody
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}