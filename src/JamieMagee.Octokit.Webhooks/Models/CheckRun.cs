namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class CheckRun
    {
        /// <summary>
        /// The id of the check.
        /// </summary>
        [JsonPropertyName("id")]
        public double Id { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; }

        /// <summary>
        /// The SHA of the commit that is being checked.
        /// </summary>
        [JsonPropertyName("head_sha")]
        public string HeadSha { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }

        [JsonPropertyName("details_url")]
        public string DetailsUrl { get; set; }

        /// <summary>
        /// The current status of the check run. Can be `queued`, `in_progress`, or `completed`.
        /// </summary>
        [JsonPropertyName("status")]
        public CheckRunStatus Status { get; set; }

        /// <summary>
        /// The result of the completed check run.
        /// This value will be `null` until the check run has completed.
        /// </summary>
        [JsonPropertyName("conclusion")]
        public CheckRunConclusion? Conclusion { get; set; }

        /// <summary>
        /// The time that the check run began. This is a timestamp in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format:
        /// `YYYY-MM-DDTHH:MM:SSZ`.
        /// </summary>
        [JsonPropertyName("started_at")]
        public string StartedAt { get; set; }

        /// <summary>
        /// The time the check completed. This is a timestamp in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format:
        /// `YYYY-MM-DDTHH:MM:SSZ`.
        /// </summary>
        [JsonPropertyName("completed_at")]
        public string CompletedAt { get; set; }

        [JsonPropertyName("output")]
        public CheckRunOutput Output { get; set; }

        /// <summary>
        /// The name of the check run.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
