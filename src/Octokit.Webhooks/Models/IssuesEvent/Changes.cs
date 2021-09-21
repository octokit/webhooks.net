namespace Octokit.Webhooks.Models.IssuesEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Changes
    {
        [JsonPropertyName("title")]
        public ChangesTitle? Title { get; init; }

        [JsonPropertyName("body")]
        public ChangesBody? Body { get; init; }

        [JsonPropertyName("old_issue")]
        public Issue? OldIssue { get; init; }

        [JsonPropertyName("old_repository")]
        public Repository? OldRepository { get; init; }

        [JsonPropertyName("new_issue")]
        public Issue? NewIssue { get; init; }

        [JsonPropertyName("new_repository")]
        public Repository? NewRepository { get; init; }
    }
}
