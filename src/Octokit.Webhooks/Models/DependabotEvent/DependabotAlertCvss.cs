namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public sealed record DependabotAlertCvss
{
    [JsonPropertyName("vector_string")]
    public string? VectorString { get; init; }

    [JsonPropertyName("score")]
    public float Score { get; init; }
}
