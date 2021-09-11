namespace JamieMagee.Octokit.Webhooks.Events.CheckSuite
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record CheckSuiteRerequestedEvent : CheckSuiteEvent
    {
        [JsonPropertyName("action")]
        public override string Action => CheckSuiteAction.Rerequested;
    }
}
