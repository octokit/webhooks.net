namespace JamieMagee.Octokit.Webhooks.Models.DiscussionEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record ChangesCategory
    {
        [JsonPropertyName("from")]
        public DiscussionCategory From { get; init; }
    }
}
