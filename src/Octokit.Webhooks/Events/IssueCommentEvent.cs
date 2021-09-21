namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;
    using Octokit.Webhooks.Models;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.IssueComment)]
    [JsonConverter(typeof(WebhookConverter<IssueCommentEvent>))]
    public abstract record IssueCommentEvent : WebhookEvent
    {
        [JsonPropertyName("issue")]
        public Issue Issue { get; init; } = null!;

        [JsonPropertyName("comment")]
        public Models.IssueComment Comment { get; init; } = null!;
    }
}
