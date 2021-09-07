namespace Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    public class PullRequestConvertedToDraftEvent : PullRequestEvent
    {
        [JsonPropertyName("action")] public override string Action => "converted_to_draft";
    }
}
