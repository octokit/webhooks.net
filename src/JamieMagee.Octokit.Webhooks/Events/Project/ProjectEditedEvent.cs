namespace JamieMagee.Octokit.Webhooks.Events.Project
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record ProjectEditedEvent : ProjectEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ProjectAction.Edited;
    }
}
