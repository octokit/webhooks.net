namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.GithubAppAuthorization)]
    [JsonConverter(typeof(WebhookConverter<GithubAppAuthorizationEvent>))]
    public abstract record GithubAppAuthorizationEvent : WebhookEvent
    {
    }
}
