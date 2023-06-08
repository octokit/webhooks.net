namespace Octokit.Webhooks.Models.MetaEvent;

[PublicAPI]
public sealed record Hook
{
    [JsonPropertyName("type")]
    public string Type { get; init; } = null!;

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("active")]
    public bool Active { get; init; }

    [JsonPropertyName("events")]
    [JsonConverter(typeof(StringEnumEnumerableConverter<AppEvent>))]
    public IEnumerable<StringEnum<AppEvent>> Events { get; init; } = null!;

    [JsonPropertyName("config")]
    public HookConfig Config { get; init; } = null!;

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }
}
