namespace JamieMagee.Octokit.Webhooks.Models.DiscussionEvent
{
    using System.Text.Json.Serialization;

    public sealed record DiscussionChangesTitle
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    }
}
