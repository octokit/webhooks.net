namespace JamieMagee.Octokit.Webhooks.Models.PullRequestEvent
{
    using System.Text.Json.Serialization;

    public sealed record PullRequestEditedEventChangesBody
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    }
}
