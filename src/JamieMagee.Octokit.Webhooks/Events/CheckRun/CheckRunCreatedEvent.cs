namespace JamieMagee.Octokit.Webhooks.Events.CheckRun
{
    using System.Text.Json.Serialization;

    public sealed record CheckRunCreatedEvent : CheckRunEvent
    {
        [JsonPropertyName("action")]
        public override string Action => CheckRunEventAction.Created;
    }
}
