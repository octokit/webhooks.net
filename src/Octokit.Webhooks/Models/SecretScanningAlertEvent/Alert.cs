namespace Octokit.Webhooks.Models.SecretScanningAlertEvent;

[PublicAPI]
public sealed record Alert
{
    [JsonPropertyName("number")]
    public long Number { get; init; }

    [JsonPropertyName("secret_type")]
    public string SecretType { get; init; } = null!;

    [JsonPropertyName("resolution")]
    [JsonConverter(typeof(StringEnumConverter<AlertResolution>))]
    public StringEnum<AlertResolution>? Resolution { get; init; }

    [JsonPropertyName("resolved_by")]
    public User? ResolvedBy { get; init; }

    [JsonPropertyName("resolved_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? ResolvedAt { get; init; }
}
