namespace Octokit.Webhooks.Models.RepositoryAdvisoryEvent;

[PublicAPI]
public sealed record RepositoryAdvisoryCredit
{
    [JsonPropertyName("login")]
    public required string Login { get; init; }

    [JsonPropertyName("type")]
    [JsonConverter(typeof(StringEnumConverter<RepositoryAdvisoryCreditType>))]
    public required StringEnum<RepositoryAdvisoryCreditType> Type { get; init; }
}
