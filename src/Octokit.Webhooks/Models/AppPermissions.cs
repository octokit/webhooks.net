namespace Octokit.Webhooks.Models;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record AppPermissions
{
    [JsonPropertyName("actions")]
    public AppPermissionsLevel? Actions { get; init; }

    [JsonPropertyName("administration")]
    public AppPermissionsLevel? Administration { get; init; }

    [JsonPropertyName("checks")]
    public AppPermissionsLevel? Checks { get; init; }

    [JsonPropertyName("content_references")]
    public AppPermissionsLevel? ContentReferences { get; init; }

    [JsonPropertyName("contents")]
    public AppPermissionsLevel? Contents { get; init; }

    [JsonPropertyName("deployments")]
    public AppPermissionsLevel? Deployments { get; init; }

    [JsonPropertyName("discussions")]
    public AppPermissionsLevel? Discussions { get; init; }

    [JsonPropertyName("emails")]
    public AppPermissionsLevel? Emails { get; init; }

    [JsonPropertyName("environments")]
    public AppPermissionsLevel? Environments { get; init; }

    [JsonPropertyName("issues")]
    public AppPermissionsLevel? Issues { get; init; }

    [JsonPropertyName("members")]
    public AppPermissionsLevel? Members { get; init; }

    [JsonPropertyName("merge_queues")]
    public AppPermissionsLevel? MergeQueues { get; init; }

    [JsonPropertyName("metadata")]
    public AppPermissionsLevel? Metadata { get; init; }

    [JsonPropertyName("organization_administration")]
    public AppPermissionsLevel? OrganizationAdministration { get; init; }

    [JsonPropertyName("organization_hooks")]
    public AppPermissionsLevel? OrganizationHooks { get; init; }

    [JsonPropertyName("organization_packages")]
    public AppPermissionsLevel? OrganizationPackages { get; init; }

    [JsonPropertyName("organization_plan")]
    public AppPermissionsLevel? OrganizationPlan { get; init; }

    [JsonPropertyName("organization_projects")]
    public AppPermissionsLevel? OrganizationProjects { get; init; }

    [JsonPropertyName("organization_secrets")]
    public AppPermissionsLevel? OrganizationSecrets { get; init; }

    [JsonPropertyName("organization_self_hosted_runners")]
    public AppPermissionsLevel? OrganizationSelfHostedRunners { get; init; }

    [JsonPropertyName("organization_user_blocking")]
    public AppPermissionsLevel? OrganizationUserBlocking { get; init; }

    [JsonPropertyName("packages")]
    public AppPermissionsLevel? Packages { get; init; }

    [JsonPropertyName("pages")]
    public AppPermissionsLevel? Pages { get; init; }

    [JsonPropertyName("pull_requests")]
    public AppPermissionsLevel? PullRequests { get; init; }

    [JsonPropertyName("repository_hooks")]
    public AppPermissionsLevel? RepositoryHooks { get; init; }

    [JsonPropertyName("repository_projects")]
    public AppPermissionsLevel? RepositoryProjects { get; init; }

    [JsonPropertyName("secret_scanning_alerts")]
    public AppPermissionsLevel? SecretScanningAlerts { get; init; }

    [JsonPropertyName("secrets")]
    public AppPermissionsLevel? Secrets { get; init; }

    [JsonPropertyName("security_events")]
    public AppPermissionsLevel? SecurityEvents { get; init; }

    [JsonPropertyName("security_scanning_alert")]
    public AppPermissionsLevel? SecurityScanningAlert { get; init; }

    [JsonPropertyName("single_file")]
    public AppPermissionsLevel? SingleFile { get; init; }

    [JsonPropertyName("statuses")]
    public AppPermissionsLevel? Statuses { get; init; }

    [JsonPropertyName("team_discussions")]
    public AppPermissionsLevel? TeamDiscussions { get; init; }

    [JsonPropertyName("vulnerability_alerts")]
    public AppPermissionsLevel? VulnerabilityAlerts { get; init; }

    [JsonPropertyName("workflows")]
    public AppPermissionsLevel? Workflows { get; init; }
}
