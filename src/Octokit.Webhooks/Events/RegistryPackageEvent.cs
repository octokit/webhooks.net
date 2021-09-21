namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.RegistryPackage)]
    [JsonConverter(typeof(WebhookConverter<RegistryPackageEvent>))]
    public abstract record RegistryPackageEvent : WebhookEvent
    {
    }
}
