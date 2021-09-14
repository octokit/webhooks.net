namespace JamieMagee.Octokit.Webhooks.Models.ProjectCardEvent
{
    using System.Text.Json.Serialization;

    public record ChangesColumnId
    {
        [JsonPropertyName("from")]
        public int From { get; init; }
    }
}
