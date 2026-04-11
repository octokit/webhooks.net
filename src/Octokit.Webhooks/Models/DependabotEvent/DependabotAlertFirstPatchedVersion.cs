namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public class DependabotAlertFirstPatchedVersion
{
    [JsonPropertyName("identifier")]
    public required string Identifier { get; init; }
}
