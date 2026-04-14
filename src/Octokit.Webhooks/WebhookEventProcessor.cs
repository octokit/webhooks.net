namespace Octokit.Webhooks;

using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Octokit.Webhooks.Events;
using Octokit.Webhooks.Events.BranchProtectionConfiguration;
using Octokit.Webhooks.Events.BranchProtectionRule;
using Octokit.Webhooks.Events.CheckRun;
using Octokit.Webhooks.Events.CheckSuite;
using Octokit.Webhooks.Events.CodeScanningAlert;
using Octokit.Webhooks.Events.CommitComment;
using Octokit.Webhooks.Events.ContentReference;
using Octokit.Webhooks.Events.CustomProperty;
using Octokit.Webhooks.Events.CustomPropertyPromotedToEnterprise;
using Octokit.Webhooks.Events.CustomPropertyValues;
using Octokit.Webhooks.Events.DependabotAlert;
using Octokit.Webhooks.Events.DeployKey;
using Octokit.Webhooks.Events.Deployment;
using Octokit.Webhooks.Events.DeploymentProtectionRule;
using Octokit.Webhooks.Events.DeploymentReview;
using Octokit.Webhooks.Events.DeploymentStatus;
using Octokit.Webhooks.Events.Discussion;
using Octokit.Webhooks.Events.DiscussionComment;
using Octokit.Webhooks.Events.GithubAppAuthorization;
using Octokit.Webhooks.Events.Installation;
using Octokit.Webhooks.Events.InstallationRepositories;
using Octokit.Webhooks.Events.InstallationTarget;
using Octokit.Webhooks.Events.IssueComment;
using Octokit.Webhooks.Events.IssueDependencies;
using Octokit.Webhooks.Events.Issues;
using Octokit.Webhooks.Events.Label;
using Octokit.Webhooks.Events.MarketplacePurchase;
using Octokit.Webhooks.Events.Member;
using Octokit.Webhooks.Events.Membership;
using Octokit.Webhooks.Events.MergeGroup;
using Octokit.Webhooks.Events.MergeQueueEntry;
using Octokit.Webhooks.Events.Meta;
using Octokit.Webhooks.Events.Milestone;
using Octokit.Webhooks.Events.Organization;
using Octokit.Webhooks.Events.OrgBlock;
using Octokit.Webhooks.Events.Package;
using Octokit.Webhooks.Events.PersonalAccessTokenRequest;
using Octokit.Webhooks.Events.Project;
using Octokit.Webhooks.Events.ProjectCard;
using Octokit.Webhooks.Events.ProjectColumn;
using Octokit.Webhooks.Events.ProjectsV2Item;
using Octokit.Webhooks.Events.ProjectsV2Project;
using Octokit.Webhooks.Events.ProjectsV2StatusUpdate;
using Octokit.Webhooks.Events.PullRequest;
using Octokit.Webhooks.Events.PullRequestReview;
using Octokit.Webhooks.Events.PullRequestReviewComment;
using Octokit.Webhooks.Events.PullRequestReviewThread;
using Octokit.Webhooks.Events.RegistryPackage;
using Octokit.Webhooks.Events.Release;
using Octokit.Webhooks.Events.Repository;
using Octokit.Webhooks.Events.RepositoryAdvisory;
using Octokit.Webhooks.Events.RepositoryDispatch;
using Octokit.Webhooks.Events.RepositoryRuleset;
using Octokit.Webhooks.Events.RepositoryVulnerabilityAlert;
using Octokit.Webhooks.Events.SecretScanningAlert;
using Octokit.Webhooks.Events.SecretScanningAlertLocation;
using Octokit.Webhooks.Events.SecretScanningScan;
using Octokit.Webhooks.Events.SecurityAdvisory;
using Octokit.Webhooks.Events.Sponsorship;
using Octokit.Webhooks.Events.Star;
using Octokit.Webhooks.Events.SubIssues;
using Octokit.Webhooks.Events.Team;
using Octokit.Webhooks.Events.Watch;
using Octokit.Webhooks.Events.WorkflowJob;
using Octokit.Webhooks.Events.WorkflowRun;

[PublicAPI]
public abstract class WebhookEventProcessor
{
    private static readonly FrozenDictionary<string, Type> EventTypeMap = new Dictionary<string, Type>
    {
        [WebhookEventType.BranchProtectionConfiguration] = typeof(BranchProtectionConfigurationEvent),
        [WebhookEventType.BranchProtectionRule] = typeof(BranchProtectionRuleEvent),
        [WebhookEventType.CheckRun] = typeof(CheckRunEvent),
        [WebhookEventType.CheckSuite] = typeof(CheckSuiteEvent),
        [WebhookEventType.CodeScanningAlert] = typeof(CodeScanningAlertEvent),
        [WebhookEventType.CommitComment] = typeof(CommitCommentEvent),
        [WebhookEventType.ContentReference] = typeof(ContentReferenceEvent),
        [WebhookEventType.Create] = typeof(CreateEvent),
        [WebhookEventType.CustomProperty] = typeof(CustomPropertyEvent),
        [WebhookEventType.CustomPropertyPromotedToEnterprise] = typeof(CustomPropertyPromotedToEnterpriseEvent),
        [WebhookEventType.CustomPropertyValues] = typeof(CustomPropertyValuesEvent),
        [WebhookEventType.Delete] = typeof(DeleteEvent),
        [WebhookEventType.DependabotAlert] = typeof(DependabotAlertEvent),
        [WebhookEventType.DeployKey] = typeof(DeployKeyEvent),
        [WebhookEventType.Deployment] = typeof(DeploymentEvent),
        [WebhookEventType.DeploymentProtectionRule] = typeof(DeploymentProtectionRuleEvent),
        [WebhookEventType.DeploymentReview] = typeof(DeploymentReviewEvent),
        [WebhookEventType.DeploymentStatus] = typeof(DeploymentStatusEvent),
        [WebhookEventType.Discussion] = typeof(DiscussionEvent),
        [WebhookEventType.DiscussionComment] = typeof(DiscussionCommentEvent),
        [WebhookEventType.Fork] = typeof(ForkEvent),
        [WebhookEventType.GithubAppAuthorization] = typeof(GithubAppAuthorizationEvent),
        [WebhookEventType.Gollum] = typeof(GollumEvent),
        [WebhookEventType.Installation] = typeof(InstallationEvent),
        [WebhookEventType.InstallationRepositories] = typeof(InstallationRepositoriesEvent),
        [WebhookEventType.InstallationTarget] = typeof(InstallationTargetEvent),
        [WebhookEventType.IssueComment] = typeof(IssueCommentEvent),
        [WebhookEventType.IssueDependencies] = typeof(IssueDependenciesEvent),
        [WebhookEventType.Issues] = typeof(IssuesEvent),
        [WebhookEventType.Label] = typeof(LabelEvent),
        [WebhookEventType.MarketplacePurchase] = typeof(MarketplacePurchaseEvent),
        [WebhookEventType.Member] = typeof(MemberEvent),
        [WebhookEventType.Membership] = typeof(MembershipEvent),
        [WebhookEventType.MergeGroup] = typeof(MergeGroupEvent),
        [WebhookEventType.MergeQueueEntry] = typeof(MergeQueueEntryEvent),
        [WebhookEventType.Meta] = typeof(MetaEvent),
        [WebhookEventType.Milestone] = typeof(MilestoneEvent),
        [WebhookEventType.OrgBlock] = typeof(OrgBlockEvent),
        [WebhookEventType.Organization] = typeof(OrganizationEvent),
        [WebhookEventType.Package] = typeof(PackageEvent),
        [WebhookEventType.PageBuild] = typeof(PageBuildEvent),
        [WebhookEventType.PersonalAccessTokenRequest] = typeof(PersonalAccessTokenRequestEvent),
        [WebhookEventType.Ping] = typeof(PingEvent),
        [WebhookEventType.Project] = typeof(ProjectEvent),
        [WebhookEventType.ProjectCard] = typeof(ProjectCardEvent),
        [WebhookEventType.ProjectColumn] = typeof(ProjectColumnEvent),
        [WebhookEventType.ProjectsV2Item] = typeof(ProjectsV2ItemEvent),
        [WebhookEventType.ProjectsV2Project] = typeof(ProjectsV2ProjectEvent),
        [WebhookEventType.ProjectsV2StatusUpdate] = typeof(ProjectsV2StatusUpdateEvent),
        [WebhookEventType.Public] = typeof(PublicEvent),
        [WebhookEventType.PullRequest] = typeof(PullRequestEvent),
        [WebhookEventType.PullRequestReview] = typeof(PullRequestReviewEvent),
        [WebhookEventType.PullRequestReviewComment] = typeof(PullRequestReviewCommentEvent),
        [WebhookEventType.PullRequestReviewThread] = typeof(PullRequestReviewThreadEvent),
        [WebhookEventType.Push] = typeof(PushEvent),
        [WebhookEventType.RegistryPackage] = typeof(RegistryPackageEvent),
        [WebhookEventType.Release] = typeof(ReleaseEvent),
        [WebhookEventType.Repository] = typeof(RepositoryEvent),
        [WebhookEventType.RepositoryAdvisory] = typeof(RepositoryAdvisoryEvent),
        [WebhookEventType.RepositoryDispatch] = typeof(RepositoryDispatchEvent),
        [WebhookEventType.RepositoryImport] = typeof(RepositoryImportEvent),
        [WebhookEventType.RepositoryRuleset] = typeof(RepositoryRulesetEvent),
        [WebhookEventType.RepositoryVulnerabilityAlert] = typeof(RepositoryVulnerabilityAlertEvent),
        [WebhookEventType.SecretScanningAlert] = typeof(SecretScanningAlertEvent),
        [WebhookEventType.SecretScanningAlertLocation] = typeof(SecretScanningAlertLocationEvent),
        [WebhookEventType.SecretScanningScan] = typeof(SecretScanningScanEvent),
        [WebhookEventType.SecurityAdvisory] = typeof(SecurityAdvisoryEvent),
        [WebhookEventType.SecurityAndAnalysis] = typeof(SecurityAndAnalysisEvent),
        [WebhookEventType.Sponsorship] = typeof(SponsorshipEvent),
        [WebhookEventType.Star] = typeof(StarEvent),
        [WebhookEventType.Status] = typeof(StatusEvent),
        [WebhookEventType.SubIssues] = typeof(SubIssuesEvent),
        [WebhookEventType.Team] = typeof(TeamEvent),
        [WebhookEventType.TeamAdd] = typeof(TeamAddEvent),
        [WebhookEventType.Watch] = typeof(WatchEvent),
        [WebhookEventType.WorkflowDispatch] = typeof(WorkflowDispatchEvent),
        [WebhookEventType.WorkflowJob] = typeof(WorkflowJobEvent),
        [WebhookEventType.WorkflowRun] = typeof(WorkflowRunEvent),
    }.ToFrozenDictionary();

    private static readonly ConcurrentDictionary<Type, bool> StringPathOverrideCache = new();

    [PublicAPI]
    public virtual ValueTask ProcessWebhookAsync(IDictionary<string, StringValues> headers, string body, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(headers);
        ArgumentNullException.ThrowIfNull(body);

        var webhookHeaders = WebhookHeaders.Parse(headers);

        if (string.IsNullOrWhiteSpace(webhookHeaders.Event))
        {
            throw new ArgumentException("X-GitHub-Event header is missing or empty.", nameof(headers));
        }

        var webhookEvent = this.DeserializeWebhookEvent(webhookHeaders, body);

        return this.ProcessWebhookAsync(webhookHeaders, webhookEvent, cancellationToken);
    }

