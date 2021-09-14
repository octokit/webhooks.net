namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookEventType(WebhookEventType.Installation)]
    [JsonConverter(typeof(WebhookConverter<InstallationEvent>))]
    public abstract record InstallationEvent : WebhookEvent
    {
        [JsonPropertyName("installation")]
        public new Models.Installation Installation { get; init; } = null!;

        [JsonPropertyName("repositories")]
        public IEnumerable<Models.InstallationEvent.Repository> Repositories { get; init; }

        [JsonPropertyName("requester")]
        public User? Requester { get; init; }
    }
}
