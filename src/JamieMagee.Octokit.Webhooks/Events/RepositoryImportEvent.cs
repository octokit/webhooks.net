namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models.RepositoryImportEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.RepositoryImport)]
    public sealed record RepositoryImportEvent : WebhookEvent
    {
        [JsonPropertyName("status")]
        public Status Status { get; init; }
    }
}
