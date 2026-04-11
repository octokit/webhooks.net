namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record DeploymentReviewReviewer
{
    [JsonPropertyName("type")]
    [JsonConverter(typeof(StringEnumConverter<ReviewerType>))]
    public required StringEnum<ReviewerType> Type { get; init; }

    // TODO: Correctly deserialize this property.
    // See https://github.com/octokit/webhooks.net/issues/278
    [JsonPropertyName("reviewer")]
    public required dynamic Reviewer { get; init; }
}
