namespace JamieMagee.Octokit.Webhooks.Models.MemberEvent
{
    using System.Text.Json.Serialization;

    public sealed record ChangesPermission
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    };
}
