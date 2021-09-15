namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JamieMagee.Octokit.Webhooks.Models;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.OrgBlock)]
    [JsonConverter(typeof(WebhookConverter<OrgBlockEvent>))]
    public abstract record OrgBlockEvent : WebhookEvent
    {
        [JsonPropertyName("blocked_user")]
        public User BlockedUser { get; init; } = null!;
    }
}
