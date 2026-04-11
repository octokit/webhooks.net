namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.SecretScanningScan)]
[JsonConverter(typeof(WebhookConverter<SecretScanningScanEvent>))]
public abstract record SecretScanningScanEvent : WebhookEvent
{
    [JsonPropertyName("type")]
    public string Type { get; init; } = null!;

    [JsonPropertyName("source")]
    public string Source { get; init; } = null!;

    [JsonPropertyName("started_at")]
    public string StartedAt { get; init; } = null!;

    [JsonPropertyName("completed_at")]
    public string CompletedAt { get; init; } = null!;

    [JsonPropertyName("secret_types")]
    public IEnumerable<string>? SecretTypes { get; init; }

    [JsonPropertyName("custom_pattern_name")]
    public string? CustomPatternName { get; init; }

    [JsonPropertyName("custom_pattern_scope")]
    public string? CustomPatternScope { get; init; }
}
