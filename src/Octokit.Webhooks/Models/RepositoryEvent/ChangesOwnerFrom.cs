namespace Octokit.Webhooks.Models.RepositoryEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record ChangesOwnerFrom
    {
        [JsonPropertyName("user")]
        public User? User { get; init; }
    };
}
