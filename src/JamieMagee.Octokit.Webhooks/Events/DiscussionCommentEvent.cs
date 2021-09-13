namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.DiscussionComment)]
    [JsonConverter(typeof(WebhookConverter<DiscussionCommentEvent>))]
    public abstract record DiscussionCommentEvent : WebhookEvent
    {
    }
}
