namespace Octokit.Webhooks.Models.RepositoryAdvisoryEvent;

[PublicAPI]
public sealed record RepositoryAdvisoryCreditDetailed
{
    [JsonPropertyName("user")]
    public User User { get; init; } = null!;

    [JsonPropertyName("type")]
    [JsonConverter(typeof(StringEnumConverter<RepositoryAdvisoryCreditType>))]
    public StringEnum<RepositoryAdvisoryCreditType> Type { get; init; } = null!;

    [JsonPropertyName("state")]
    [JsonConverter(typeof(StringEnumConverter<RepositoryAdvisoryCreditState>))]
    public StringEnum<RepositoryAdvisoryCreditState>? State { get; init; }
}
