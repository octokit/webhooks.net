namespace Octokit.Webhooks.Events.Member;

using Octokit.Webhooks.Models.MemberEvent;

[PublicAPI]
[WebhookActionType(MemberActionValue.Added)]
public sealed record MemberAddedEvent : MemberEvent
{
    [JsonPropertyName("action")]
    public override string Action => MemberAction.Added;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
