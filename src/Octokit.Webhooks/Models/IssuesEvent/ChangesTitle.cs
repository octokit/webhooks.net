namespace Octokit.Webhooks.Models.IssuesEvent
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
