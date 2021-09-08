namespace JamieMagee.Octokit.Webhooks.Events.CheckRun
{
    using System.Text.Json.Serialization;

    public class CheckRunCreatedEvent : CheckRunEvent
    {
        [JsonPropertyName("action")]
        public override string Action => "created";
    }
}
