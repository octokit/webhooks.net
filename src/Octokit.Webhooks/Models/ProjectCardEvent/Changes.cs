namespace Octokit.Webhooks.Models.ProjectCardEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("note")]
    public ChangesNote? Note { get; init; }

    [JsonPropertyName("column_id")]
    public ChangesColumnId? ColumnId { get; init; }
}
