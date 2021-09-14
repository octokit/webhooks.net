namespace JamieMagee.Octokit.Webhooks.Models.PullRequestReviewEvent
{
    using System.Text.Json.Serialization;

    public sealed record Changes
    {
        [JsonPropertyName("body")]
        public ChangesBody? Body { get; init; }
    };
}
