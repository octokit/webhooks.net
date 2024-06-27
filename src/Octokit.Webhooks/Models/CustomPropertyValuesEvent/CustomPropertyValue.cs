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
        JsonElement { ValueKind: JsonValueKind.String } json => json.GetString(),
        JsonElement { ValueKind: JsonValueKind.Array } json => "[" + string.Join(",", json.EnumerateArray().Select(e => e.GetString()!)) + "]",
        _ => null,
    };

    public IEnumerable<string>? Values => this.Object switch
    {
        string str => [str],
        IEnumerable<string> strings => strings,
        JsonElement { ValueKind: JsonValueKind.String } json => [json.GetString()!],
        JsonElement { ValueKind: JsonValueKind.Array } json => json.EnumerateArray().Select(e => e.GetString()!),
        _ => null,
    };
}
