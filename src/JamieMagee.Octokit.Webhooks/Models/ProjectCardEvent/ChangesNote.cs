namespace JamieMagee.Octokit.Webhooks.Models.ProjectCardEvent
{
    using System.Text.Json.Serialization;

    public sealed record ChangesNote
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    }
}
