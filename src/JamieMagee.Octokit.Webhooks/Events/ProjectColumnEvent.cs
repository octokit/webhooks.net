namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.ProjectColumn)]
    [JsonConverter(typeof(WebhookConverter<ProjectColumnEvent>))]
    public abstract record ProjectColumnEvent : WebhookEvent
    {
        [JsonPropertyName("project_column")]
        public Models.ProjectColumn ProjectColumn { get; init; }
    }
}
