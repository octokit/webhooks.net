namespace Octokit.Webhooks.Events.Member
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(MemberActionValue.Removed)]
    public sealed record MemberRemovedEvent : MemberEvent
    {
        [JsonPropertyName("action")]
        public override string Action => MemberAction.Removed;
    }
}
