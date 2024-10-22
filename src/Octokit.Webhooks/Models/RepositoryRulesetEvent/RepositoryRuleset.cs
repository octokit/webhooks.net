namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record RepositoryRuleset
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("target")]
    [JsonConverter(typeof(StringEnumConverter<Target>))]
    public StringEnum<Target>? Target { get; init; }

    [JsonPropertyName("source_type")]
    [JsonConverter(typeof(StringEnumConverter<SourceType>))]
    public StringEnum<SourceType>? SourceType { get; init; }

    [JsonPropertyName("source")]
    public string? Source { get; init; }

    [JsonPropertyName("enforcement")]
    [JsonConverter(typeof(StringEnumConverter<Enforcement>))]
    public StringEnum<Enforcement>? Enforcement { get; init; }

    [JsonPropertyName("bypass_actors")]
    public IReadOnlyCollection<BypassActor>? BypassActors { get; init; }

    [JsonPropertyName("current_user_can_bypass")]
    [JsonConverter(typeof(StringEnumConverter<CurrentUserCanBypass>))]
    public StringEnum<CurrentUserCanBypass>? CurrentUserCanBypass { get; init; }

    [JsonPropertyName("node_id")]
    public string? NodeId { get; init; }

    [JsonPropertyName("conditions")]
    public Conditions? Conditions { get; init; }

    [JsonPropertyName("rules")]
    public IReadOnlyCollection<Rule>? Rules { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? UpdatedAt { get; init; }
}
