namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record PatternParameters
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("negate")]
    public bool? Negate { get; init; }

    [JsonPropertyName("operator")]
    [JsonConverter(typeof(StringEnumConverter<RefType>))]
    public StringEnum<PatternOperator>? Operator { get; init; }

    [JsonPropertyName("pattern")]
    public string? Pattern { get; init; }
}
