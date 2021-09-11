namespace JamieMagee.Octokit.Webhooks
{
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JamieMagee.Octokit.Webhooks.Models;
    using JetBrains.Annotations;

    /// <summary>
    /// </summary>
    [PublicAPI]
    [JsonConverter(typeof(WebhookConverter<WebhookEvent>))]
    public abstract record WebhookEvent
    {
        /// <summary>
        /// </summary>
        [JsonPropertyName("action")]
        public virtual string Action { get; }

        [JsonPropertyName("repository")]
        public Repository Repository { get; set; } = null!;

        [JsonPropertyName("installation")]
        public InstallationLite? Installation { get; set; }

        [JsonPropertyName("organization")]
        public Organization? Organization { get; set; }

        [JsonPropertyName("sender")]
        public User Sender { get; set; } = null!;

        public static WebhookEvent? Parse(string json) => JsonSerializer.Deserialize<WebhookEvent>(json);
    }
}
