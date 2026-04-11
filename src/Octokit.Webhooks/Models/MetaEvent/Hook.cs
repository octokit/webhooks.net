namespace Octokit.Webhooks.Models.MetaEvent;

[PublicAPI]
public sealed record Hook
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("active")]
    public bool Active { get; init; }

    [JsonPropertyName("events")]
    [JsonConverter(typeof(StringEnumEnumerableConverter<AppEvent>))]
    public required IEnumerable<StringEnum<AppEvent>> Events { get; init; }

    [JsonPropertyName("config")]
    public required HookConfig Config { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }
}
