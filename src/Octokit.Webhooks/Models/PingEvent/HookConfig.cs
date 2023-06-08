namespace Octokit.Webhooks.Models.PingEvent;

[PublicAPI]
public sealed record HookConfig
{
    [JsonPropertyName("content_type")]
    [JsonConverter(typeof(StringEnumConverter<HookConfigContentType>))]
    public StringEnum<HookConfigContentType> ContentType { get; init; } = null!;

    [JsonPropertyName("secret")]
    public string? Secret { get; init; }

    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("insecure_ssl")]
    public string InsecureSsl { get; init; } = null!;
}
