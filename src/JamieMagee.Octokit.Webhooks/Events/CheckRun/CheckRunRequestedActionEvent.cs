namespace JamieMagee.Octokit.Webhooks.Events.CheckRun
{
    using System.Text.Json.Serialization;

    public class CheckRunRequestedActionEvent : CheckRunEvent
    {
        [JsonPropertyName("action")]
        public override string Action => "requested_action";
    }
}
