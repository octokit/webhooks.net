namespace Octokit.Webhooks.Models.MilestoneEvent;

using Octokit.Webhooks.Models.MemberEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("description")]
    public ChangesPermission? Description { get; init; }

    [JsonPropertyName("due_on")]
    public ChangesDueOn? DueOn { get; init; }

    [JsonPropertyName("title")]
    public ChangesTitle? Title { get; init; }
}
