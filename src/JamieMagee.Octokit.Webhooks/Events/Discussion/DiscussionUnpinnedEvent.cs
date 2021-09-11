namespace JamieMagee.Octokit.Webhooks.Events.Discussion
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record DiscussionUnpinnedEvent : DiscussionEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DiscussionAction.Unpinned;
    }
}
