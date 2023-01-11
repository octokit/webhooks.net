namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public class DependabotAlertFirstPatchedVersion
{
    [JsonPropertyName("identifier")]
    public string Identifier { get; init; } = null!;
}
