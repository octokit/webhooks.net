namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The set of permissions for the GitHub app
    /// </summary>
    public class AppPermissions
    {
        [JsonPropertyName("actions")]
        public AppPermissionsLevel? Actions { get; set; }

        [JsonPropertyName("administration")]
        public AppPermissionsLevel? Administration { get; set; }

        [JsonPropertyName("checks")]
        public AppPermissionsLevel? Checks { get; set; }

        [JsonPropertyName("content_references")]
        public AppPermissionsLevel? ContentReferences { get; set; }

        [JsonPropertyName("contents")]
        public AppPermissionsLevel? Contents { get; set; }

        [JsonPropertyName("deployments")]
        public AppPermissionsLevel? Deployments { get; set; }

        [JsonPropertyName("discussions")]
        public AppPermissionsLevel? Discussions { get; set; }

        [JsonPropertyName("emails")]
        public AppPermissionsLevel? Emails { get; set; }

        [JsonPropertyName("environments")]
        public AppPermissionsLevel? Environments { get; set; }

        [JsonPropertyName("issues")]
        public AppPermissionsLevel? Issues { get; set; }

        [JsonPropertyName("members")]
        public AppPermissionsLevel? Members { get; set; }

        [JsonPropertyName("metadata")]
        public AppPermissionsLevel? Metadata { get; set; }

        [JsonPropertyName("organization_administration")]
        public AppPermissionsLevel? OrganizationAdministration { get; set; }

        [JsonPropertyName("organization_hooks")]
        public AppPermissionsLevel? OrganizationHooks { get; set; }

        [JsonPropertyName("organization_packages")]
        public AppPermissionsLevel? OrganizationPackages { get; set; }

        [JsonPropertyName("organization_plan")]
        public AppPermissionsLevel? OrganizationPlan { get; set; }

        [JsonPropertyName("organization_projects")]
        public AppPermissionsLevel? OrganizationProjects { get; set; }

        [JsonPropertyName("organization_secrets")]
        public AppPermissionsLevel? OrganizationSecrets { get; set; }

        [JsonPropertyName("organization_self_hosted_runners")]
        public AppPermissionsLevel? OrganizationSelfHostedRunners { get; set; }

        [JsonPropertyName("organization_user_blocking")]
        public AppPermissionsLevel? OrganizationUserBlocking { get; set; }

        [JsonPropertyName("packages")]
        public AppPermissionsLevel? Packages { get; set; }

        [JsonPropertyName("pages")]
        public AppPermissionsLevel? Pages { get; set; }

        [JsonPropertyName("pull_requests")]
        public AppPermissionsLevel? PullRequests { get; set; }

        [JsonPropertyName("repository_hooks")]
        public AppPermissionsLevel? RepositoryHooks { get; set; }

        [JsonPropertyName("repository_projects")]
        public AppPermissionsLevel? RepositoryProjects { get; set; }

        [JsonPropertyName("secret_scanning_alerts")]
        public AppPermissionsLevel? SecretScanningAlerts { get; set; }

        [JsonPropertyName("secrets")]
        public AppPermissionsLevel? Secrets { get; set; }

        [JsonPropertyName("security_events")]
        public AppPermissionsLevel? SecurityEvents { get; set; }

        [JsonPropertyName("security_scanning_alert")]
        public AppPermissionsLevel? SecurityScanningAlert { get; set; }

        [JsonPropertyName("single_file")]
        public AppPermissionsLevel? SingleFile { get; set; }

        [JsonPropertyName("statuses")]
        public AppPermissionsLevel? Statuses { get; set; }

        [JsonPropertyName("team_discussions")]
        public AppPermissionsLevel? TeamDiscussions { get; set; }

        [JsonPropertyName("vulnerability_alerts")]
        public AppPermissionsLevel? VulnerabilityAlerts { get; set; }

        [JsonPropertyName("workflows")]
        public AppPermissionsLevel? Workflows { get; set; }
    }
}
