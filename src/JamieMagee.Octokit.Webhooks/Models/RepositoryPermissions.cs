namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public sealed record RepositoryPermissions
    {
        [JsonPropertyName("pull")]
        public bool Pull { get; set; }

        [JsonPropertyName("push")]
        public bool Push { get; set; }

        [JsonPropertyName("admin")]
        public bool Admin { get; set; }

        [JsonPropertyName("maintain")]
        public bool? Maintain { get; set; }

        [JsonPropertyName("triage")]
        public bool? Triage { get; set; }
    }
}
