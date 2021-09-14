namespace JamieMagee.Octokit.Webhooks.Models.IssuesEvent
{
    using System.Text.Json.Serialization;

    public class ChangesBody
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    }
}
