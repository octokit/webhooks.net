namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.RepositoryDispatch)]
    [JsonConverter(typeof(WebhookConverter<RepositoryDispatchEvent>))]
    public abstract record RepositoryDispatchEvent : WebhookEvent
    {
        [JsonPropertyName("branch")]
        public string branch { get; init; } = null!;

        [JsonPropertyName("client_payload")]
        public dynamic client_payload { get; init; } = null!;
    }
}
