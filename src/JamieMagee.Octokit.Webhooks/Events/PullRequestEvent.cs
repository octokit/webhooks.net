namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.PullRequest)]
    [JsonConverter(typeof(WebhookConverter<PullRequestEvent>))]
    public abstract record PullRequestEvent : WebhookEvent
    {
        [JsonPropertyName("number")]
        public int Number { get; init; }

        [JsonPropertyName("pull_request")]
        public Models.PullRequest PullRequest { get; init; } = null!;
    }
}
