namespace JamieMagee.Octokit.Webhooks.Events.Release
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.ReleaseEvent;

    [WebhookActionType(ReleaseActionValue.Edited)]
    public sealed record ReleaseEditedEvent : ReleaseEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ReleaseAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
