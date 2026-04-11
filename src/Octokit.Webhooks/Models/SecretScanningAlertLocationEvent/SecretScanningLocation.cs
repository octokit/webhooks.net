namespace Octokit.Webhooks.Models.SecretScanningAlertLocationEvent;

[PublicAPI]
public sealed record SecretScanningLocation
{
    [JsonPropertyName("type")]
    [JsonConverter(typeof(StringEnumConverter<SecretScanningLocationType>))]
    public required StringEnum<SecretScanningLocationType> Type { get; init; }

    // TODO: type union with SecretScanningLocationCommit, SecretScanningLocationIssueBody, etc.
    [JsonPropertyName("details")]
    public required JsonElement Details { get; init; }
}
