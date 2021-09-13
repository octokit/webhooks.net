namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.WorkflowJob)]
    [JsonConverter(typeof(WebhookConverter<WorkflowJobEvent>))]
    public abstract record WorkflowJobEvent : WebhookEvent
    {
    }
}
