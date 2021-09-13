namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.CommitComment)]
    [JsonConverter(typeof(WebhookConverter<CommitCommentEvent>))]
    public abstract record CommitCommentEvent : WebhookEvent
    {
    }
}
