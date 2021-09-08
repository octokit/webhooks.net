namespace JamieMagee.Octokit.Webhooks.Events.CheckRun
{
    using System.Text.Json.Serialization;

    public class CheckRunRerequestedEvent : CheckRunEvent
    {
        [JsonPropertyName("action")]
        public override string Action => "rerequested";
    }
}
