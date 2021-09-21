namespace Octokit.Webhooks.Models.PullRequestReviewEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Changes
    {
        [JsonPropertyName("body")]
        public ChangesBody? Body { get; init; }
    }
}
