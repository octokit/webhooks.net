namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public sealed record DependabotAlertFirstPatchedVersion
{
    [JsonPropertyName("identifier")]
    public required string Identifier { get; init; }
}
