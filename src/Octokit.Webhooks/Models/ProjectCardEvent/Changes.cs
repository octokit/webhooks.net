namespace Octokit.Webhooks.Models.ProjectCardEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("note")]
    public ChangesNote? Note { get; init; }

    [JsonPropertyName("column_id")]
    public ChangesColumnId? ColumnId { get; init; }
}
