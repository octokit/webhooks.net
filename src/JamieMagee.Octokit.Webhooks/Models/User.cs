namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public sealed record User
    {
        [JsonPropertyName("email")]
        public string? Email { get; init; }

        [JsonPropertyName("login")]
        public string Login { get; init; } = null!;

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; init; } = null!;

        [JsonPropertyName("gravatar_id")]
        public string GravatarId { get; init; } = null!;

        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; } = null!;

        [JsonPropertyName("followers_url")]
        public string FollowersUrl { get; init; } = null!;

        [JsonPropertyName("following_url")]
        public string FollowingUrl { get; init; } = null!;

        [JsonPropertyName("gists_url")]
        public string GistsUrl { get; init; } = null!;

        [JsonPropertyName("starred_url")]
        public string StarredUrl { get; init; } = null!;

        [JsonPropertyName("subscriptions_url")]
        public string SubscriptionsUrl { get; init; } = null!;

        [JsonPropertyName("organizations_url")]
        public string OrganizationsUrl { get; init; } = null!;

        [JsonPropertyName("repos_url")]
        public string ReposUrl { get; init; } = null!;

        [JsonPropertyName("events_url")]
        public string EventsUrl { get; init; } = null!;

        [JsonPropertyName("received_events_url")]
        public string ReceivedEventsUrl { get; init; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("name")]
        public string? Name { get; init; }

        [JsonPropertyName("type")]
        public UserType Type { get; init; }

        [JsonPropertyName("site_admin")]
        public bool SiteAdmin { get; init; }
    }
}
