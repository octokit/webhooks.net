namespace JamieMagee.Octokit.Webhooks.Models.PageBuildEvent
{
    using System.Text.Json.Serialization;

    public sealed record BuildError
    {
        [JsonPropertyName("message")]
        public string? message { get; init; }
    }
}
