namespace Octokit.Webhooks.Events.Member;

using Octokit.Webhooks.Models.MemberEvent;

[PublicAPI]
[WebhookActionType(MemberActionValue.Edited)]
public sealed record MemberEditedEvent : MemberEvent
{
    [JsonPropertyName("action")]
    public override string Action => MemberAction.Edited;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
