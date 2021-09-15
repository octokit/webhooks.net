namespace JamieMagee.Octokit.Webhooks.Events.Discussion
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(DiscussionActionValue.Unanswered)]
    public sealed record DiscussionUnansweredEvent : DiscussionEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DiscussionAction.Unanswered;

        [JsonPropertyName("old_answer")]
        public DiscussionAnswer OldAnswer { get; init; } = null!;
    }
}
