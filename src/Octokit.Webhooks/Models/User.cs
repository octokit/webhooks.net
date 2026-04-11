namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record User
{
    [JsonPropertyName("login")]
    public required string Login { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string? NodeId { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonPropertyName("avatar_url")]
    public required string AvatarUrl { get; init; }

    [JsonPropertyName("gravatar_id")]
    public string? GravatarId { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("html_url")]
    public string? HtmlUrl { get; init; }

    [JsonPropertyName("followers_url")]
    public string? FollowersUrl { get; init; }

    [JsonPropertyName("following_url")]
    public string? FollowingUrl { get; init; }

    [JsonPropertyName("gists_url")]
    public string? GistsUrl { get; init; }

    [JsonPropertyName("starred_url")]
    public string? StarredUrl { get; init; }

    [JsonPropertyName("subscriptions_url")]
    public string? SubscriptionsUrl { get; init; }

    [JsonPropertyName("organizations_url")]
    public string? OrganizationsUrl { get; init; }

    [JsonPropertyName("repos_url")]
    public string? ReposUrl { get; init; }

    [JsonPropertyName("events_url")]
    public string? EventsUrl { get; init; }

    [JsonPropertyName("received_events_url")]
    public string? ReceivedEventsUrl { get; init; }

    [JsonPropertyName("type")]
    [JsonConverter(typeof(StringEnumConverter<UserType>))]
    public required StringEnum<UserType> Type { get; init; }

    [JsonPropertyName("site_admin")]
    public bool SiteAdmin { get; init; }
}
