namespace JamieMagee.Octokit.Webhooks.Models.IssuesEvent
{
    using System.Text.Json.Serialization;

    public sealed record ChangesTitle
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    }
}
