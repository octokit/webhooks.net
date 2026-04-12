namespace Octokit.Webhooks.Models.PingEvent;

[PublicAPI]
public sealed record Hook
{
    [JsonPropertyName("type")]
    [JsonConverter(typeof(StringEnumConverter<HookType>))]
    public required StringEnum<HookType> Type { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("active")]
    public bool Active { get; init; }

    [JsonPropertyName("app_id")]
    public int? AppId { get; init; }

    [JsonPropertyName("events")]
    [JsonConverter(typeof(StringEnumReadOnlyListConverter<AppEvent>))]
    public required IReadOnlyList<StringEnum<AppEvent>> Events { get; init; }

    [JsonPropertyName("config")]
    public required HookConfig Config { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("test_url")]
    public string? TestUrl { get; init; }

    [JsonPropertyName("ping_url")]
    public required string PingUrl { get; init; }

    [JsonPropertyName("deliveries_url")]
    public required string DeliveriesUrl { get; init; }

    [JsonPropertyName("last_response")]
    public HookLastResponse? LastResponse { get; init; }
}
