namespace Octokit.Webhooks.Models.ProjectsV2StatusUpdateEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("body")]
    public ChangesField<string>? Body { get; init; }

    [JsonPropertyName("status")]
    public ChangesField<string>? Status { get; init; }

    [JsonPropertyName("start_date")]
    public ChangesField<string>? StartDate { get; init; }

    [JsonPropertyName("target_date")]
    public ChangesField<string>? TargetDate { get; init; }
}
