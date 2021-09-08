namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class User
    {
        [JsonPropertyName("email")] public string? Email;

        [JsonPropertyName("login")] public string Login { get; set; } = null!;

        [JsonPropertyName("node_id")] public string NodeId { get; set; } = null!;

        [JsonPropertyName("avatar_url")] public string AvatarUrl { get; set; } = null!;

        [JsonPropertyName("gravatar_id")] public string GravatarId { get; set; } = null!;

        [JsonPropertyName("url")] public string Url { get; set; } = null!;

        [JsonPropertyName("html_url")] public string HtmlUrl { get; set; } = null!;

        [JsonPropertyName("followers_url")] public string FollowersUrl { get; set; } = null!;

        [JsonPropertyName("following_url")] public string FollowingUrl { get; set; } = null!;

        [JsonPropertyName("gists_url")] public string GistsUrl { get; set; } = null!;

        [JsonPropertyName("starred_url")] public string StarredUrl { get; set; } = null!;

        [JsonPropertyName("subscriptions_url")]
        public string SubscriptionsUrl { get; set; } = null!;

        [JsonPropertyName("organizations_url")]
        public string OrganizationsUrl { get; set; } = null!;

        [JsonPropertyName("repos_url")] public string ReposUrl { get; set; } = null!;

        [JsonPropertyName("events_url")] public string EventsUrl { get; set; } = null!;

        [JsonPropertyName("received_events_url")]
        public string ReceivedEventsUrl { get; set; } = null!;

        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("name")] public string? Name { get; set; }

        [JsonPropertyName("type")] public UserType Type { get; set; }

        [JsonPropertyName("site_admin")] public bool SiteAdmin { get; set; }
    }
}