    [PublicAPI]
    public virtual ValueTask ProcessWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent, CancellationToken cancellationToken = default) =>
        webhookEvent switch
        {
            BranchProtectionRuleEvent branchProtectionRuleEvent
                => this.ProcessBranchProtectionRuleWebhookAsync(headers, branchProtectionRuleEvent, cancellationToken),
            CheckRunEvent checkRunEvent => this.ProcessCheckRunWebhookAsync(headers, checkRunEvent, cancellationToken),
            CheckSuiteEvent checkSuiteEvent => this.ProcessCheckSuiteWebhookAsync(headers, checkSuiteEvent, cancellationToken),
            CodeScanningAlertEvent codeScanningAlertEvent => this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, cancellationToken),
            CommitCommentEvent commitCommentEvent => this.ProcessCommitCommentWebhookAsync(headers, commitCommentEvent, cancellationToken),
            ContentReferenceEvent contentReferenceEvent => this.ProcessContentReferenceWebhookAsync(headers, contentReferenceEvent, cancellationToken),
            CreateEvent createEvent => this.ProcessCreateWebhookAsync(headers, createEvent, cancellationToken),
            CustomPropertyEvent customPropertyEvent => this.ProcessCustomPropertyWebhookAsync(headers, customPropertyEvent, cancellationToken),
            CustomPropertyValuesEvent customPropertyValuesEvent => this.ProcessCustomPropertyValuesWebhookAsync(headers, customPropertyValuesEvent, cancellationToken),
            DeleteEvent deleteEvent => this.ProcessDeleteWebhookAsync(headers, deleteEvent, cancellationToken),
            DependabotAlertEvent dependabotAlertEvent => this.ProcessDependabotAlertWebhookAsync(headers, dependabotAlertEvent, cancellationToken),
            DeployKeyEvent deployKeyEvent => this.ProcessDeployKeyWebhookAsync(headers, deployKeyEvent, cancellationToken),
            DeploymentEvent deploymentEvent => this.ProcessDeploymentWebhookAsync(headers, deploymentEvent, cancellationToken),
            DeploymentProtectionRuleEvent deploymentProtectionRuleEvent => this.ProcessDeploymentProtectionRuleWebhookAsync(headers, deploymentProtectionRuleEvent, cancellationToken),
            DeploymentReviewEvent deploymentReviewEvent => this.ProcessDeploymentReviewWebhookAsync(headers, deploymentReviewEvent, cancellationToken),
            DeploymentStatusEvent deploymentStatusEvent => this.ProcessDeploymentStatusWebhookAsync(headers, deploymentStatusEvent, cancellationToken),
            DiscussionEvent discussionEvent => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, cancellationToken),
            DiscussionCommentEvent discussionCommentEvent => this.ProcessDiscussionCommentWebhookAsync(headers, discussionCommentEvent, cancellationToken),
            ForkEvent forkEvent => this.ProcessForkWebhookAsync(headers, forkEvent, cancellationToken),
            GithubAppAuthorizationEvent githubAppAuthorizationEvent
                => this.ProcessGithubAppAuthorizationWebhookAsync(headers, githubAppAuthorizationEvent, cancellationToken),
            GollumEvent gollumEvent => this.ProcessGollumWebhookAsync(headers, gollumEvent, cancellationToken),
            InstallationEvent installationEvent => this.ProcessInstallationWebhookAsync(headers, installationEvent, cancellationToken),
            InstallationRepositoriesEvent installationRepositoriesEvent
                => this.ProcessInstallationRepositoriesWebhookAsync(headers, installationRepositoriesEvent, cancellationToken),
            InstallationTargetEvent installationTargetEvent
                => this.ProcessInstallationTargetWebhookAsync(headers, installationTargetEvent, cancellationToken),
            IssueCommentEvent issueCommentEvent => this.ProcessIssueCommentWebhookAsync(headers, issueCommentEvent, cancellationToken),
            IssuesEvent issuesEvent => this.ProcessIssuesWebhookAsync(headers, issuesEvent, cancellationToken),
            LabelEvent labelEvent => this.ProcessLabelWebhookAsync(headers, labelEvent, cancellationToken),
            MarketplacePurchaseEvent marketplacePurchaseEvent
                => this.ProcessMarketplacePurchaseWebhookAsync(headers, marketplacePurchaseEvent, cancellationToken),
            MemberEvent memberEvent => this.ProcessMemberWebhookAsync(headers, memberEvent, cancellationToken),
            MergeGroupEvent mergeGroupEvent => this.ProcessMergeGroupWebhookAsync(headers, mergeGroupEvent, cancellationToken),
            MergeQueueEntryEvent mergeQueueEntryEvent => this.ProcessMergeQueueEntryWebhookAsync(headers, mergeQueueEntryEvent, cancellationToken),
            MembershipEvent membershipEvent => this.ProcessMembershipWebhookAsync(headers, membershipEvent, cancellationToken),
            MetaEvent metaEvent => this.ProcessMetaWebhookAsync(headers, metaEvent, cancellationToken),
            MilestoneEvent milestoneEvent => this.ProcessMilestoneWebhookAsync(headers, milestoneEvent, cancellationToken),
            OrgBlockEvent orgBlockEvent => this.ProcessOrgBlockWebhookAsync(headers, orgBlockEvent, cancellationToken),
            OrganizationEvent organizationEvent => this.ProcessOrganizationWebhookAsync(headers, organizationEvent, cancellationToken),
            PackageEvent packageEvent => this.ProcessPackageWebhookAsync(headers, packageEvent, cancellationToken),
            PageBuildEvent pageBuildEvent => this.ProcessPageBuildWebhookAsync(headers, pageBuildEvent, cancellationToken),
            PingEvent pingEvent => this.ProcessPingWebhookAsync(headers, pingEvent, cancellationToken),
            ProjectEvent projectEvent => this.ProcessProjectWebhookAsync(headers, projectEvent, cancellationToken),
            ProjectCardEvent projectCardEvent => this.ProcessProjectCardWebhookAsync(headers, projectCardEvent, cancellationToken),
            ProjectColumnEvent projectColumnEvent => this.ProcessProjectColumnWebhookAsync(headers, projectColumnEvent, cancellationToken),
            ProjectsV2ItemEvent projectsV2ItemEvent => this.ProcessProjectsV2ItemWebhookAsync(headers, projectsV2ItemEvent, cancellationToken),
            PublicEvent publicEvent => this.ProcessPublicWebhookAsync(headers, publicEvent, cancellationToken),
            PullRequestEvent pullRequestEvent => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, cancellationToken),
            PullRequestReviewEvent pullRequestReviewEvent => this.ProcessPullRequestReviewWebhookAsync(headers, pullRequestReviewEvent, cancellationToken),
            PullRequestReviewCommentEvent pullRequestReviewCommentEvent
                => this.ProcessPullRequestReviewCommentWebhookAsync(headers, pullRequestReviewCommentEvent, cancellationToken),
            PullRequestReviewThreadEvent pullRequestReviewThreadEvent
                => this.ProcessPullRequestReviewThreadWebhookAsync(headers, pullRequestReviewThreadEvent, cancellationToken),
            PushEvent pushEvent => this.ProcessPushWebhookAsync(headers, pushEvent, cancellationToken),
            ReleaseEvent releaseEvent => this.ProcessReleaseWebhookAsync(headers, releaseEvent, cancellationToken),
            RegistryPackageEvent registryPackageEvent => this.ProcessRegistryPackageWebhookAsync(headers, registryPackageEvent, cancellationToken),
            RepositoryEvent repositoryEvent => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, cancellationToken),
            RepositoryAdvisoryEvent repositoryAdvisoryEvent => this.ProcessRepositoryAdvisoryWebhookAsync(headers, repositoryAdvisoryEvent, cancellationToken),
            RepositoryDispatchEvent repositoryDispatchEvent
                => this.ProcessRepositoryDispatchWebhookAsync(headers, repositoryDispatchEvent, cancellationToken),
            RepositoryImportEvent repositoryImportEvent => this.ProcessRepositoryImportWebhookAsync(headers, repositoryImportEvent, cancellationToken),
            RepositoryRulesetEvent repositoryRulesetEvent => this.ProcessRepositoryRulesetWebhookAsync(headers, repositoryRulesetEvent, cancellationToken),
            RepositoryVulnerabilityAlertEvent repositoryVulnerabilityAlertEvent
                => this.ProcessRepositoryVulnerabilityAlertWebhookAsync(headers, repositoryVulnerabilityAlertEvent, cancellationToken),
            SecretScanningAlertEvent secretScanningAlertEvent
                => this.ProcessSecretScanningAlertWebhookAsync(headers, secretScanningAlertEvent, cancellationToken),
            SecretScanningAlertLocationEvent secretScanningAlertLocationEvent
                => this.ProcessSecretScanningAlertLocationWebhookAsync(headers, secretScanningAlertLocationEvent, cancellationToken),
            SecurityAdvisoryEvent securityAdvisoryEvent => this.ProcessSecurityAdvisoryWebhookAsync(headers, securityAdvisoryEvent, cancellationToken),
            SecurityAndAnalysisEvent securityAndAnalysisEvent => this.ProcessSecurityAndAnalysisWebhookAsync(headers, securityAndAnalysisEvent, cancellationToken),
            SponsorshipEvent sponsorshipEvent => this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, cancellationToken),
            StarEvent starEvent => this.ProcessStarWebhookAsync(headers, starEvent, cancellationToken),
            StatusEvent statusEvent => this.ProcessStatusWebhookAsync(headers, statusEvent, cancellationToken),
            SubIssuesEvent subIssuesEvent => this.ProcessSubIssuesWebhookAsync(headers, subIssuesEvent, cancellationToken),
            TeamEvent teamEvent => this.ProcessTeamWebhookAsync(headers, teamEvent, cancellationToken),
            TeamAddEvent teamAddEvent => this.ProcessTeamAddWebhookAsync(headers, teamAddEvent, cancellationToken),
            WatchEvent watchEvent => this.ProcessWatchWebhookAsync(headers, watchEvent, cancellationToken),
            WorkflowDispatchEvent workflowDispatchEvent => this.ProcessWorkflowDispatchWebhookAsync(headers, workflowDispatchEvent, cancellationToken),
            WorkflowJobEvent workflowJobEvent => this.ProcessWorkflowJobWebhookAsync(headers, workflowJobEvent, cancellationToken),
            WorkflowRunEvent workflowRunEvent => this.ProcessWorkflowRunWebhookAsync(headers, workflowRunEvent, cancellationToken),
            BranchProtectionConfigurationEvent branchProtectionConfigurationEvent => this.ProcessBranchProtectionConfigurationWebhookAsync(headers, branchProtectionConfigurationEvent, cancellationToken),
            CustomPropertyPromotedToEnterpriseEvent customPropertyPromotedToEnterpriseEvent => this.ProcessCustomPropertyPromotedToEnterpriseWebhookAsync(headers, customPropertyPromotedToEnterpriseEvent, cancellationToken),
            IssueDependenciesEvent issueDependenciesEvent => this.ProcessIssueDependenciesWebhookAsync(headers, issueDependenciesEvent, cancellationToken),
            PersonalAccessTokenRequestEvent personalAccessTokenRequestEvent => this.ProcessPersonalAccessTokenRequestWebhookAsync(headers, personalAccessTokenRequestEvent, cancellationToken),
            ProjectsV2ProjectEvent projectsV2ProjectEvent => this.ProcessProjectsV2ProjectWebhookAsync(headers, projectsV2ProjectEvent, cancellationToken),
            ProjectsV2StatusUpdateEvent projectsV2StatusUpdateEvent => this.ProcessProjectsV2StatusUpdateWebhookAsync(headers, projectsV2StatusUpdateEvent, cancellationToken),
            SecretScanningScanEvent secretScanningScanEvent => this.ProcessSecretScanningScanWebhookAsync(headers, secretScanningScanEvent, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    public virtual WebhookEvent DeserializeWebhookEvent(WebhookHeaders headers, string body)
    {
        ArgumentNullException.ThrowIfNull(headers);
        ArgumentNullException.ThrowIfNull(body);

        if (string.IsNullOrWhiteSpace(headers.Event))
        {
            throw new JsonException($"Unable to deserialize event: '{headers.Event}'");
        }

        if (!EventTypeMap.TryGetValue(headers.Event, out var type))
        {
            throw new JsonException($"Unable to deserialize event: '{headers.Event}'");
        }

        return (WebhookEvent)JsonSerializer.Deserialize(body, type)!;
    }

    /// <summary>
    /// Processes a GitHub webhook from raw UTF-8 bytes, avoiding string allocation.
    /// Uses the byte-based fast path when no string-based overrides are detected;
    /// otherwise falls back to the string-based virtual methods for backward compatibility.
    /// </summary>
    /// <param name="headers">The HTTP request headers.</param>
    /// <param name="body">The raw request body as UTF-8 bytes.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    [PublicAPI]
    public ValueTask ProcessWebhookAsync(IDictionary<string, StringValues> headers, ReadOnlyMemory<byte> body, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(headers);

        var webhookHeaders = WebhookHeaders.Parse(headers);

        if (string.IsNullOrWhiteSpace(webhookHeaders.Event))
        {
            throw new ArgumentException("X-GitHub-Event header is missing or empty.", nameof(headers));
        }

        if (this.HasStringPathOverrides())
        {
            var bodyString = Encoding.UTF8.GetString(body.Span);
            return this.ProcessWebhookAsync(headers, bodyString, cancellationToken);
        }

        return this.ProcessWebhookFromBytesAsync(webhookHeaders, body, cancellationToken);
    }

    private ValueTask ProcessWebhookFromBytesAsync(WebhookHeaders webhookHeaders, ReadOnlyMemory<byte> body, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(webhookHeaders.Event))
        {
            throw new JsonException($"Unable to deserialize event: '{webhookHeaders.Event}'");
        }

        if (!EventTypeMap.TryGetValue(webhookHeaders.Event, out var type))
        {
            throw new JsonException($"Unable to deserialize event: '{webhookHeaders.Event}'");
        }

        var webhookEvent = (WebhookEvent)JsonSerializer.Deserialize(body.Span, type)!;
        return this.ProcessWebhookAsync(webhookHeaders, webhookEvent, cancellationToken);
    }

    private bool HasStringPathOverrides()
    {
        var concreteType = this.GetType();
        return StringPathOverrideCache.GetOrAdd(concreteType, static t =>
        {
            var baseType = typeof(WebhookEventProcessor);

            var processMethod = t.GetMethod(
                "ProcessWebhookAsync",
                BindingFlags.Public | BindingFlags.Instance,
                null,
                [typeof(IDictionary<string, StringValues>), typeof(string), typeof(CancellationToken)],
                null);

            var deserializeMethod = t.GetMethod(
                "DeserializeWebhookEvent",
                BindingFlags.Public | BindingFlags.Instance,
                null,
                [typeof(WebhookHeaders), typeof(string)],
                null);

            return (processMethod?.DeclaringType != baseType)
                || (deserializeMethod?.DeclaringType != baseType);
        });
    }

    private ValueTask ProcessBranchProtectionRuleWebhookAsync(WebhookHeaders headers, BranchProtectionRuleEvent branchProtectionRuleEvent, CancellationToken cancellationToken = default) =>
        branchProtectionRuleEvent.Action switch
        {
            BranchProtectionRuleActionValue.Created
                => this.ProcessBranchProtectionRuleWebhookAsync(headers, branchProtectionRuleEvent, BranchProtectionRuleAction.Created, cancellationToken),
            BranchProtectionRuleActionValue.Deleted
                => this.ProcessBranchProtectionRuleWebhookAsync(headers, branchProtectionRuleEvent, BranchProtectionRuleAction.Deleted, cancellationToken),
            BranchProtectionRuleActionValue.Edited
                => this.ProcessBranchProtectionRuleWebhookAsync(headers, branchProtectionRuleEvent, BranchProtectionRuleAction.Edited, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessBranchProtectionRuleWebhookAsync(
        WebhookHeaders headers,
        BranchProtectionRuleEvent branchProtectionRuleEvent,
        BranchProtectionRuleAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessCheckRunWebhookAsync(WebhookHeaders headers, CheckRunEvent checkRunEvent, CancellationToken cancellationToken = default) =>
        checkRunEvent.Action switch
        {
            CheckRunActionValue.Completed => this.ProcessCheckRunWebhookAsync(headers, checkRunEvent, CheckRunAction.Completed, cancellationToken),
            CheckRunActionValue.Created => this.ProcessCheckRunWebhookAsync(headers, checkRunEvent, CheckRunAction.Created, cancellationToken),
            CheckRunActionValue.RequestedAction
                => this.ProcessCheckRunWebhookAsync(headers, checkRunEvent, CheckRunAction.RequestedAction, cancellationToken),
            CheckRunActionValue.Rerequested => this.ProcessCheckRunWebhookAsync(headers, checkRunEvent, CheckRunAction.Rerequested, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessCheckRunWebhookAsync(WebhookHeaders headers, CheckRunEvent checkRunEvent, CheckRunAction action, CancellationToken cancellationToken = default) =>
        ValueTask.CompletedTask;

    private ValueTask ProcessCheckSuiteWebhookAsync(WebhookHeaders headers, CheckSuiteEvent checkSuiteEvent, CancellationToken cancellationToken = default) =>
        checkSuiteEvent.Action switch
        {
            CheckSuiteActionValue.Completed => this.ProcessCheckSuiteWebhookAsync(headers, checkSuiteEvent, CheckSuiteAction.Completed, cancellationToken),
            CheckSuiteActionValue.Requested => this.ProcessCheckSuiteWebhookAsync(headers, checkSuiteEvent, CheckSuiteAction.Requested, cancellationToken),
            CheckSuiteActionValue.Rerequested
                => this.ProcessCheckSuiteWebhookAsync(headers, checkSuiteEvent, CheckSuiteAction.Rerequested, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessCheckSuiteWebhookAsync(
        WebhookHeaders headers,
        CheckSuiteEvent checkSuiteEvent,
        CheckSuiteAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessCodeScanningAlertWebhookAsync(WebhookHeaders headers, CodeScanningAlertEvent codeScanningAlertEvent, CancellationToken cancellationToken = default) =>
        codeScanningAlertEvent.Action switch
        {
            CodeScanningAlertActionValue.AppearedInBranch
                => this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.AppearedInBranch, cancellationToken),
            CodeScanningAlertActionValue.ClosedByUser
                => this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.ClosedByUser, cancellationToken),
            CodeScanningAlertActionValue.Created
                => this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.Created, cancellationToken),
            CodeScanningAlertActionValue.Fixed
                => this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.Fixed, cancellationToken),
            CodeScanningAlertActionValue.Reopened
                => this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.Reopened, cancellationToken),
            CodeScanningAlertActionValue.ReopenedByUser
                => this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.ReopenedByUser, cancellationToken),
            CodeScanningAlertActionValue.UpdatedAssignment
                => this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.UpdatedAssignment, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessCodeScanningAlertWebhookAsync(
        WebhookHeaders headers,
        CodeScanningAlertEvent codeScanningAlertEvent,
        CodeScanningAlertAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessCommitCommentWebhookAsync(WebhookHeaders headers, CommitCommentEvent commitCommentEvent, CancellationToken cancellationToken = default) =>
        commitCommentEvent.Action switch
        {
            CommitCommentActionValue.Created
                => this.ProcessCommitCommentWebhookAsync(headers, commitCommentEvent, CommitCommentAction.Created, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessCommitCommentWebhookAsync(
        WebhookHeaders headers,
        CommitCommentEvent commitCommentEvent,
        CommitCommentAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessContentReferenceWebhookAsync(WebhookHeaders headers, ContentReferenceEvent contentReferenceEvent, CancellationToken cancellationToken = default) =>
        contentReferenceEvent.Action switch
        {
            ContentReferenceActionValue.Created
                => this.ProcessContentReferenceWebhookAsync(headers, contentReferenceEvent, ContentReferenceAction.Created, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessContentReferenceWebhookAsync(
        WebhookHeaders headers,
        ContentReferenceEvent contentReferenceEvent,
        ContentReferenceAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    [PublicAPI]
    protected virtual ValueTask ProcessCreateWebhookAsync(WebhookHeaders headers, CreateEvent createEvent, CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessCustomPropertyWebhookAsync(WebhookHeaders headers, CustomPropertyEvent customPropertyEvent, CancellationToken cancellationToken = default) =>
        customPropertyEvent.Action switch
        {
            CustomPropertyActionValue.Created
                => this.ProcessCustomPropertyWebhookAsync(headers, customPropertyEvent, CustomPropertyAction.Created, cancellationToken),
            CustomPropertyActionValue.Deleted
                => this.ProcessCustomPropertyWebhookAsync(headers, customPropertyEvent, CustomPropertyAction.Deleted, cancellationToken),
            CustomPropertyActionValue.Updated
                => this.ProcessCustomPropertyWebhookAsync(headers, customPropertyEvent, CustomPropertyAction.Updated, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessCustomPropertyWebhookAsync(
        WebhookHeaders headers,
        CustomPropertyEvent hookEvent,
        CustomPropertyAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessCustomPropertyValuesWebhookAsync(WebhookHeaders headers, CustomPropertyValuesEvent customPropertyValuesEvent, CancellationToken cancellationToken = default) =>
        customPropertyValuesEvent.Action switch
        {
            CustomPropertyValuesActionValue.Updated
                => this.ProcessCustomPropertyValuesWebhookAsync(headers, customPropertyValuesEvent, CustomPropertyValuesAction.Updated, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessCustomPropertyValuesWebhookAsync(
        WebhookHeaders headers,
        CustomPropertyValuesEvent hookEvent,
        CustomPropertyValuesAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    [PublicAPI]
    protected virtual ValueTask ProcessDeleteWebhookAsync(WebhookHeaders headers, DeleteEvent deleteEvent, CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessDependabotAlertWebhookAsync(WebhookHeaders headers, DependabotAlertEvent dependabotAlertEvent, CancellationToken cancellationToken = default) =>
        dependabotAlertEvent.Action switch
        {
            DependabotAlertActionValue.Created
                => this.ProcessDependabotAlertWebhookAsync(headers, dependabotAlertEvent, DependabotAlertAction.Created, cancellationToken),
            DependabotAlertActionValue.Dismissed
                => this.ProcessDependabotAlertWebhookAsync(headers, dependabotAlertEvent, DependabotAlertAction.Dismissed, cancellationToken),
            DependabotAlertActionValue.Fixed
                => this.ProcessDependabotAlertWebhookAsync(headers, dependabotAlertEvent, DependabotAlertAction.Fixed, cancellationToken),
            DependabotAlertActionValue.Reintroduced
                => this.ProcessDependabotAlertWebhookAsync(headers, dependabotAlertEvent, DependabotAlertAction.Reintroduced, cancellationToken),
            DependabotAlertActionValue.Reopened
                => this.ProcessDependabotAlertWebhookAsync(headers, dependabotAlertEvent, DependabotAlertAction.Reopened, cancellationToken),
            DependabotAlertActionValue.AssigneesChanged
                => this.ProcessDependabotAlertWebhookAsync(headers, dependabotAlertEvent, DependabotAlertAction.AssigneesChanged, cancellationToken),
            DependabotAlertActionValue.AutoDismissed
                => this.ProcessDependabotAlertWebhookAsync(headers, dependabotAlertEvent, DependabotAlertAction.AutoDismissed, cancellationToken),
            DependabotAlertActionValue.AutoReopened
                => this.ProcessDependabotAlertWebhookAsync(headers, dependabotAlertEvent, DependabotAlertAction.AutoReopened, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessDependabotAlertWebhookAsync(
        WebhookHeaders headers,
        DependabotAlertEvent dependabotAlertEvent,
        DependabotAlertAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessDeployKeyWebhookAsync(WebhookHeaders headers, DeployKeyEvent deployKeyEvent, CancellationToken cancellationToken = default) =>
        deployKeyEvent.Action switch
        {
            DeployKeyActionValue.Created => this.ProcessDeployKeyWebhookAsync(headers, deployKeyEvent, DeployKeyAction.Created, cancellationToken),
            DeployKeyActionValue.Deleted => this.ProcessDeployKeyWebhookAsync(headers, deployKeyEvent, DeployKeyAction.Deleted, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessDeployKeyWebhookAsync(
        WebhookHeaders headers,
        DeployKeyEvent deployKeyEvent,
        DeployKeyAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessDeploymentWebhookAsync(WebhookHeaders headers, DeploymentEvent deploymentEvent, CancellationToken cancellationToken = default) =>
        deploymentEvent.Action switch
        {
            DeploymentActionValue.Created => this.ProcessDeploymentWebhookAsync(headers, deploymentEvent, DeploymentAction.Created, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessDeploymentWebhookAsync(
        WebhookHeaders headers,
        DeploymentEvent deploymentEvent,
        DeploymentAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessDeploymentProtectionRuleWebhookAsync(WebhookHeaders headers, DeploymentProtectionRuleEvent deploymentProtectionRuleEvent, CancellationToken cancellationToken = default) =>
        deploymentProtectionRuleEvent.Action switch
        {
            DeploymentProtectionRuleActionValue.Requested => this.ProcessDeployProtectionRuleWebhookAsync(headers, deploymentProtectionRuleEvent, DeploymentProtectionRuleAction.Requested, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessDeployProtectionRuleWebhookAsync(
        WebhookHeaders headers,
        DeploymentProtectionRuleEvent deploymentProtectionRuleEvent,
        DeploymentProtectionRuleAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessDeploymentReviewWebhookAsync(WebhookHeaders headers, DeploymentReviewEvent deploymentReviewEvent, CancellationToken cancellationToken = default) =>
        deploymentReviewEvent.Action switch
        {
            DeploymentReviewActionValue.Approved => this.ProcessDeploymentReviewWebhookAsync(
                headers,
                deploymentReviewEvent,
                DeploymentReviewAction.Approved,
                cancellationToken),
            DeploymentReviewActionValue.Rejected => this.ProcessDeploymentReviewWebhookAsync(
                headers,
                deploymentReviewEvent,
                DeploymentReviewAction.Rejected,
                cancellationToken),
            DeploymentReviewActionValue.Requested => this.ProcessDeploymentReviewWebhookAsync(
                headers,
                deploymentReviewEvent,
                DeploymentReviewAction.Requested,
                cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessDeploymentReviewWebhookAsync(
        WebhookHeaders headers,
        DeploymentReviewEvent deploymentReviewEvent,
        DeploymentReviewAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessDeploymentStatusWebhookAsync(WebhookHeaders headers, DeploymentStatusEvent deploymentStatusEvent, CancellationToken cancellationToken = default) =>
        deploymentStatusEvent.Action switch
        {
            DeploymentStatusActionValue.Created
                => this.ProcessDeploymentStatusWebhookAsync(headers, deploymentStatusEvent, DeploymentStatusAction.Created, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessDeploymentStatusWebhookAsync(
        WebhookHeaders headers,
        DeploymentStatusEvent deploymentStatusEvent,
        DeploymentStatusAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessDiscussionWebhookAsync(WebhookHeaders headers, DiscussionEvent discussionEvent, CancellationToken cancellationToken = default) =>
        discussionEvent.Action switch
        {
            DiscussionActionValue.Answered => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Answered, cancellationToken),
            DiscussionActionValue.CategoryChanged
                => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.CategoryChanged, cancellationToken),
            DiscussionActionValue.Created => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Created, cancellationToken),
            DiscussionActionValue.Deleted => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Deleted, cancellationToken),
            DiscussionActionValue.Edited => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Edited, cancellationToken),
            DiscussionActionValue.Labeled => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Labeled, cancellationToken),
            DiscussionActionValue.Locked => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Locked, cancellationToken),
            DiscussionActionValue.Pinned => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Pinned, cancellationToken),
            DiscussionActionValue.Transferred
                => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Transferred, cancellationToken),
            DiscussionActionValue.Unanswered
                => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Unanswered, cancellationToken),
            DiscussionActionValue.Unlabeled => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Unlabeled, cancellationToken),
            DiscussionActionValue.Unlocked => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Unlocked, cancellationToken),
            DiscussionActionValue.Unpinned => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Unpinned, cancellationToken),
            DiscussionActionValue.Closed
                => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Closed, cancellationToken),
            DiscussionActionValue.Reopened
                => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Reopened, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessDiscussionWebhookAsync(
        WebhookHeaders headers,
        DiscussionEvent discussionEvent,
        DiscussionAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessDiscussionCommentWebhookAsync(WebhookHeaders headers, DiscussionCommentEvent discussionCommentEvent, CancellationToken cancellationToken = default) =>
        discussionCommentEvent.Action switch
        {
            DiscussionCommentActionValue.Created
                => this.ProcessDiscussionCommentWebhookAsync(headers, discussionCommentEvent, DiscussionCommentAction.Created, cancellationToken),
            DiscussionCommentActionValue.Deleted
                => this.ProcessDiscussionCommentWebhookAsync(headers, discussionCommentEvent, DiscussionCommentAction.Deleted, cancellationToken),
            DiscussionCommentActionValue.Edited
                => this.ProcessDiscussionCommentWebhookAsync(headers, discussionCommentEvent, DiscussionCommentAction.Edited, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessDiscussionCommentWebhookAsync(
        WebhookHeaders headers,
        DiscussionCommentEvent discussionCommentEvent,
        DiscussionCommentAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    [PublicAPI]
    protected virtual ValueTask ProcessForkWebhookAsync(WebhookHeaders headers, ForkEvent forkEvent, CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessGithubAppAuthorizationWebhookAsync(
        WebhookHeaders headers,
        GithubAppAuthorizationEvent githubAppAuthorizationEvent,
        CancellationToken cancellationToken = default) =>
        githubAppAuthorizationEvent.Action switch
        {
            GithubAppAuthorizationActionValue.Revoked
                => this.ProcessGithubAppAuthorizationWebhookAsync(
                    headers,
                    githubAppAuthorizationEvent,
                    GithubAppAuthorizationAction.Revoked,
                    cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessGithubAppAuthorizationWebhookAsync(
        WebhookHeaders headers,
        GithubAppAuthorizationEvent githubAppAuthorizationEvent,
        GithubAppAuthorizationAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    [PublicAPI]
    protected virtual ValueTask ProcessGollumWebhookAsync(WebhookHeaders headers, GollumEvent gollumEvent, CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessInstallationWebhookAsync(WebhookHeaders headers, InstallationEvent installationEvent, CancellationToken cancellationToken = default) =>
        installationEvent.Action switch
        {
            InstallationActionValue.Created
                => this.ProcessInstallationWebhookAsync(headers, installationEvent, InstallationAction.Created, cancellationToken),
            InstallationActionValue.Deleted
                => this.ProcessInstallationWebhookAsync(headers, installationEvent, InstallationAction.Deleted, cancellationToken),
            InstallationActionValue.NewPermissionsAccepted
                => this.ProcessInstallationWebhookAsync(headers, installationEvent, InstallationAction.NewPermissionsAccepted, cancellationToken),
            InstallationActionValue.Suspend
                => this.ProcessInstallationWebhookAsync(headers, installationEvent, InstallationAction.Suspend, cancellationToken),
            InstallationActionValue.Unsuspend
                => this.ProcessInstallationWebhookAsync(headers, installationEvent, InstallationAction.Unsuspend, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessInstallationWebhookAsync(
        WebhookHeaders headers,
        InstallationEvent installationEvent,
        InstallationAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessInstallationRepositoriesWebhookAsync(
        WebhookHeaders headers,
        InstallationRepositoriesEvent installationRepositoriesEvent,
        CancellationToken cancellationToken = default) =>
        installationRepositoriesEvent.Action switch
        {
            InstallationRepositoriesActionValue.Added
                => this.ProcessInstallationRepositoriesWebhookAsync(
                    headers,
                    installationRepositoriesEvent,
                    InstallationRepositoriesAction.Added,
                    cancellationToken),
            InstallationRepositoriesActionValue.Removed
                => this.ProcessInstallationRepositoriesWebhookAsync(
                    headers,
                    installationRepositoriesEvent,
                    InstallationRepositoriesAction.Removed,
                    cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessInstallationTargetWebhookAsync(
        WebhookHeaders headers,
        InstallationTargetEvent installationTargetEvent,
        InstallationTargetAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessInstallationTargetWebhookAsync(
        WebhookHeaders headers,
        InstallationTargetEvent installationTargetEvent,
        CancellationToken cancellationToken = default) =>
        installationTargetEvent.Action switch
        {
            InstallationTargetActionValue.Renamed
                => this.ProcessInstallationTargetWebhookAsync(
                    headers,
                    installationTargetEvent,
                    InstallationTargetAction.Renamed,
                    cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessInstallationRepositoriesWebhookAsync(
        WebhookHeaders headers,
        InstallationRepositoriesEvent installationRepositoriesEvent,
        InstallationRepositoriesAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessIssueCommentWebhookAsync(WebhookHeaders headers, IssueCommentEvent issueCommentEvent, CancellationToken cancellationToken = default) =>
        issueCommentEvent.Action switch
        {
            IssueCommentActionValue.Created
                => this.ProcessIssueCommentWebhookAsync(headers, issueCommentEvent, IssueCommentAction.Created, cancellationToken),
            IssueCommentActionValue.Deleted
                => this.ProcessIssueCommentWebhookAsync(headers, issueCommentEvent, IssueCommentAction.Deleted, cancellationToken),
            IssueCommentActionValue.Edited
                => this.ProcessIssueCommentWebhookAsync(headers, issueCommentEvent, IssueCommentAction.Edited, cancellationToken),
            IssueCommentActionValue.Pinned
                => this.ProcessIssueCommentWebhookAsync(headers, issueCommentEvent, IssueCommentAction.Pinned, cancellationToken),
            IssueCommentActionValue.Unpinned
                => this.ProcessIssueCommentWebhookAsync(headers, issueCommentEvent, IssueCommentAction.Unpinned, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessIssueCommentWebhookAsync(
        WebhookHeaders headers,
        IssueCommentEvent issueCommentEvent,
        IssueCommentAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessIssuesWebhookAsync(WebhookHeaders headers, IssuesEvent issuesEvent, CancellationToken cancellationToken = default) =>
        issuesEvent.Action switch
        {
            IssuesActionValue.Assigned => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Assigned, cancellationToken),
            IssuesActionValue.Closed => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Closed, cancellationToken),
            IssuesActionValue.Deleted => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Deleted, cancellationToken),
            IssuesActionValue.Demilestoned => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Demilestoned, cancellationToken),
            IssuesActionValue.Edited => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Edited, cancellationToken),
            IssuesActionValue.Labeled => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Labeled, cancellationToken),
            IssuesActionValue.Locked => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Locked, cancellationToken),
            IssuesActionValue.Milestoned => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Milestoned, cancellationToken),
            IssuesActionValue.Opened => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Opened, cancellationToken),
            IssuesActionValue.Pinned => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Pinned, cancellationToken),
            IssuesActionValue.Reopened => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Reopened, cancellationToken),
            IssuesActionValue.Transferred => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Transferred, cancellationToken),
            IssuesActionValue.Typed => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Typed, cancellationToken),
            IssuesActionValue.Unassigned => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Unassigned, cancellationToken),
            IssuesActionValue.Unlabeled => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Unlabeled, cancellationToken),
            IssuesActionValue.Unlocked => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Unlocked, cancellationToken),
            IssuesActionValue.Unpinned => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Unpinned, cancellationToken),
            IssuesActionValue.Untyped => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Untyped, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessIssuesWebhookAsync(WebhookHeaders headers, IssuesEvent issuesEvent, IssuesAction action, CancellationToken cancellationToken = default) =>
        ValueTask.CompletedTask;

    private ValueTask ProcessLabelWebhookAsync(WebhookHeaders headers, LabelEvent labelEvent, CancellationToken cancellationToken = default) =>
        labelEvent.Action switch
        {
            LabelActionValue.Created => this.ProcessLabelWebhookAsync(headers, labelEvent, LabelAction.Created, cancellationToken),
            LabelActionValue.Deleted => this.ProcessLabelWebhookAsync(headers, labelEvent, LabelAction.Deleted, cancellationToken),
            LabelActionValue.Edited => this.ProcessLabelWebhookAsync(headers, labelEvent, LabelAction.Edited, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessLabelWebhookAsync(WebhookHeaders headers, LabelEvent labelEvent, LabelAction action, CancellationToken cancellationToken = default) =>
        ValueTask.CompletedTask;

    private ValueTask ProcessMarketplacePurchaseWebhookAsync(WebhookHeaders headers, MarketplacePurchaseEvent marketplacePurchaseEvent, CancellationToken cancellationToken = default) =>
        marketplacePurchaseEvent.Action switch
        {
            MarketplacePurchaseActionValue.Cancelled
                => this.ProcessMarketplacePurchaseWebhookAsync(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.Cancelled, cancellationToken),
            MarketplacePurchaseActionValue.Changed
                => this.ProcessMarketplacePurchaseWebhookAsync(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.Changed, cancellationToken),
            MarketplacePurchaseActionValue.PendingChange
                => this.ProcessMarketplacePurchaseWebhookAsync(
                    headers,
                    marketplacePurchaseEvent,
                    MarketplacePurchaseAction.PendingChange,
                    cancellationToken),
            MarketplacePurchaseActionValue.PendingChangeCancelled
                => this.ProcessMarketplacePurchaseWebhookAsync(
                    headers,
                    marketplacePurchaseEvent,
                    MarketplacePurchaseAction.PendingChangeCancelled,
                    cancellationToken),
            MarketplacePurchaseActionValue.Purchased
                => this.ProcessMarketplacePurchaseWebhookAsync(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.Purchased, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessMarketplacePurchaseWebhookAsync(
        WebhookHeaders headers,
        MarketplacePurchaseEvent marketplacePurchaseEvent,
        MarketplacePurchaseAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessMemberWebhookAsync(WebhookHeaders headers, MemberEvent memberEvent, CancellationToken cancellationToken = default) =>
        memberEvent.Action switch
        {
            MemberActionValue.Added => this.ProcessMemberWebhookAsync(headers, memberEvent, MemberAction.Added, cancellationToken),
            MemberActionValue.Edited => this.ProcessMemberWebhookAsync(headers, memberEvent, MemberAction.Edited, cancellationToken),
            MemberActionValue.Removed => this.ProcessMemberWebhookAsync(headers, memberEvent, MemberAction.Removed, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessMemberWebhookAsync(WebhookHeaders headers, MemberEvent memberEvent, MemberAction action, CancellationToken cancellationToken = default) =>
        ValueTask.CompletedTask;

    private ValueTask ProcessMembershipWebhookAsync(WebhookHeaders headers, MembershipEvent membershipEvent, CancellationToken cancellationToken = default) =>
        membershipEvent.Action switch
        {
            MembershipActionValue.Added => this.ProcessMembershipWebhookAsync(headers, membershipEvent, MembershipAction.Added, cancellationToken),
            MembershipActionValue.Removed => this.ProcessMembershipWebhookAsync(headers, membershipEvent, MembershipAction.Removed, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessMembershipWebhookAsync(
        WebhookHeaders headers,
        MembershipEvent membershipEvent,
        MembershipAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessMergeGroupWebhookAsync(WebhookHeaders headers, MergeGroupEvent mergeGroupEvent, CancellationToken cancellationToken = default) =>
        mergeGroupEvent.Action switch
        {
            MergeGroupActionValue.ChecksRequested => this.ProcessMergeGroupWebhookAsync(headers, mergeGroupEvent, MergeGroupAction.ChecksRequested, cancellationToken),
            MergeGroupActionValue.Destroyed => this.ProcessMergeGroupWebhookAsync(headers, (MergeGroupDestroyedEvent)mergeGroupEvent, MergeGroupAction.Destroyed, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessMergeGroupWebhookAsync(
        WebhookHeaders headers,
        MergeGroupEvent mergeGroupEvent,
        MergeGroupAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    [PublicAPI]
    protected virtual ValueTask ProcessMergeGroupWebhookAsync(
        WebhookHeaders headers,
        MergeGroupDestroyedEvent mergeGroupDestroyedEvent,
        MergeGroupAction action,
        CancellationToken cancellationToken = default) => this.ProcessMergeGroupWebhookAsync(headers, (MergeGroupEvent)mergeGroupDestroyedEvent, action, cancellationToken);

    private ValueTask ProcessMergeQueueEntryWebhookAsync(WebhookHeaders headers, MergeQueueEntryEvent mergeQueueEntryEvent, CancellationToken cancellationToken = default) =>
        mergeQueueEntryEvent.Action switch
        {
            MergeQueueEntryActionValue.Created => this.ProcessMergeQueueEntryWebhookAsync(
                headers,
                mergeQueueEntryEvent,
                MergeQueueEntryAction.Created,
                cancellationToken),
            MergeQueueEntryActionValue.Deleted => this.ProcessMergeQueueEntryWebhookAsync(
                headers,
                mergeQueueEntryEvent,
                MergeQueueEntryAction.Deleted,
                cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessMergeQueueEntryWebhookAsync(
        WebhookHeaders headers,
        MergeQueueEntryEvent mergeQueueEntryEvent,
        MergeQueueEntryAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessMetaWebhookAsync(WebhookHeaders headers, MetaEvent metaEvent, CancellationToken cancellationToken = default) =>
        metaEvent.Action switch
        {
            MetaActionValue.Deleted => this.ProcessMetaWebhookAsync(headers, metaEvent, MetaAction.Deleted, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessMetaWebhookAsync(WebhookHeaders headers, MetaEvent metaEvent, MetaAction action, CancellationToken cancellationToken = default) =>
        ValueTask.CompletedTask;

    private ValueTask ProcessMilestoneWebhookAsync(WebhookHeaders headers, MilestoneEvent milestoneEvent, CancellationToken cancellationToken = default) =>
        milestoneEvent.Action switch
        {
            MilestoneActionValue.Closed => this.ProcessMilestoneWebhookAsync(headers, milestoneEvent, MilestoneAction.Closed, cancellationToken),
            MilestoneActionValue.Created => this.ProcessMilestoneWebhookAsync(headers, milestoneEvent, MilestoneAction.Created, cancellationToken),
            MilestoneActionValue.Deleted => this.ProcessMilestoneWebhookAsync(headers, milestoneEvent, MilestoneAction.Deleted, cancellationToken),
            MilestoneActionValue.Edited => this.ProcessMilestoneWebhookAsync(headers, milestoneEvent, MilestoneAction.Edited, cancellationToken),
            MilestoneActionValue.Opened => this.ProcessMilestoneWebhookAsync(headers, milestoneEvent, MilestoneAction.Opened, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessMilestoneWebhookAsync(
        WebhookHeaders headers,
        MilestoneEvent milestoneEvent,
        MilestoneAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessOrgBlockWebhookAsync(WebhookHeaders headers, OrgBlockEvent orgBlockEvent, CancellationToken cancellationToken = default) =>
        orgBlockEvent.Action switch
        {
            OrgBlockActionValue.Blocked => this.ProcessOrgBlockWebhookAsync(headers, orgBlockEvent, OrgBlockAction.Blocked, cancellationToken),
            OrgBlockActionValue.Unblocked => this.ProcessOrgBlockWebhookAsync(headers, orgBlockEvent, OrgBlockAction.Unblocked, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessOrgBlockWebhookAsync(WebhookHeaders headers, OrgBlockEvent orgBlockEvent, OrgBlockAction action, CancellationToken cancellationToken = default) =>
        ValueTask.CompletedTask;

    private ValueTask ProcessOrganizationWebhookAsync(WebhookHeaders headers, OrganizationEvent organizationEvent, CancellationToken cancellationToken = default) =>
        organizationEvent.Action switch
        {
            OrganizationActionValue.Deleted
                => this.ProcessOrganizationWebhookAsync(headers, organizationEvent, OrganizationAction.Deleted, cancellationToken),
            OrganizationActionValue.MemberAdded
                => this.ProcessOrganizationWebhookAsync(headers, organizationEvent, OrganizationAction.MemberAdded, cancellationToken),
            OrganizationActionValue.MemberInvited
                => this.ProcessOrganizationWebhookAsync(headers, organizationEvent, OrganizationAction.MemberInvited, cancellationToken),
            OrganizationActionValue.MemberRemoved
                => this.ProcessOrganizationWebhookAsync(headers, organizationEvent, OrganizationAction.MemberRemoved, cancellationToken),
            OrganizationActionValue.Renamed
                => this.ProcessOrganizationWebhookAsync(headers, organizationEvent, OrganizationAction.Renamed, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessOrganizationWebhookAsync(
        WebhookHeaders headers,
        OrganizationEvent organizationEvent,
        OrganizationAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessPackageWebhookAsync(WebhookHeaders headers, PackageEvent packageEvent, CancellationToken cancellationToken = default) =>
        packageEvent.Action switch
        {
            PackageActionValue.Published => this.ProcessPackageWebhookAsync(headers, packageEvent, PackageAction.Published, cancellationToken),
            PackageActionValue.Updated => this.ProcessPackageWebhookAsync(headers, packageEvent, PackageAction.Updated, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessPackageWebhookAsync(WebhookHeaders headers, PackageEvent packageEvent, PackageAction action, CancellationToken cancellationToken = default) =>
        ValueTask.CompletedTask;

    [PublicAPI]
    protected virtual ValueTask ProcessPageBuildWebhookAsync(WebhookHeaders headers, PageBuildEvent pageBuildEvent, CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    [PublicAPI]
    protected virtual ValueTask ProcessPingWebhookAsync(WebhookHeaders headers, PingEvent pingEvent, CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessProjectWebhookAsync(WebhookHeaders headers, ProjectEvent projectEvent, CancellationToken cancellationToken = default) =>
        projectEvent.Action switch
        {
            ProjectActionValue.Closed => this.ProcessProjectWebhookAsync(headers, projectEvent, ProjectAction.Closed, cancellationToken),
            ProjectActionValue.Created => this.ProcessProjectWebhookAsync(headers, projectEvent, ProjectAction.Created, cancellationToken),
            ProjectActionValue.Deleted => this.ProcessProjectWebhookAsync(headers, projectEvent, ProjectAction.Deleted, cancellationToken),
            ProjectActionValue.Edited => this.ProcessProjectWebhookAsync(headers, projectEvent, ProjectAction.Edited, cancellationToken),
            ProjectActionValue.Reopened => this.ProcessProjectWebhookAsync(headers, projectEvent, ProjectAction.Reopened, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessProjectWebhookAsync(WebhookHeaders headers, ProjectEvent projectEvent, ProjectAction action, CancellationToken cancellationToken = default) =>
        ValueTask.CompletedTask;

    private ValueTask ProcessProjectCardWebhookAsync(WebhookHeaders headers, ProjectCardEvent projectCardEvent, CancellationToken cancellationToken = default) =>
        projectCardEvent.Action switch
        {
            ProjectCardActionValue.Converted
                => this.ProcessProjectCardWebhookAsync(headers, projectCardEvent, ProjectCardAction.Converted, cancellationToken),
            ProjectCardActionValue.Created => this.ProcessProjectCardWebhookAsync(headers, projectCardEvent, ProjectCardAction.Created, cancellationToken),
            ProjectCardActionValue.Deleted => this.ProcessProjectCardWebhookAsync(headers, projectCardEvent, ProjectCardAction.Deleted, cancellationToken),
            ProjectCardActionValue.Edited => this.ProcessProjectCardWebhookAsync(headers, projectCardEvent, ProjectCardAction.Edited, cancellationToken),
            ProjectCardActionValue.Moved => this.ProcessProjectCardWebhookAsync(headers, projectCardEvent, ProjectCardAction.Moved, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessProjectCardWebhookAsync(
        WebhookHeaders headers,
        ProjectCardEvent projectCardEvent,
        ProjectCardAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessProjectColumnWebhookAsync(WebhookHeaders headers, ProjectColumnEvent projectColumnEvent, CancellationToken cancellationToken = default) =>
        projectColumnEvent.Action switch
        {
            ProjectColumnActionValue.Created
                => this.ProcessProjectColumnWebhookAsync(headers, projectColumnEvent, ProjectColumnAction.Created, cancellationToken),
            ProjectColumnActionValue.Deleted
                => this.ProcessProjectColumnWebhookAsync(headers, projectColumnEvent, ProjectColumnAction.Deleted, cancellationToken),
            ProjectColumnActionValue.Edited
                => this.ProcessProjectColumnWebhookAsync(headers, projectColumnEvent, ProjectColumnAction.Edited, cancellationToken),
            ProjectColumnActionValue.Moved
                => this.ProcessProjectColumnWebhookAsync(headers, projectColumnEvent, ProjectColumnAction.Moved, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessProjectColumnWebhookAsync(
        WebhookHeaders headers,
        ProjectColumnEvent projectColumnEvent,
        ProjectColumnAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    [PublicAPI]
    protected virtual ValueTask ProcessProjectsV2ItemWebhookAsync(WebhookHeaders headers, ProjectsV2ItemEvent projectsV2ItemEvent, ProjectsV2ItemAction action, CancellationToken cancellationToken = default)
        => ValueTask.CompletedTask;

    private ValueTask ProcessProjectsV2ItemWebhookAsync(WebhookHeaders headers, ProjectsV2ItemEvent projectsV2ItemEvent, CancellationToken cancellationToken = default) =>
        projectsV2ItemEvent.Action switch
        {
            ProjectsV2ItemActionValue.Created => this.ProcessProjectsV2ItemWebhookAsync(headers, projectsV2ItemEvent, ProjectsV2ItemAction.Created, cancellationToken),
            ProjectsV2ItemActionValue.Deleted => this.ProcessProjectsV2ItemWebhookAsync(headers, projectsV2ItemEvent, ProjectsV2ItemAction.Deleted, cancellationToken),
            ProjectsV2ItemActionValue.Edited => this.ProcessProjectsV2ItemWebhookAsync(headers, projectsV2ItemEvent, ProjectsV2ItemAction.Edited, cancellationToken),
            ProjectsV2ItemActionValue.Archived => this.ProcessProjectsV2ItemWebhookAsync(headers, projectsV2ItemEvent, ProjectsV2ItemAction.Archived, cancellationToken),
            ProjectsV2ItemActionValue.Converted => this.ProcessProjectsV2ItemWebhookAsync(headers, projectsV2ItemEvent, ProjectsV2ItemAction.Converted, cancellationToken),
            ProjectsV2ItemActionValue.Restored => this.ProcessProjectsV2ItemWebhookAsync(headers, projectsV2ItemEvent, ProjectsV2ItemAction.Restored, cancellationToken),
            ProjectsV2ItemActionValue.Reordered => this.ProcessProjectsV2ItemWebhookAsync(headers, projectsV2ItemEvent, ProjectsV2ItemAction.Reordered, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessPublicWebhookAsync(WebhookHeaders headers, PublicEvent publicEvent, CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessPullRequestWebhookAsync(WebhookHeaders headers, PullRequestEvent pullRequestEvent, CancellationToken cancellationToken = default) =>
        pullRequestEvent.Action switch
        {
            PullRequestActionValue.Assigned
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Assigned, cancellationToken),
            PullRequestActionValue.AutoMergeDisabled
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.AutoMergeDisabled, cancellationToken),
            PullRequestActionValue.AutoMergeEnabled
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.AutoMergeEnabled, cancellationToken),
            PullRequestActionValue.Closed => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Closed, cancellationToken),
            PullRequestActionValue.ConvertedToDraft
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.ConvertedToDraft, cancellationToken),
            PullRequestActionValue.Dequeued =>
                this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Dequeued, cancellationToken),
            PullRequestActionValue.Demilestoned =>
                this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Demilestoned, cancellationToken),
            PullRequestActionValue.Edited => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Edited, cancellationToken),
            PullRequestActionValue.Labeled => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Labeled, cancellationToken),
            PullRequestActionValue.Locked => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Locked, cancellationToken),
            PullRequestActionValue.Milestoned => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Milestoned, cancellationToken),
            PullRequestActionValue.Opened => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Opened, cancellationToken),
            PullRequestActionValue.Enqueued
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Enqueued, cancellationToken),
            PullRequestActionValue.ReadyForReview
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.ReadyForReview, cancellationToken),
            PullRequestActionValue.Reopened
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Reopened, cancellationToken),
            PullRequestActionValue.ReviewRequestRemoved
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.ReviewRequestRemoved, cancellationToken),
            PullRequestActionValue.ReviewRequested
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.ReviewRequested, cancellationToken),
            PullRequestActionValue.Synchronize
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Synchronize, cancellationToken),
            PullRequestActionValue.Unassigned
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Unassigned, cancellationToken),
            PullRequestActionValue.Unlabeled
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Unlabeled, cancellationToken),
            PullRequestActionValue.Unlocked
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Unlocked, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessPullRequestWebhookAsync(
        WebhookHeaders headers,
        PullRequestEvent pullRequestEvent,
        PullRequestAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessPullRequestReviewWebhookAsync(WebhookHeaders headers, PullRequestReviewEvent pullRequestReviewEvent, CancellationToken cancellationToken = default) =>
        pullRequestReviewEvent.Action switch
        {
            PullRequestReviewActionValue.Dismissed
                => this.ProcessPullRequestReviewWebhookAsync(headers, pullRequestReviewEvent, PullRequestReviewAction.Dismissed, cancellationToken),
            PullRequestReviewActionValue.Edited
                => this.ProcessPullRequestReviewWebhookAsync(headers, pullRequestReviewEvent, PullRequestReviewAction.Edited, cancellationToken),
            PullRequestReviewActionValue.Submitted
                => this.ProcessPullRequestReviewWebhookAsync(headers, pullRequestReviewEvent, PullRequestReviewAction.Submitted, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessPullRequestReviewWebhookAsync(
        WebhookHeaders headers,
        PullRequestReviewEvent pullRequestReviewEvent,
        PullRequestReviewAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessPullRequestReviewCommentWebhookAsync(
        WebhookHeaders headers,
        PullRequestReviewCommentEvent pullRequestReviewCommentEvent,
        CancellationToken cancellationToken = default) =>
        pullRequestReviewCommentEvent.Action switch
        {
            PullRequestReviewCommentActionValue.Created
                => this.ProcessPullRequestReviewCommentWebhookAsync(
                    headers,
                    pullRequestReviewCommentEvent,
                    PullRequestReviewCommentAction.Created,
                    cancellationToken),
            PullRequestReviewCommentActionValue.Deleted
                => this.ProcessPullRequestReviewCommentWebhookAsync(
                    headers,
                    pullRequestReviewCommentEvent,
                    PullRequestReviewCommentAction.Deleted,
                    cancellationToken),
            PullRequestReviewCommentActionValue.Edited
                => this.ProcessPullRequestReviewCommentWebhookAsync(
                    headers,
                    pullRequestReviewCommentEvent,
                    PullRequestReviewCommentAction.Edited,
                    cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessPullRequestReviewCommentWebhookAsync(
        WebhookHeaders headers,
        PullRequestReviewCommentEvent pullRequestReviewCommentEvent,
        PullRequestReviewCommentAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessPullRequestReviewThreadWebhookAsync(
        WebhookHeaders headers,
        PullRequestReviewThreadEvent pullRequestReviewThreadEvent,
        CancellationToken cancellationToken = default) =>
        pullRequestReviewThreadEvent.Action switch
        {
            PullRequestReviewThreadActionValue.Resolved
                => this.ProcessPullRequestReviewThreadWebhookAsync(
                    headers,
                    pullRequestReviewThreadEvent,
                    PullRequestReviewThreadAction.Resolved,
                    cancellationToken),
            PullRequestReviewThreadActionValue.Unresolved
                => this.ProcessPullRequestReviewThreadWebhookAsync(
                    headers,
                    pullRequestReviewThreadEvent,
                    PullRequestReviewThreadAction.Unresolved,
                    cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessPullRequestReviewThreadWebhookAsync(
        WebhookHeaders headers,
        PullRequestReviewThreadEvent pullRequestReviewThreadEvent,
        PullRequestReviewThreadAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    [PublicAPI]
    protected virtual ValueTask ProcessPushWebhookAsync(WebhookHeaders headers, PushEvent pushEvent, CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessReleaseWebhookAsync(WebhookHeaders headers, ReleaseEvent releaseEvent, CancellationToken cancellationToken = default) =>
        releaseEvent.Action switch
        {
            ReleaseActionValue.Created => this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Created, cancellationToken),
            ReleaseActionValue.Deleted => this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Deleted, cancellationToken),
            ReleaseActionValue.Edited => this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Edited, cancellationToken),
            ReleaseActionValue.Prereleased => this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Prereleased, cancellationToken),
            ReleaseActionValue.Published => this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Published, cancellationToken),
            ReleaseActionValue.Released => this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Released, cancellationToken),
            ReleaseActionValue.Unpublished => this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Unpublished, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessReleaseWebhookAsync(WebhookHeaders headers, ReleaseEvent releaseEvent, ReleaseAction action, CancellationToken cancellationToken = default) =>
        ValueTask.CompletedTask;

    private ValueTask ProcessRegistryPackageWebhookAsync(WebhookHeaders headers, RegistryPackageEvent registryPackageEvent, CancellationToken cancellationToken = default) =>
        registryPackageEvent.Action switch
        {
            RegistryPackageActionValue.Published => this.ProcessRegistryPackageWebhookAsync(
                headers,
                registryPackageEvent,
                RegistryPackageAction.Published,
                cancellationToken),
            RegistryPackageActionValue.Updated => this.ProcessRegistryPackageWebhookAsync(
                headers,
                registryPackageEvent,
                RegistryPackageAction.Published,
                cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessRegistryPackageWebhookAsync(
        WebhookHeaders headers,
        RegistryPackageEvent registryPackageEvent,
        RegistryPackageAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessRepositoryWebhookAsync(WebhookHeaders headers, RepositoryEvent repositoryEvent, CancellationToken cancellationToken = default) =>
        repositoryEvent.Action switch
        {
            RepositoryActionValue.Archived => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Archived, cancellationToken),
            RepositoryActionValue.Created => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Created, cancellationToken),
            RepositoryActionValue.Deleted => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Deleted, cancellationToken),
            RepositoryActionValue.Edited => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Edited, cancellationToken),
            RepositoryActionValue.Privatized
                => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Privatized, cancellationToken),
            RepositoryActionValue.Publicized
                => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Publicized, cancellationToken),
            RepositoryActionValue.Renamed => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Renamed, cancellationToken),
            RepositoryActionValue.Transferred
                => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Transferred, cancellationToken),
            RepositoryActionValue.Unarchived
                => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Unarchived, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessRepositoryWebhookAsync(
        WebhookHeaders headers,
        RepositoryEvent repositoryEvent,
        RepositoryAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessRepositoryAdvisoryWebhookAsync(WebhookHeaders headers, RepositoryAdvisoryEvent repositoryAdvisoryEvent, CancellationToken cancellationToken = default) =>
        repositoryAdvisoryEvent.Action switch
        {
            RepositoryAdvisoryActionValue.Reported => this.ProcessRepositoryAdvisoryWebhookAsync(
                headers,
                repositoryAdvisoryEvent,
                RepositoryAdvisoryAction.Reported,
                cancellationToken),
            RepositoryAdvisoryActionValue.Published => this.ProcessRepositoryAdvisoryWebhookAsync(
                headers,
                repositoryAdvisoryEvent,
                RepositoryAdvisoryAction.Published,
                cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessRepositoryAdvisoryWebhookAsync(
        WebhookHeaders headers,
        RepositoryAdvisoryEvent repositoryAdvisoryEvent,
        RepositoryAdvisoryAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessRepositoryDispatchWebhookAsync(WebhookHeaders headers, RepositoryDispatchEvent repositoryDispatchEvent, CancellationToken cancellationToken = default) =>
        repositoryDispatchEvent.Action switch
        {
            RepositoryDispatchActionValue.OnDemandTest
                => this.ProcessRepositoryDispatchWebhookAsync(headers, repositoryDispatchEvent, RepositoryDispatchAction.OnDemandTest, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessRepositoryDispatchWebhookAsync(
        WebhookHeaders headers,
        RepositoryDispatchEvent repositoryDispatchEvent,
        RepositoryDispatchAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    [PublicAPI]
    protected virtual ValueTask ProcessRepositoryImportWebhookAsync(WebhookHeaders headers, RepositoryImportEvent repositoryImportEvent, CancellationToken cancellationToken = default) =>
        ValueTask.CompletedTask;

    private ValueTask ProcessRepositoryRulesetWebhookAsync(WebhookHeaders headers, RepositoryRulesetEvent repositoryRulesetEvent, CancellationToken cancellationToken = default) =>
        repositoryRulesetEvent.Action switch
        {
            RepositoryRulesetActionValue.Created => this.ProcessRepositoryRulesetWebhookAsync(
                headers,
                repositoryRulesetEvent,
                RepositoryRulesetAction.Created,
                cancellationToken),
            RepositoryRulesetActionValue.Deleted => this.ProcessRepositoryRulesetWebhookAsync(
                headers,
                repositoryRulesetEvent,
                RepositoryRulesetAction.Deleted,
                cancellationToken),
            RepositoryRulesetActionValue.Edited => this.ProcessRepositoryRulesetWebhookAsync(
                headers,
                repositoryRulesetEvent,
                RepositoryRulesetAction.Edited,
                cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessRepositoryRulesetWebhookAsync(
        WebhookHeaders headers,
        RepositoryRulesetEvent repositoryRulesetEvent,
        RepositoryRulesetAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessRepositoryVulnerabilityAlertWebhookAsync(
        WebhookHeaders headers,
        RepositoryVulnerabilityAlertEvent repositoryVulnerabilityAlertEvent,
        CancellationToken cancellationToken = default) =>
        repositoryVulnerabilityAlertEvent.Action switch
        {
            RepositoryVulnerabilityAlertActionValue.Create
                => this.ProcessRepositoryVulnerabilityAlertWebhookAsync(
                    headers,
                    repositoryVulnerabilityAlertEvent,
                    RepositoryVulnerabilityAlertAction.Create,
                    cancellationToken),
            RepositoryVulnerabilityAlertActionValue.Dismiss
                => this.ProcessRepositoryVulnerabilityAlertWebhookAsync(
                    headers,
                    repositoryVulnerabilityAlertEvent,
                    RepositoryVulnerabilityAlertAction.Dismiss,
                    cancellationToken),
            RepositoryVulnerabilityAlertActionValue.Resolve
                => this.ProcessRepositoryVulnerabilityAlertWebhookAsync(
                    headers,
                    repositoryVulnerabilityAlertEvent,
                    RepositoryVulnerabilityAlertAction.Resolve,
                    cancellationToken),
            RepositoryVulnerabilityAlertActionValue.Reopen
                => this.ProcessRepositoryVulnerabilityAlertWebhookAsync(headers, repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction.Reopen, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessRepositoryVulnerabilityAlertWebhookAsync(
        WebhookHeaders headers,
        RepositoryVulnerabilityAlertEvent repositoryVulnerabilityAlertEvent,
        RepositoryVulnerabilityAlertAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessSecretScanningAlertWebhookAsync(WebhookHeaders headers, SecretScanningAlertEvent secretScanningAlertEvent, CancellationToken cancellationToken = default) =>
        secretScanningAlertEvent.Action switch
        {
            SecretScanningAlertActionValue.Created
                => this.ProcessSecretScanningAlertWebhookAsync(headers, secretScanningAlertEvent, SecretScanningAlertAction.Created, cancellationToken),
            SecretScanningAlertActionValue.Reopened
                => this.ProcessSecretScanningAlertWebhookAsync(headers, secretScanningAlertEvent, SecretScanningAlertAction.Reopened, cancellationToken),
            SecretScanningAlertActionValue.Resolved
                => this.ProcessSecretScanningAlertWebhookAsync(headers, secretScanningAlertEvent, SecretScanningAlertAction.Resolved, cancellationToken),
            SecretScanningAlertActionValue.Revoked
                => this.ProcessSecretScanningAlertWebhookAsync(headers, secretScanningAlertEvent, SecretScanningAlertAction.Revoked, cancellationToken),
            SecretScanningAlertActionValue.Assigned
                => this.ProcessSecretScanningAlertWebhookAsync(headers, secretScanningAlertEvent, SecretScanningAlertAction.Assigned, cancellationToken),
            SecretScanningAlertActionValue.PubliclyLeaked
                => this.ProcessSecretScanningAlertWebhookAsync(headers, secretScanningAlertEvent, SecretScanningAlertAction.PubliclyLeaked, cancellationToken),
            SecretScanningAlertActionValue.Unassigned
                => this.ProcessSecretScanningAlertWebhookAsync(headers, secretScanningAlertEvent, SecretScanningAlertAction.Unassigned, cancellationToken),
            SecretScanningAlertActionValue.Validated
                => this.ProcessSecretScanningAlertWebhookAsync(headers, secretScanningAlertEvent, SecretScanningAlertAction.Validated, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessSecretScanningAlertWebhookAsync(
        WebhookHeaders headers,
        SecretScanningAlertEvent secretScanningAlertEvent,
        SecretScanningAlertAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessSecretScanningAlertLocationWebhookAsync(WebhookHeaders headers, SecretScanningAlertLocationEvent secretScanningAlertLocationEvent, CancellationToken cancellationToken = default) =>
        secretScanningAlertLocationEvent.Action switch
        {
            SecretScanningAlertLocationActionValue.Created
                => this.ProcessSecretScanningAlertLocationWebhookAsync(headers, secretScanningAlertLocationEvent, SecretScanningAlertLocationAction.Created, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessSecretScanningAlertLocationWebhookAsync(
        WebhookHeaders headers,
        SecretScanningAlertLocationEvent secretScanningAlertLocationEvent,
        SecretScanningAlertLocationAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessSecurityAdvisoryWebhookAsync(WebhookHeaders headers, SecurityAdvisoryEvent securityAdvisoryEvent, CancellationToken cancellationToken = default) =>
        securityAdvisoryEvent.Action switch
        {
            SecurityAdvisoryActionValue.Performed
                => this.ProcessSecurityAdvisoryWebhookAsync(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Performed, cancellationToken),
            SecurityAdvisoryActionValue.Published
                => this.ProcessSecurityAdvisoryWebhookAsync(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Published, cancellationToken),
            SecurityAdvisoryActionValue.Updated
                => this.ProcessSecurityAdvisoryWebhookAsync(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Updated, cancellationToken),
            SecurityAdvisoryActionValue.Withdrawn
                => this.ProcessSecurityAdvisoryWebhookAsync(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Withdrawn, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessSecurityAdvisoryWebhookAsync(
        WebhookHeaders headers,
        SecurityAdvisoryEvent securityAdvisoryEvent,
        SecurityAdvisoryAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    [PublicAPI]
    protected virtual ValueTask ProcessSecurityAndAnalysisWebhookAsync(WebhookHeaders headers, SecurityAndAnalysisEvent securityAndAnalysisEvent, CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessSponsorshipWebhookAsync(WebhookHeaders headers, SponsorshipEvent sponsorshipEvent, CancellationToken cancellationToken = default) =>
        sponsorshipEvent.Action switch
        {
            SponsorshipActionValue.Cancelled
                => this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.Cancelled, cancellationToken),
            SponsorshipActionValue.Created => this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.Created, cancellationToken),
            SponsorshipActionValue.Edited => this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.Edited, cancellationToken),
            SponsorshipActionValue.PendingCancellation
                => this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.PendingCancellation, cancellationToken),
            SponsorshipActionValue.PendingTierChange
                => this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.PendingTierChange, cancellationToken),
            SponsorshipActionValue.TierChanged
                => this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.TierChanged, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessSponsorshipWebhookAsync(
        WebhookHeaders headers,
        SponsorshipEvent sponsorshipEvent,
        SponsorshipAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessStarWebhookAsync(WebhookHeaders headers, StarEvent starEvent, CancellationToken cancellationToken = default) =>
        starEvent.Action switch
        {
            StarActionValue.Created => this.ProcessStarWebhookAsync(headers, starEvent, StarAction.Created, cancellationToken),
            StarActionValue.Deleted => this.ProcessStarWebhookAsync(headers, starEvent, StarAction.Deleted, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessStarWebhookAsync(WebhookHeaders headers, StarEvent starEvent, StarAction action, CancellationToken cancellationToken = default) =>
        ValueTask.CompletedTask;

    [PublicAPI]
    protected virtual ValueTask ProcessStatusWebhookAsync(WebhookHeaders headers, StatusEvent statusEvent, CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessSubIssuesWebhookAsync(WebhookHeaders headers, SubIssuesEvent subIssuesEvent, CancellationToken cancellationToken = default) =>
        subIssuesEvent.Action switch
        {
            SubIssuesActionValue.ParentIssueAdded => this.ProcessSubIssuesWebhookAsync(headers, subIssuesEvent, SubIssuesAction.ParentIssueAdded, cancellationToken),
            SubIssuesActionValue.ParentIssueRemoved => this.ProcessSubIssuesWebhookAsync(headers, subIssuesEvent, SubIssuesAction.ParentIssueRemoved, cancellationToken),
            SubIssuesActionValue.SubIssueAdded => this.ProcessSubIssuesWebhookAsync(headers, subIssuesEvent, SubIssuesAction.SubIssueAdded, cancellationToken),
            SubIssuesActionValue.SubIssueRemoved => this.ProcessSubIssuesWebhookAsync(headers, subIssuesEvent, SubIssuesAction.SubIssueRemoved, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessSubIssuesWebhookAsync(
        WebhookHeaders headers,
        SubIssuesEvent subIssuesEvent,
        SubIssuesAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessTeamWebhookAsync(WebhookHeaders headers, TeamEvent teamEvent, CancellationToken cancellationToken = default) =>
        teamEvent.Action switch
        {
            TeamActionValue.AddedToRepository => this.ProcessTeamWebhookAsync(headers, teamEvent, TeamAction.AddedToRepository, cancellationToken),
            TeamActionValue.Created => this.ProcessTeamWebhookAsync(headers, teamEvent, TeamAction.Created, cancellationToken),
            TeamActionValue.Deleted => this.ProcessTeamWebhookAsync(headers, teamEvent, TeamAction.Deleted, cancellationToken),
            TeamActionValue.Edited => this.ProcessTeamWebhookAsync(headers, teamEvent, TeamAction.Edited, cancellationToken),
            TeamActionValue.RemovedFromRepository => this.ProcessTeamWebhookAsync(headers, teamEvent, TeamAction.RemovedFromRepository, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessTeamWebhookAsync(WebhookHeaders headers, TeamEvent teamEvent, TeamAction action, CancellationToken cancellationToken = default) =>
        ValueTask.CompletedTask;

    [PublicAPI]
    protected virtual ValueTask ProcessTeamAddWebhookAsync(WebhookHeaders headers, TeamAddEvent teamAddEvent, CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessWatchWebhookAsync(WebhookHeaders headers, WatchEvent watchEvent, CancellationToken cancellationToken = default) =>
        watchEvent.Action switch
        {
            WatchActionValue.Started => this.ProcessWatchWebhookAsync(headers, watchEvent, WatchAction.Started, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessWatchWebhookAsync(WebhookHeaders headers, WatchEvent watchEvent, WatchAction action, CancellationToken cancellationToken = default) =>
        ValueTask.CompletedTask;

    [PublicAPI]
    protected virtual ValueTask ProcessWorkflowDispatchWebhookAsync(WebhookHeaders headers, WorkflowDispatchEvent workflowDispatchEvent, CancellationToken cancellationToken = default) =>
        ValueTask.CompletedTask;

    private ValueTask ProcessWorkflowJobWebhookAsync(WebhookHeaders headers, WorkflowJobEvent workflowJobEvent, CancellationToken cancellationToken = default) =>
        workflowJobEvent.Action switch
        {
            WorkflowJobActionValue.Queued
                => this.ProcessWorkflowJobWebhookAsync(headers, workflowJobEvent, WorkflowJobAction.Queued, cancellationToken),
            WorkflowJobActionValue.InProgress
                => this.ProcessWorkflowJobWebhookAsync(headers, workflowJobEvent, WorkflowJobAction.InProgress, cancellationToken),
            WorkflowJobActionValue.Completed
                => this.ProcessWorkflowJobWebhookAsync(headers, workflowJobEvent, WorkflowJobAction.Completed, cancellationToken),
            WorkflowJobActionValue.Waiting
                => this.ProcessWorkflowJobWebhookAsync(headers, workflowJobEvent, WorkflowJobAction.Waiting, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessWorkflowJobWebhookAsync(
        WebhookHeaders headers,
        WorkflowJobEvent workflowJobEvent,
        WorkflowJobAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessWorkflowRunWebhookAsync(WebhookHeaders headers, WorkflowRunEvent workflowRunEvent, CancellationToken cancellationToken = default) =>
        workflowRunEvent.Action switch
        {
            WorkflowRunActionValue.Completed
                => this.ProcessWorkflowRunWebhookAsync(headers, workflowRunEvent, WorkflowRunAction.Completed, cancellationToken),
            WorkflowRunActionValue.InProgress
                => this.ProcessWorkflowRunWebhookAsync(headers, workflowRunEvent, WorkflowRunAction.InProgress, cancellationToken),
            WorkflowRunActionValue.Requested
                => this.ProcessWorkflowRunWebhookAsync(headers, workflowRunEvent, WorkflowRunAction.Requested, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessWorkflowRunWebhookAsync(
        WebhookHeaders headers,
        WorkflowRunEvent workflowRunEvent,
        WorkflowRunAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessBranchProtectionConfigurationWebhookAsync(WebhookHeaders headers, BranchProtectionConfigurationEvent branchProtectionConfigurationEvent, CancellationToken cancellationToken = default) =>
        branchProtectionConfigurationEvent.Action switch
        {
            BranchProtectionConfigurationActionValue.Disabled
                => this.ProcessBranchProtectionConfigurationWebhookAsync(headers, branchProtectionConfigurationEvent, BranchProtectionConfigurationAction.Disabled, cancellationToken),
            BranchProtectionConfigurationActionValue.Enabled
                => this.ProcessBranchProtectionConfigurationWebhookAsync(headers, branchProtectionConfigurationEvent, BranchProtectionConfigurationAction.Enabled, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessBranchProtectionConfigurationWebhookAsync(
        WebhookHeaders headers,
        BranchProtectionConfigurationEvent branchProtectionConfigurationEvent,
        BranchProtectionConfigurationAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessCustomPropertyPromotedToEnterpriseWebhookAsync(WebhookHeaders headers, CustomPropertyPromotedToEnterpriseEvent customPropertyPromotedToEnterpriseEvent, CancellationToken cancellationToken = default) =>
        customPropertyPromotedToEnterpriseEvent.Action switch
        {
            CustomPropertyPromotedToEnterpriseActionValue.PromoteToEnterprise
                => this.ProcessCustomPropertyPromotedToEnterpriseWebhookAsync(headers, customPropertyPromotedToEnterpriseEvent, CustomPropertyPromotedToEnterpriseAction.PromoteToEnterprise, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessCustomPropertyPromotedToEnterpriseWebhookAsync(
        WebhookHeaders headers,
        CustomPropertyPromotedToEnterpriseEvent customPropertyPromotedToEnterpriseEvent,
        CustomPropertyPromotedToEnterpriseAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessIssueDependenciesWebhookAsync(WebhookHeaders headers, IssueDependenciesEvent issueDependenciesEvent, CancellationToken cancellationToken = default) =>
        issueDependenciesEvent.Action switch
        {
            IssueDependenciesActionValue.BlockedByAdded
                => this.ProcessIssueDependenciesWebhookAsync(headers, issueDependenciesEvent, IssueDependenciesAction.BlockedByAdded, cancellationToken),
            IssueDependenciesActionValue.BlockedByRemoved
                => this.ProcessIssueDependenciesWebhookAsync(headers, issueDependenciesEvent, IssueDependenciesAction.BlockedByRemoved, cancellationToken),
            IssueDependenciesActionValue.BlockingAdded
                => this.ProcessIssueDependenciesWebhookAsync(headers, issueDependenciesEvent, IssueDependenciesAction.BlockingAdded, cancellationToken),
            IssueDependenciesActionValue.BlockingRemoved
                => this.ProcessIssueDependenciesWebhookAsync(headers, issueDependenciesEvent, IssueDependenciesAction.BlockingRemoved, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessIssueDependenciesWebhookAsync(
        WebhookHeaders headers,
        IssueDependenciesEvent issueDependenciesEvent,
        IssueDependenciesAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessPersonalAccessTokenRequestWebhookAsync(WebhookHeaders headers, PersonalAccessTokenRequestEvent personalAccessTokenRequestEvent, CancellationToken cancellationToken = default) =>
        personalAccessTokenRequestEvent.Action switch
        {
            PersonalAccessTokenRequestActionValue.Approved
                => this.ProcessPersonalAccessTokenRequestWebhookAsync(headers, personalAccessTokenRequestEvent, PersonalAccessTokenRequestAction.Approved, cancellationToken),
            PersonalAccessTokenRequestActionValue.Cancelled
                => this.ProcessPersonalAccessTokenRequestWebhookAsync(headers, personalAccessTokenRequestEvent, PersonalAccessTokenRequestAction.Cancelled, cancellationToken),
            PersonalAccessTokenRequestActionValue.Created
                => this.ProcessPersonalAccessTokenRequestWebhookAsync(headers, personalAccessTokenRequestEvent, PersonalAccessTokenRequestAction.Created, cancellationToken),
            PersonalAccessTokenRequestActionValue.Denied
                => this.ProcessPersonalAccessTokenRequestWebhookAsync(headers, personalAccessTokenRequestEvent, PersonalAccessTokenRequestAction.Denied, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessPersonalAccessTokenRequestWebhookAsync(
        WebhookHeaders headers,
        PersonalAccessTokenRequestEvent personalAccessTokenRequestEvent,
        PersonalAccessTokenRequestAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessProjectsV2ProjectWebhookAsync(WebhookHeaders headers, ProjectsV2ProjectEvent projectsV2ProjectEvent, CancellationToken cancellationToken = default) =>
        projectsV2ProjectEvent.Action switch
        {
            ProjectsV2ProjectActionValue.Closed
                => this.ProcessProjectsV2ProjectWebhookAsync(headers, projectsV2ProjectEvent, ProjectsV2ProjectAction.Closed, cancellationToken),
            ProjectsV2ProjectActionValue.Created
                => this.ProcessProjectsV2ProjectWebhookAsync(headers, projectsV2ProjectEvent, ProjectsV2ProjectAction.Created, cancellationToken),
            ProjectsV2ProjectActionValue.Deleted
                => this.ProcessProjectsV2ProjectWebhookAsync(headers, projectsV2ProjectEvent, ProjectsV2ProjectAction.Deleted, cancellationToken),
            ProjectsV2ProjectActionValue.Edited
                => this.ProcessProjectsV2ProjectWebhookAsync(headers, projectsV2ProjectEvent, ProjectsV2ProjectAction.Edited, cancellationToken),
            ProjectsV2ProjectActionValue.Reopened
                => this.ProcessProjectsV2ProjectWebhookAsync(headers, projectsV2ProjectEvent, ProjectsV2ProjectAction.Reopened, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessProjectsV2ProjectWebhookAsync(
        WebhookHeaders headers,
        ProjectsV2ProjectEvent projectsV2ProjectEvent,
        ProjectsV2ProjectAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessProjectsV2StatusUpdateWebhookAsync(WebhookHeaders headers, ProjectsV2StatusUpdateEvent projectsV2StatusUpdateEvent, CancellationToken cancellationToken = default) =>
        projectsV2StatusUpdateEvent.Action switch
        {
            ProjectsV2StatusUpdateActionValue.Created
                => this.ProcessProjectsV2StatusUpdateWebhookAsync(headers, projectsV2StatusUpdateEvent, ProjectsV2StatusUpdateAction.Created, cancellationToken),
            ProjectsV2StatusUpdateActionValue.Deleted
                => this.ProcessProjectsV2StatusUpdateWebhookAsync(headers, projectsV2StatusUpdateEvent, ProjectsV2StatusUpdateAction.Deleted, cancellationToken),
            ProjectsV2StatusUpdateActionValue.Edited
                => this.ProcessProjectsV2StatusUpdateWebhookAsync(headers, projectsV2StatusUpdateEvent, ProjectsV2StatusUpdateAction.Edited, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessProjectsV2StatusUpdateWebhookAsync(
        WebhookHeaders headers,
        ProjectsV2StatusUpdateEvent projectsV2StatusUpdateEvent,
        ProjectsV2StatusUpdateAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;

    private ValueTask ProcessSecretScanningScanWebhookAsync(WebhookHeaders headers, SecretScanningScanEvent secretScanningScanEvent, CancellationToken cancellationToken = default) =>
        secretScanningScanEvent.Action switch
        {
            SecretScanningScanActionValue.Completed
                => this.ProcessSecretScanningScanWebhookAsync(headers, secretScanningScanEvent, SecretScanningScanAction.Completed, cancellationToken),
            _ => ValueTask.CompletedTask,
        };

    [PublicAPI]
    protected virtual ValueTask ProcessSecretScanningScanWebhookAsync(
        WebhookHeaders headers,
        SecretScanningScanEvent secretScanningScanEvent,
        SecretScanningScanAction action,
        CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
}
