namespace Octokit.Webhooks.Events.InstallationTarget;

using Octokit.Webhooks.Models.InstallationTargetEvent;

[PublicAPI]
[WebhookActionType(InstallationTargetActionValue.Renamed)]
public sealed record InstallationTargetRenamedEvent : InstallationTargetEvent
{
    [JsonPropertyName("action")]
    public override string Action => InstallationTargetActionValue.Renamed;

    [JsonPropertyName("account")]
    public required User Account { get; init; }

    [JsonPropertyName("changes")]
    public required Changes Changes { get; init; }

    [JsonPropertyName("target_type")]
    [JsonConverter(typeof(StringEnumConverter<InstallationTargetType>))]
    public required StringEnum<InstallationTargetType> TargetType { get; init; }
}
