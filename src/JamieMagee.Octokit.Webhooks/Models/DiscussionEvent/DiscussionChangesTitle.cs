namespace JamieMagee.Octokit.Webhooks.Models.DiscussionEvent
{
    using System.Text.Json.Serialization;

    public class DiscussionChangesTitle
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    }
}
