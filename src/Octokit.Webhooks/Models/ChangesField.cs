namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record ChangesField<T>
{
    [JsonPropertyName("from")]
    public T? From { get; init; }

    [JsonPropertyName("to")]
    public T? To { get; init; }
}
