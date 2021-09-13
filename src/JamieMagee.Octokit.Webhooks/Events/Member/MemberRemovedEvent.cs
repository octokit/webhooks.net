namespace JamieMagee.Octokit.Webhooks.Events.Member
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(MemberActionValue.Removed)]
    public sealed record MemberRemovedEvent : MemberEvent
    {
        [JsonPropertyName("action")]
        public override string Action => MemberAction.Removed;
    }
}
