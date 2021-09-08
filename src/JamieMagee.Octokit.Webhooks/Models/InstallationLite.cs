namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class InstallationLite
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("node_id")] public string NodeId { get; set; } = null!;
    }
}
