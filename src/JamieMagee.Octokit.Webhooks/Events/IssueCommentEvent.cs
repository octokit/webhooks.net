namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.IssueComment)]
    [JsonConverter(typeof(WebhookConverter<IssueCommentEvent>))]
    public abstract record IssueCommentEvent : WebhookEvent
    {
    }
}
