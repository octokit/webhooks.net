namespace Octokit.Webhooks.Models.StatusEvent;

[PublicAPI]
public sealed record CommitVerification
{
    [JsonPropertyName("verified")]
    public bool Verified { get; init; }

    [JsonPropertyName("reason")]
    [JsonConverter(typeof(StringEnumConverter<CommitVerificationReason>))]
    public StringEnum<CommitVerificationReason> Reason { get; init; } = null!;

    [JsonPropertyName("signature")]
    public string? Signature { get; init; }

    [JsonPropertyName("payload")]
    public string? Payload { get; init; }
}
