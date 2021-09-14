namespace JamieMagee.Octokit.Webhooks.Models.DiscussionEvent
{
    using System.Text.Json.Serialization;

    public sealed record DiscussionChangesCategory
    {
        [JsonPropertyName("from")]
        public DiscussionCategory From { get; init; }
    }
}
