namespace JamieMagee.Octokit.Webhooks
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    /// <summary>
    /// </summary>
    [PublicAPI]
    [JsonConverter(typeof(WebhookConverter<WebhookEvent>))]
    public abstract class WebhookEvent
    {
        /// <summary>
        /// </summary>
        [JsonPropertyName("action")]
        public abstract string Action { get; }
    }
}
