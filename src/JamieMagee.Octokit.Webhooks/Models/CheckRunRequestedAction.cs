namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class CheckRunRequestedAction
    {
        /// <summary>
        /// The integrator reference of the action requested by the user.
        /// </summary>
        [JsonPropertyName("identifier")]
        public string? Identifier { get; set; }
    }
}
