namespace JamieMagee.Octokit.Webhooks.Events.CheckRun
{
    using System.Text.Json.Serialization;

    public class CheckRunCompletedEvent : CheckRunEvent
    {
        [JsonPropertyName("action")]
        public override string Action => "completed";
    }
}
