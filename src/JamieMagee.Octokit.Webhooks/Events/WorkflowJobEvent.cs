namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    // TODO: Undocumented event

    [PublicAPI]
    [WebhookEventType(WebhookEventType.WorkflowJob)]
    [JsonConverter(typeof(WebhookConverter<WorkflowJobEvent>))]
    public abstract record WorkflowJobEvent : WebhookEvent;
}
