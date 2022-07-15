namespace Octokit.Webhooks.Models.SecretScanningAlertLocationEvent;

[PublicAPI]
public sealed record SecretScanningLocation
{
    [JsonPropertyName("type")]
    [JsonConverter(typeof(StringEnumConverter<SecretScanningLocationType>))]
    public StringEnum<SecretScanningLocationType> Type { get; init; } = null!;

    // TODO: type union with SecretScanningLocationCommit, SecretScanningLocationIssueBody, etc.
    [JsonPropertyName("details")]
    public dynamic Details { get; init; } = null!;
}
