namespace Octokit.Webhooks.Models.PingEvent;

[PublicAPI]
public sealed record HookLastResponse
{
    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("status")]
    public required string Status { get; init; }

    [JsonPropertyName("message")]
    public string? Message { get; init; }
}
