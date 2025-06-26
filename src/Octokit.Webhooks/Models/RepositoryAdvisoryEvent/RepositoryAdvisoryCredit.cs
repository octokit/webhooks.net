namespace Octokit.Webhooks.Models.RepositoryAdvisoryEvent;

[PublicAPI]
public sealed record RepositoryAdvisoryCredit
{
    [JsonPropertyName("login")]
    public string Login { get; init; } = null!;

    [JsonPropertyName("type")]
    [JsonConverter(typeof(StringEnumConverter<RepositoryAdvisoryCreditType>))]
    public StringEnum<RepositoryAdvisoryCreditType> Type { get; init; } = null!;
}
