namespace Octokit.Webhooks.Models.CodeScanningAlertEvent;

[PublicAPI]
public sealed record AlertInstance
{
    [JsonPropertyName("ref")]
    public required string Ref { get; init; }

    [JsonPropertyName("analysis_key")]
    public required string AnalysisKey { get; init; }

    [JsonPropertyName("environment")]
    public required string Environment { get; init; }

    [JsonPropertyName("state")]
    [JsonConverter(typeof(StringEnumConverter<AlertState>))]
    public required StringEnum<AlertState> State { get; init; }

    [JsonPropertyName("commit_sha")]
    public string? CommitSha { get; init; }

    [JsonPropertyName("message")]
    public AlertInstanceMessage? Message { get; init; }

    [JsonPropertyName("location")]
    public AlertInstanceLocation? Location { get; init; }

    [JsonPropertyName("classifications")]
    public IReadOnlyList<string>? Classifications { get; init; }
}
