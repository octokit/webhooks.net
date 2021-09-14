namespace JamieMagee.Octokit.Webhooks.Models.IssuesEvent
{
    using System.Text.Json.Serialization;

    public class ChangesTitle
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    }
}
