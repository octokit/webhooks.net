namespace JamieMagee.Octokit.Webhooks.Models.PageBuildEvent
{
    using System.Text.Json.Serialization;

    public class BuildError
    {
        [JsonPropertyName("message")]
        public string? message { get; init; }
    }
}
