namespace JamieMagee.Octokit.Webhooks.Models.ProjectCardEvent
{
    using System.Text.Json.Serialization;

    public record Changes
    {
        [JsonPropertyName("note")]
        public ChangesNote? Note { get; init; } = null!;

        [JsonPropertyName("column_id")]
        public ChangesColumnId? ColumnId { get; init; } = null!;
    };
}
