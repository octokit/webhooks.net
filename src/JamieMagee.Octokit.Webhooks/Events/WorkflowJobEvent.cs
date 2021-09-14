namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    // TODO: Undocumented event

    [WebhookEventType(WebhookEventType.WorkflowJob)]
    [JsonConverter(typeof(WebhookConverter<WorkflowJobEvent>))]
    public abstract record WorkflowJobEvent : WebhookEvent;
}
