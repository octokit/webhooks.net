namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using Models;

    public class PullRequestUnlabeledEvent : PullRequestEvent
    {
        [JsonPropertyName("action")] public override string Action => "unlabeled";

        [JsonPropertyName("label")] public Label Label { get; set; } = null!;
    }
}
