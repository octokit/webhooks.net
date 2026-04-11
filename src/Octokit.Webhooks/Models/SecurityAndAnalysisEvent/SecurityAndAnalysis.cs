namespace Octokit.Webhooks.Models.SecurityAndAnalysisEvent;

[PublicAPI]
public sealed record SecurityAndAnalysis
{
    [JsonPropertyName("advanced_security")]
    public SecurityFeature? AdvancedSecurity { get; init; }

    [JsonPropertyName("code_security")]
    public SecurityFeature? CodeSecurity { get; init; }

    [JsonPropertyName("dependabot_security_updates")]
    public SecurityFeature? DependabotSecurityUpdates { get; init; }

    [JsonPropertyName("secret_scanning")]
    public SecurityFeature? SecretScanning { get; init; }

    [JsonPropertyName("secret_scanning_push_protection")]
    public SecurityFeature? SecretScanningPushProtection { get; init; }

    [JsonPropertyName("secret_scanning_non_provider_patterns")]
    public SecurityFeature? SecretScanningNonProviderPatterns { get; init; }

    [JsonPropertyName("secret_scanning_ai_detection")]
    public SecurityFeature? SecretScanningAiDetection { get; init; }

    [JsonPropertyName("secret_scanning_delegated_alert_dismissal")]
    public SecurityFeature? SecretScanningDelegatedAlertDismissal { get; init; }

    [JsonPropertyName("secret_scanning_delegated_bypass")]
    public SecurityFeature? SecretScanningDelegatedBypass { get; init; }
}
