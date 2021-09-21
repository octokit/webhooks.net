namespace Octokit.Webhooks
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models;
    using JetBrains.Annotations;

    [PublicAPI]
    public abstract record WebhookEvent
    {
        [JsonPropertyName("action")]
        public virtual string? Action { get; init; }

        [JsonPropertyName("repository")]
        public Repository? Repository { get; init; }

        [JsonPropertyName("installation")]
        public InstallationLite? Installation { get; init; }

        [JsonPropertyName("organization")]
        public Organization? Organization { get; init; }

        [JsonPropertyName("sender")]
        public User? Sender { get; init; }
    }
}
