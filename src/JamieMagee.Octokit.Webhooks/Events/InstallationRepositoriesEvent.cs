namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.InstallationRepositories)]
    [JsonConverter(typeof(WebhookConverter<InstallationRepositoriesEvent>))]
    public abstract record InstallationRepositoriesEvent : WebhookEvent
    {
    }
}
