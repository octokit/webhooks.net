namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.GithubAppAuthorization)]
    [JsonConverter(typeof(WebhookConverter<GithubAppAuthorizationEvent>))]
    public abstract record GithubAppAuthorizationEvent : WebhookEvent
    {
    }
}
