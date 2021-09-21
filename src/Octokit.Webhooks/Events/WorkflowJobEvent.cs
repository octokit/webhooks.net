namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    // TODO: Undocumented event
    [PublicAPI]
    [WebhookEventType(WebhookEventType.WorkflowJob)]
    [JsonConverter(typeof(WebhookConverter<WorkflowJobEvent>))]
    public abstract record WorkflowJobEvent : WebhookEvent;
}
