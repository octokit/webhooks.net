namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class Discussion
    {
        [JsonPropertyName("repository_url")]
        public string RepositoryUrl { get; init; }

        [JsonPropertyName("category")]
        public DiscussionCategory Category { get; init; }

        [JsonPropertyName("answer_html_url")]
        public string? AnswerHtmlUrl { get; init; }

        [JsonPropertyName("answer_chosen_at")]
        public string? AnswerChosenAt { get; init; }

        [JsonPropertyName("answer_chosen_by")]
        public User? AnswerChosenBy { get; init; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; }

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; }

        [JsonPropertyName("number")]
        public int Number { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("user")]
        public User User { get; init; }

        [JsonPropertyName("state")]
        public DiscussionState State { get; init; }

        [JsonPropertyName("locked")]
        public int Locked { get; init; }

        [JsonPropertyName("comments")]
        public int Comments { get; init; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; }

        [JsonPropertyName("author_association")]
        public AuthorAssociation AuthorAssociation { get; init; }

        [JsonPropertyName("active_lock_reason")]
        public string? ActiveLockReason { get; init; }

        [JsonPropertyName("body")]
        public string Body { get; init; }
    }
}
