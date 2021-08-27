namespace Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using Models;

    public class PullRequestLabeledEvent : PullRequestEvent
    {
        [JsonPropertyName("action")] public override string Action => "labeled";

        [JsonPropertyName("label")] public Label Label { get; set; } = null!;
    }
}
