namespace Octokit.Webhooks.Models.CustomPropertyValuesEvent;

using System.Linq;

[PublicAPI]
public sealed record CustomPropertyValue
{
    [JsonPropertyName("property_name")]
    public string PropertyName { get; init; } = null!;

    [JsonPropertyName("value")]
    public object? Object { get; init; }

    public string? Value => this.Object switch
    {
        string str => str,
        IEnumerable<string> strings => "[" + string.Join(",", strings) + "]",
        JsonElement json when json.ValueKind is JsonValueKind.String => json.GetString(),
        JsonElement json when json.ValueKind is JsonValueKind.Array => "[" + string.Join(",", json.EnumerateArray().Select(e => e.GetString()!)) + "]",
        _ => null,
    };

    public IEnumerable<string>? Values => this.Object switch
    {
        string str => [str],
        IEnumerable<string> strings => strings,
        JsonElement json when json.ValueKind is JsonValueKind.String => [json.GetString()],
        JsonElement json when json.ValueKind is JsonValueKind.Array => json.EnumerateArray().Select(e => e.GetString()!),
        _ => null,
    };
}
