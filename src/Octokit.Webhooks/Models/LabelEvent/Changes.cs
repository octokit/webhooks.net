namespace Octokit.Webhooks.Models.LabelEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("color")]
    public required ChangesColor Color { get; init; }

    [JsonPropertyName("name")]
    public ChangesName? Name { get; init; }

    [JsonPropertyName("description")]
    public ChangesDescription? Description { get; init; }
}
