namespace Octokit.Webhooks.Models.ProjectColumnEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("name")]
    public ChangesName? Name { get; init; }
}
