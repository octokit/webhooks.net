namespace JamieMagee.Octokit.Webhooks
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JetBrains.Annotations;

    [PublicAPI]
    public abstract record WebhookEvent
    {
        [JsonPropertyName("action")]
        public virtual string Action { get; set; }

        [JsonPropertyName("repository")]
        public Repository Repository { get; set; } = null!;

        [JsonPropertyName("installation")]
        public InstallationLite? Installation { get; set; }

        [JsonPropertyName("organization")]
        public Organization? Organization { get; set; }

        [JsonPropertyName("sender")]
        public User Sender { get; set; } = null!;
    }
}
