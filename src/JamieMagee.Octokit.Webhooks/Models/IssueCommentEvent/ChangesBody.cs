namespace JamieMagee.Octokit.Webhooks.Models.IssueCommentEvent
{
    using System.Text.Json.Serialization;

    public sealed record ChangesBody
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    };
}
