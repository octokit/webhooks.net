namespace JamieMagee.Octokit.Webhooks.Events.Release
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record ReleaseEditedEvent : ReleaseEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ReleaseAction.Edited;
    }
}
