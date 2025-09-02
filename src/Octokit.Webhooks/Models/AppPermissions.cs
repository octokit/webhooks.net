namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record AppPermissions
{
    [JsonPropertyName("actions")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Actions { get; init; }

    [JsonPropertyName("administration")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Administration { get; init; }

    [JsonPropertyName("blocking")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Blocking { get; init; }

    [JsonPropertyName("checks")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Checks { get; init; }

    [JsonPropertyName("content_references")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? ContentReferences { get; init; }

    [JsonPropertyName("contents")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Contents { get; init; }

    [JsonPropertyName("deployments")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Deployments { get; init; }

    [JsonPropertyName("discussions")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Discussions { get; init; }

    [JsonPropertyName("emails")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Emails { get; init; }

    [JsonPropertyName("environments")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Environments { get; init; }

    [JsonPropertyName("followers")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Followers { get; init; }

    [JsonPropertyName("gpg_keys")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? GpgKeys { get; init; }

    [JsonPropertyName("interaction_limits")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? InteractionLimits { get; init; }

    [JsonPropertyName("issues")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Issues { get; init; }

    [JsonPropertyName("keys")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Keys { get; init; }

    [JsonPropertyName("members")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Members { get; init; }

    [JsonPropertyName("merge_queues")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? MergeQueues { get; init; }

    [JsonPropertyName("metadata")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Metadata { get; init; }

    [JsonPropertyName("organization_administration")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? OrganizationAdministration { get; init; }

    [JsonPropertyName("organization_custom_properties")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? OrganizationCustomProperties { get; init; }

    [JsonPropertyName("organization_hooks")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? OrganizationHooks { get; init; }

    [JsonPropertyName("organization_packages")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? OrganizationPackages { get; init; }

    [JsonPropertyName("organization_plan")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? OrganizationPlan { get; init; }

    [JsonPropertyName("organization_projects")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? OrganizationProjects { get; init; }

    [JsonPropertyName("organization_secrets")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? OrganizationSecrets { get; init; }

    [JsonPropertyName("organization_self_hosted_runners")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? OrganizationSelfHostedRunners { get; init; }

    [JsonPropertyName("organization_user_blocking")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? OrganizationUserBlocking { get; init; }

    [JsonPropertyName("packages")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Packages { get; init; }

    [JsonPropertyName("pages")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Pages { get; init; }

    [JsonPropertyName("plan")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Plan { get; init; }

    [JsonPropertyName("pull_requests")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? PullRequests { get; init; }

    [JsonPropertyName("repository_custom_properties")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? RepositoryCustomProperties { get; init; }

    [JsonPropertyName("repository_hooks")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? RepositoryHooks { get; init; }

    [JsonPropertyName("repository_projects")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? RepositoryProjects { get; init; }

    [JsonPropertyName("secret_scanning_alerts")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? SecretScanningAlerts { get; init; }

    [JsonPropertyName("secrets")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Secrets { get; init; }

    [JsonPropertyName("security_events")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? SecurityEvents { get; init; }

    [JsonPropertyName("security_scanning_alert")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? SecurityScanningAlert { get; init; }

    [JsonPropertyName("single_file")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? SingleFile { get; init; }

    [JsonPropertyName("starring")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Starring { get; init; }

    [JsonPropertyName("statuses")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Statuses { get; init; }

    [JsonPropertyName("team_discussions")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? TeamDiscussions { get; init; }

    [JsonPropertyName("vulnerability_alerts")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? VulnerabilityAlerts { get; init; }

    [JsonPropertyName("watching")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Watching { get; init; }

    [JsonPropertyName("workflows")]
    [JsonConverter(typeof(StringEnumConverter<AppPermissionsLevel>))]
    public StringEnum<AppPermissionsLevel>? Workflows { get; init; }
}
