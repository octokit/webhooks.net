namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record BypassActor
{
    [JsonPropertyName("actor_id")]
    public long ActorId { get; init; }

    [JsonPropertyName("actor_type")]
    [JsonConverter(typeof(StringEnumConverter<ActorType>))]
    public StringEnum<ActorType>? ActorType { get; init; }

    [JsonPropertyName("bypass_mode")]
    [JsonConverter(typeof(StringEnumConverter<BypassMode>))]
    public StringEnum<BypassMode>? BypassMode { get; init; }
}
