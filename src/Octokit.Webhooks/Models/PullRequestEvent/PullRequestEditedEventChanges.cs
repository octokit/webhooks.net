namespace Octokit.Webhooks.Models.PullRequestEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record PullRequestEditedEventChanges
    {
        [JsonPropertyName("body")]
        public PullRequestEditedEventChangesBody? Body { get; init; }

        [JsonPropertyName("title")]
        public PullRequestEditedEventChangesTitle? Title { get; init; }
    }
}
