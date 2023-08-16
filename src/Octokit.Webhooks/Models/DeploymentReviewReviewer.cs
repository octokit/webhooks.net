namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record DeploymentReviewReviewer
{
    [JsonPropertyName("type")]
    [JsonConverter(typeof(StringEnumConverter<ReviewerType>))]
    public StringEnum<ReviewerType> Type { get; init; } = null!;

    // TODO: Correctly deserialize this property.
    // See https://github.com/octokit/webhooks.net/issues/278
    [JsonPropertyName("reviewer")]
    public dynamic Reviewer { get; init; } = null!;
}
