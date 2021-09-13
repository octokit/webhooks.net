namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.WorkflowRun)]
    [JsonConverter(typeof(WebhookConverter<WorkflowRunEvent>))]
    public abstract record WorkflowRunEvent : WebhookEvent
    {
    }
}
