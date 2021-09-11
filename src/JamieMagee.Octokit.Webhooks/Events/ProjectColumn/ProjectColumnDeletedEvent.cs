namespace JamieMagee.Octokit.Webhooks.Events.ProjectColumn
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record ProjectColumnDeletedEvent : ProjectColumnEvent
    {
        [JsonPropertyName("action")]
        public override string Action => ProjectColumnAction.Deleted;
    }
}
