namespace JamieMagee.Octokit.Webhooks.Events.Team
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(TeamActionValue.AddedToRepository)]
    public sealed record TeamAddedToRepositoryEvent : TeamEvent
    {
        [JsonPropertyName("action")]
        public override string Action => TeamAction.AddedToRepository;
    }
}
