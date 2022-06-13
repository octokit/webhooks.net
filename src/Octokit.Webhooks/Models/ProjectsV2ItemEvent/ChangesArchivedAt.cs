namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
public sealed record ChangesArchivedAt
{
    [JsonPropertyName("from")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? From { get; init; }

    [JsonPropertyName("archived_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? To { get; init; }
}