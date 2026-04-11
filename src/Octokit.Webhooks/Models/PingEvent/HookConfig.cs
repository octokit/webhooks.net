namespace Octokit.Webhooks.Models.PingEvent;

[PublicAPI]
public sealed record HookConfig
{
    [JsonPropertyName("content_type")]
    [JsonConverter(typeof(StringEnumConverter<HookConfigContentType>))]
    public required StringEnum<HookConfigContentType> ContentType { get; init; }

    [JsonPropertyName("secret")]
    public string? Secret { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("insecure_ssl")]
    public required string InsecureSsl { get; init; }
}
