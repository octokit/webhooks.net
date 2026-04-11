namespace Octokit.Webhooks.Models.DeploymentEvent;

[PublicAPI]
public sealed record DeploymentCheckRun
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("head_sha")]
    public required string HeadSha { get; init; }

    [JsonPropertyName("external_id")]
    public required string ExternalId { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("details_url")]
    public required string DetailsUrl { get; init; }

    [JsonPropertyName("status")]
    [JsonConverter(typeof(StringEnumConverter<DeploymentCheckRunStatus>))]
    public required StringEnum<DeploymentCheckRunStatus> Status { get; init; }

    [JsonPropertyName("conclusion")]
    [JsonConverter(typeof(StringEnumConverter<DeploymentCheckRunConclusion>))]
    public StringEnum<DeploymentCheckRunConclusion>? Conclusion { get; init; }

    [JsonPropertyName("started_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset StartedAt { get; init; }

    [JsonPropertyName("completed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? CompletedAt { get; init; }
}
