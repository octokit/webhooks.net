namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.Milestone)]
    [JsonConverter(typeof(WebhookConverter<MilestoneEvent>))]
    public abstract record MilestoneEvent : WebhookEvent
    {
    }
}
