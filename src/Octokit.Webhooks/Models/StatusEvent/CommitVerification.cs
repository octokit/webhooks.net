namespace Octokit.Webhooks.Models.StatusEvent;

[PublicAPI]
public sealed record CommitVerification
{
    [JsonPropertyName("verified")]
    public bool Verified { get; init; }

    [JsonPropertyName("reason")]
    [JsonConverter(typeof(StringEnumConverter<CommitVerificationReason>))]
    public required StringEnum<CommitVerificationReason> Reason { get; init; }

    [JsonPropertyName("signature")]
    public string? Signature { get; init; }

    [JsonPropertyName("payload")]
    public string? Payload { get; init; }
}
