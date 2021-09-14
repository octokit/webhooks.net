namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.MembershipAddedEvent;

    [WebhookEventType(WebhookEventType.Membership)]
    [JsonConverter(typeof(WebhookConverter<MembershipEvent>))]
    public abstract record MembershipEvent : WebhookEvent
    {
        [JsonPropertyName("scope")]
        public Scope Scope { get; init; }

        [JsonPropertyName("member")]
        public User Member { get; init; }

        [JsonPropertyName("team")]
        public Models.Team Team { get; init; }
    }
}
