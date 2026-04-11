namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.SecretScanningScan)]
[JsonConverter(typeof(WebhookConverter<SecretScanningScanEvent>))]
public abstract record SecretScanningScanEvent : WebhookEvent
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("source")]
    public required string Source { get; init; }

    [JsonPropertyName("started_at")]
    public DateTimeOffset StartedAt { get; init; }

    [JsonPropertyName("completed_at")]
    public DateTimeOffset CompletedAt { get; init; }

    [JsonPropertyName("secret_types")]
    public IReadOnlyList<string>? SecretTypes { get; init; }

    [JsonPropertyName("custom_pattern_name")]
    public string? CustomPatternName { get; init; }

    [JsonPropertyName("custom_pattern_scope")]
    public string? CustomPatternScope { get; init; }
}
