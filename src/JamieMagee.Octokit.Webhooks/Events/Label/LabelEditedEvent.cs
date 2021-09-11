namespace JamieMagee.Octokit.Webhooks.Events.Label
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record LabelEditedEvent : LabelEvent
    {
        [JsonPropertyName("action")]
        public override string Action => LabelAction.Edited;
    }
}
