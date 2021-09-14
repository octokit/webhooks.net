namespace JamieMagee.Octokit.Webhooks.Models.MetaEvent
{
    using System.Text.Json.Serialization;

    public sealed record HookConfig
    {
        [JsonPropertyName("secret")]
        public HookConfigContentType ContentType { get; init; }

        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("insecure_ssl")]
        public string InsecureSsl { get; init; } = null!;
    };
}
