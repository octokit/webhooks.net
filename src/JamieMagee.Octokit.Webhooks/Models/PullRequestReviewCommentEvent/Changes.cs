namespace JamieMagee.Octokit.Webhooks.Models.PullRequestReviewCommentEvent
{
    using System.Text.Json.Serialization;

    public sealed record Changes
    {
        [JsonPropertyName("body")]
        public ChangesBody? Body { get; init; }
    };
}
