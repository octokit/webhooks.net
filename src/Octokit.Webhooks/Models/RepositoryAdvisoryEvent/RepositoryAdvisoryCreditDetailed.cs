namespace Octokit.Webhooks.Models.RepositoryAdvisoryEvent;

[PublicAPI]
public sealed record RepositoryAdvisoryCreditDetailed
{
    [JsonPropertyName("user")]
    public required User User { get; init; }

    [JsonPropertyName("type")]
    [JsonConverter(typeof(StringEnumConverter<RepositoryAdvisoryCreditType>))]
    public required StringEnum<RepositoryAdvisoryCreditType> Type { get; init; }

    [JsonPropertyName("state")]
    [JsonConverter(typeof(StringEnumConverter<RepositoryAdvisoryCreditState>))]
    public StringEnum<RepositoryAdvisoryCreditState>? State { get; init; }
}
