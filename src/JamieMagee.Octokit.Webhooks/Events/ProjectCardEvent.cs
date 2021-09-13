namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.ProjectCard)]
    [JsonConverter(typeof(WebhookConverter<ProjectCardEvent>))]
    public abstract record ProjectCardEvent : WebhookEvent
    {
    }
}
