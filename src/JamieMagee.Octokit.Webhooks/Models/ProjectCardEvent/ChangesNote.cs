namespace JamieMagee.Octokit.Webhooks.Models.ProjectCardEvent
{
    using System.Text.Json.Serialization;

    public class ChangesNote
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    }
}
