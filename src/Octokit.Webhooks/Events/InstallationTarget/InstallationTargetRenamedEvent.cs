namespace Octokit.Webhooks.Events.InstallationTarget;

using Octokit.Webhooks.Models.InstallationTargetEvent;

[PublicAPI]
[WebhookActionType(InstallationTargetActionValue.Renamed)]
public sealed record InstallationTargetRenamedEvent : InstallationTargetEvent
{
    [JsonPropertyName("action")]
    public override string Action => InstallationTargetActionValue.Renamed;

    [JsonPropertyName("account")]
    public User Account { get; init; } = null!;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;

    [JsonPropertyName("target_type")]
    [JsonConverter(typeof(StringEnumConverter<InstallationTargetType>))]
    public StringEnum<InstallationTargetType> TargetType { get; init; } = null!;
}
