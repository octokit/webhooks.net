namespace Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Discussion
    {
        [JsonPropertyName("repository_url")]
        public string RepositoryUrl { get; init; } = null!;

        [JsonPropertyName("category")]
        public DiscussionCategory Category { get; init; } = null!;

        [JsonPropertyName("answer_html_url")]
        public string? AnswerHtmlUrl { get; init; }

        [JsonPropertyName("answer_chosen_at")]
        public string? AnswerChosenAt { get; init; }

        [JsonPropertyName("answer_chosen_by")]
        public User? AnswerChosenBy { get; init; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; } = null!;

        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("number")]
        public long Number { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; } = null!;

        [JsonPropertyName("user")]
        public User User { get; init; } = null!;

        [JsonPropertyName("state")]
        public DiscussionState State { get; init; }

        [JsonPropertyName("locked")]
        public long Locked { get; init; }

        [JsonPropertyName("comments")]
        public long Comments { get; init; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;

        [JsonPropertyName("author_association")]
        public AuthorAssociation AuthorAssociation { get; init; }

        [JsonPropertyName("active_lock_reason")]
        public string? ActiveLockReason { get; init; }

        [JsonPropertyName("body")]
        public string Body { get; init; } = null!;
    }
}
