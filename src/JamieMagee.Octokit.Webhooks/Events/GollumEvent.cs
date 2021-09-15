namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models.GollumEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Gollum)]
    public sealed record GollumEvent : WebhookEvent
    {
        [JsonPropertyName("pages")]
        public IEnumerable<Page> Pages { get; init; } = null!;
    }
}
