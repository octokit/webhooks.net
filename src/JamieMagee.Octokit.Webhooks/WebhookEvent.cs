namespace Octokit.Webhooks
{
    using System.Text.Json.Serialization;
    using Converter;
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
