namespace JamieMagee.Octokit.Webhooks.Models.MemberEvent
{
    using System.Text.Json.Serialization;

    public sealed record ChangesOldPermission
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    };
}
