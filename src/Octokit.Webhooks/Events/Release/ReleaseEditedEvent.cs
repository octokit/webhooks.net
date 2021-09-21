namespace Octokit.Webhooks.Events.Release
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models.ReleaseEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(ReleaseActionValue.Edited)]
    public sealed record ReleaseEditedEvent : ReleaseEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ReleaseAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
