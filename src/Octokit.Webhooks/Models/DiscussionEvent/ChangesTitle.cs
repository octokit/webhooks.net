namespace Octokit.Webhooks.Models.DiscussionEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record ChangesTitle
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    }
}
