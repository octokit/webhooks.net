namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.RegistryPackage)]
    [JsonConverter(typeof(WebhookConverter<RegistryPackageEvent>))]
    public abstract record RegistryPackageEvent : WebhookEvent
    {
    }
}
