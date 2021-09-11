namespace JamieMagee.Octokit.Webhooks.Events.ProjectCard
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record ProjectCardConvertedEvent : ProjectCardEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ProjectCardAction.Converted;
    }
}
