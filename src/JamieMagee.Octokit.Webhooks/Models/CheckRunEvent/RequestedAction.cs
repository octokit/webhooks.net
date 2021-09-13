namespace JamieMagee.Octokit.Webhooks.Models.CheckRunEvent
{
    using System.Text.Json.Serialization;

    public sealed record RequestedAction
    {
        [JsonPropertyName("identifier")]
        public string? Identifier { get; set; }
    }
}
