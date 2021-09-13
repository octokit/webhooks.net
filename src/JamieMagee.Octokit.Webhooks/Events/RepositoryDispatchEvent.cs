namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.RepositoryDispatch)]
    [JsonConverter(typeof(WebhookConverter<RepositoryDispatchEvent>))]
    public abstract record RepositoryDispatchEvent : WebhookEvent
    {
    }
}
