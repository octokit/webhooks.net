namespace Octokit.Webhooks;

using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Octokit.Webhooks.Events;
using Octokit.Webhooks.Events.BranchProtectionRule;
using Octokit.Webhooks.Events.CheckRun;
using Octokit.Webhooks.Events.CheckSuite;
using Octokit.Webhooks.Events.CodeScanningAlert;
using Octokit.Webhooks.Events.CommitComment;
using Octokit.Webhooks.Events.ContentReference;
using Octokit.Webhooks.Events.DependabotAlert;
using Octokit.Webhooks.Events.DeployKey;
using Octokit.Webhooks.Events.Deployment;
using Octokit.Webhooks.Events.DeploymentProtectionRule;
using Octokit.Webhooks.Events.DeploymentStatus;
using Octokit.Webhooks.Events.Discussion;
using Octokit.Webhooks.Events.DiscussionComment;
using Octokit.Webhooks.Events.GithubAppAuthorization;
using Octokit.Webhooks.Events.Installation;
using Octokit.Webhooks.Events.InstallationRepositories;
using Octokit.Webhooks.Events.InstallationTarget;
using Octokit.Webhooks.Events.IssueComment;
using Octokit.Webhooks.Events.Issues;
using Octokit.Webhooks.Events.Label;
using Octokit.Webhooks.Events.MarketplacePurchase;
using Octokit.Webhooks.Events.Member;
using Octokit.Webhooks.Events.Membership;
using Octokit.Webhooks.Events.MergeGroup;
using Octokit.Webhooks.Events.Meta;
using Octokit.Webhooks.Events.Milestone;
using Octokit.Webhooks.Events.Organization;
using Octokit.Webhooks.Events.OrgBlock;
using Octokit.Webhooks.Events.Package;
using Octokit.Webhooks.Events.Project;
using Octokit.Webhooks.Events.ProjectCard;
using Octokit.Webhooks.Events.ProjectColumn;
using Octokit.Webhooks.Events.PullRequest;
using Octokit.Webhooks.Events.PullRequestReview;
using Octokit.Webhooks.Events.PullRequestReviewComment;
using Octokit.Webhooks.Events.PullRequestReviewThread;
using Octokit.Webhooks.Events.RegistryPackage;
using Octokit.Webhooks.Events.Release;
using Octokit.Webhooks.Events.Repository;
using Octokit.Webhooks.Events.RepositoryDispatch;
using Octokit.Webhooks.Events.RepositoryVulnerabilityAlert;
using Octokit.Webhooks.Events.SecretScanningAlert;
using Octokit.Webhooks.Events.SecurityAdvisory;
using Octokit.Webhooks.Events.Sponsorship;
using Octokit.Webhooks.Events.Star;
using Octokit.Webhooks.Events.Team;
using Octokit.Webhooks.Events.Watch;
using Octokit.Webhooks.Events.WorkflowJob;
using Octokit.Webhooks.Events.WorkflowRun;

public abstract class WebhookEventProcessor
{
    [PublicAPI]
    public virtual Task ProcessWebhookAsync(IDictionary<string, StringValues> headers, string body)
    {
        ArgumentNullException.ThrowIfNull(headers);
        ArgumentNullException.ThrowIfNull(body);

        var webhookHeaders = WebhookHeaders.Parse(headers);
        var webhookEvent = this.DeserializeWebhookEvent(webhookHeaders, body);

        return this.ProcessWebhookAsync(webhookHeaders, webhookEvent);
    }

    [PublicAPI]
    public virtual Task ProcessWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent) =>
        webhookEvent switch
        {
            BranchProtectionRuleEvent branchProtectionRuleEvent
                => this.ProcessBranchProtectionRuleWebhookAsync(headers, branchProtectionRuleEvent),
            CheckRunEvent checkRunEvent => this.ProcessCheckRunWebhookAsync(headers, checkRunEvent),
            CheckSuiteEvent checkSuiteEvent => this.ProcessCheckSuiteWebhookAsync(headers, checkSuiteEvent),
            CodeScanningAlertEvent codeScanningAlertEvent => this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent),
            CommitCommentEvent commitCommentEvent => this.ProcessCommitCommentWebhookAsync(headers, commitCommentEvent),
            ContentReferenceEvent contentReferenceEvent => this.ProcessContentReferenceWebhookAsync(headers, contentReferenceEvent),
            CreateEvent createEvent => this.ProcessCreateWebhookAsync(headers, createEvent),
            DeleteEvent deleteEvent => this.ProcessDeleteWebhookAsync(headers, deleteEvent),
            DependabotAlertEvent dependabotAlertEvent => this.ProcessDependabotAlertWebhookAsync(headers, dependabotAlertEvent),
            DeployKeyEvent deployKeyEvent => this.ProcessDeployKeyWebhookAsync(headers, deployKeyEvent),
            DeploymentEvent deploymentEvent => this.ProcessDeploymentWebhookAsync(headers, deploymentEvent),
            DeploymentProtectionRuleEvent deploymentProtectionRuleEvent => this.ProcessDeploymentProtectionRuleWebhookAsync(headers, deploymentProtectionRuleEvent),
            DeploymentStatusEvent deploymentStatusEvent => this.ProcessDeploymentStatusWebhookAsync(headers, deploymentStatusEvent),
            DiscussionEvent discussionEvent => this.ProcessDiscussionWebhookAsync(headers, discussionEvent),
            DiscussionCommentEvent discussionCommentEvent => this.ProcessDiscussionCommentWebhookAsync(headers, discussionCommentEvent),
            ForkEvent forkEvent => this.ProcessForkWebhookAsync(headers, forkEvent),
            GithubAppAuthorizationEvent githubAppAuthorizationEvent
                => this.ProcessGithubAppAuthorizationWebhookAsync(headers, githubAppAuthorizationEvent),
            GollumEvent gollumEvent => this.ProcessGollumWebhookAsync(headers, gollumEvent),
            InstallationEvent installationEvent => this.ProcessInstallationWebhookAsync(headers, installationEvent),
            InstallationRepositoriesEvent installationRepositoriesEvent
                => this.ProcessInstallationRepositoriesWebhookAsync(headers, installationRepositoriesEvent),
            InstallationTargetEvent installationTargetEvent
                => this.ProcessInstallationTargetWebhookAsync(headers, installationTargetEvent),
            IssueCommentEvent issueCommentEvent => this.ProcessIssueCommentWebhookAsync(headers, issueCommentEvent),
            IssuesEvent issuesEvent => this.ProcessIssuesWebhookAsync(headers, issuesEvent),
            LabelEvent labelEvent => this.ProcessLabelWebhookAsync(headers, labelEvent),
            MarketplacePurchaseEvent marketplacePurchaseEvent
                => this.ProcessMarketplacePurchaseWebhookAsync(headers, marketplacePurchaseEvent),
            MemberEvent memberEvent => this.ProcessMemberWebhookAsync(headers, memberEvent),
            MergeGroupEvent mergeGroupEvent => this.ProcessMergeGroupWebhookAsync(headers, mergeGroupEvent),
            MembershipEvent membershipEvent => this.ProcessMembershipWebhookAsync(headers, membershipEvent),
            MetaEvent metaEvent => this.ProcessMetaWebhookAsync(headers, metaEvent),
            MilestoneEvent milestoneEvent => this.ProcessMilestoneWebhookAsync(headers, milestoneEvent),
            OrgBlockEvent orgBlockEvent => this.ProcessOrgBlockWebhookAsync(headers, orgBlockEvent),
            OrganizationEvent organizationEvent => this.ProcessOrganizationWebhookAsync(headers, organizationEvent),
            PackageEvent packageEvent => this.ProcessPackageWebhookAsync(headers, packageEvent),
            PageBuildEvent pageBuildEvent => this.ProcessPageBuildWebhookAsync(headers, pageBuildEvent),
            PingEvent pingEvent => this.ProcessPingWebhookAsync(headers, pingEvent),
            ProjectEvent projectEvent => this.ProcessProjectWebhookAsync(headers, projectEvent),
            ProjectCardEvent projectCardEvent => this.ProcessProjectCardWebhookAsync(headers, projectCardEvent),
            ProjectColumnEvent projectColumnEvent => this.ProcessProjectColumnWebhookAsync(headers, projectColumnEvent),
            PublicEvent publicEvent => this.ProcessPublicWebhookAsync(headers, publicEvent),
            PullRequestEvent pullRequestEvent => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent),
            PullRequestReviewEvent pullRequestReviewEvent => this.ProcessPullRequestReviewWebhookAsync(headers, pullRequestReviewEvent),
            PullRequestReviewCommentEvent pullRequestReviewCommentEvent
                => this.ProcessPullRequestReviewCommentWebhookAsync(headers, pullRequestReviewCommentEvent),
            PullRequestReviewThreadEvent pullRequestReviewThreadEvent
                => this.ProcessPullRequestReviewThreadWebhookAsync(headers, pullRequestReviewThreadEvent),
            PushEvent pushEvent => this.ProcessPushWebhookAsync(headers, pushEvent),
            ReleaseEvent releaseEvent => this.ProcessReleaseWebhookAsync(headers, releaseEvent),
            RegistryPackageEvent registryPackageEvent => this.ProcessRegistryPackageWebhookAsync(headers, registryPackageEvent),
            RepositoryEvent repositoryEvent => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent),
            RepositoryDispatchEvent repositoryDispatchEvent
                => this.ProcessRepositoryDispatchWebhookAsync(headers, repositoryDispatchEvent),
            RepositoryImportEvent repositoryImportEvent => this.ProcessRepositoryImportWebhookAsync(headers, repositoryImportEvent),
            RepositoryVulnerabilityAlertEvent repositoryVulnerabilityAlertEvent
                => this.ProcessRepositoryVulnerabilityAlertWebhookAsync(headers, repositoryVulnerabilityAlertEvent),
            SecretScanningAlertEvent secretScanningAlertEvent
                => this.ProcessSecretScanningAlertWebhookAsync(headers, secretScanningAlertEvent),
            SecurityAdvisoryEvent securityAdvisoryEvent => this.ProcessSecurityAdvisoryWebhookAsync(headers, securityAdvisoryEvent),
            SponsorshipEvent sponsorshipEvent => this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent),
            StarEvent starEvent => this.ProcessStarWebhookAsync(headers, starEvent),
            StatusEvent statusEvent => this.ProcessStatusWebhookAsync(headers, statusEvent),
            TeamEvent teamEvent => this.ProcessTeamWebhookAsync(headers, teamEvent),
            TeamAddEvent teamAddEvent => this.ProcessTeamAddWebhookAsync(headers, teamAddEvent),
            WatchEvent watchEvent => this.ProcessWatchWebhookAsync(headers, watchEvent),
            WorkflowDispatchEvent workflowDispatchEvent => this.ProcessWorkflowDispatchWebhookAsync(headers, workflowDispatchEvent),
            WorkflowJobEvent workflowJobEvent => this.ProcessWorkflowJobWebhookAsync(headers, workflowJobEvent),
            WorkflowRunEvent workflowRunEvent => this.ProcessWorkflowRunWebhookAsync(headers, workflowRunEvent),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    public virtual WebhookEvent DeserializeWebhookEvent(WebhookHeaders headers, string body) =>
        headers.Event switch
        {
            WebhookEventType.BranchProtectionRule => JsonSerializer.Deserialize<BranchProtectionRuleEvent>(body)!,
            WebhookEventType.CheckRun => JsonSerializer.Deserialize<CheckRunEvent>(body)!,
            WebhookEventType.CheckSuite => JsonSerializer.Deserialize<CheckSuiteEvent>(body)!,
            WebhookEventType.CodeScanningAlert => JsonSerializer.Deserialize<CodeScanningAlertEvent>(body)!,
            WebhookEventType.CommitComment => JsonSerializer.Deserialize<CommitCommentEvent>(body)!,
            WebhookEventType.ContentReference => JsonSerializer.Deserialize<ContentReferenceEvent>(body)!,
            WebhookEventType.Create => JsonSerializer.Deserialize<CreateEvent>(body)!,
            WebhookEventType.Delete => JsonSerializer.Deserialize<DeleteEvent>(body)!,
            WebhookEventType.DependabotAlert => JsonSerializer.Deserialize<DependabotAlertEvent>(body)!,
            WebhookEventType.DeployKey => JsonSerializer.Deserialize<DeployKeyEvent>(body)!,
            WebhookEventType.Deployment => JsonSerializer.Deserialize<DeploymentEvent>(body)!,
            WebhookEventType.DeploymentProtectionRule => JsonSerializer.Deserialize<DeploymentProtectionRuleEvent>(body)!,
            WebhookEventType.DeploymentStatus => JsonSerializer.Deserialize<DeploymentStatusEvent>(body)!,
            WebhookEventType.Discussion => JsonSerializer.Deserialize<DiscussionEvent>(body)!,
            WebhookEventType.DiscussionComment => JsonSerializer.Deserialize<DiscussionCommentEvent>(body)!,
            WebhookEventType.Fork => JsonSerializer.Deserialize<ForkEvent>(body)!,
            WebhookEventType.GithubAppAuthorization => JsonSerializer.Deserialize<GithubAppAuthorizationEvent>(body)!,
            WebhookEventType.Gollum => JsonSerializer.Deserialize<GollumEvent>(body)!,
            WebhookEventType.Installation => JsonSerializer.Deserialize<InstallationEvent>(body)!,
            WebhookEventType.InstallationRepositories => JsonSerializer.Deserialize<InstallationRepositoriesEvent>(body)!,
            WebhookEventType.InstallationTarget => JsonSerializer.Deserialize<InstallationTargetEvent>(body)!,
            WebhookEventType.IssueComment => JsonSerializer.Deserialize<IssueCommentEvent>(body)!,
            WebhookEventType.Issues => JsonSerializer.Deserialize<IssuesEvent>(body)!,
            WebhookEventType.Label => JsonSerializer.Deserialize<LabelEvent>(body)!,
            WebhookEventType.MarketplacePurchase => JsonSerializer.Deserialize<MarketplacePurchaseEvent>(body)!,
            WebhookEventType.Member => JsonSerializer.Deserialize<MemberEvent>(body)!,
            WebhookEventType.Membership => JsonSerializer.Deserialize<MembershipEvent>(body)!,
            WebhookEventType.MergeGroup => JsonSerializer.Deserialize<MergeGroupEvent>(body)!,
            WebhookEventType.Meta => JsonSerializer.Deserialize<MetaEvent>(body)!,
            WebhookEventType.Milestone => JsonSerializer.Deserialize<MilestoneEvent>(body)!,
            WebhookEventType.OrgBlock => JsonSerializer.Deserialize<OrgBlockEvent>(body)!,
            WebhookEventType.Organization => JsonSerializer.Deserialize<OrganizationEvent>(body)!,
            WebhookEventType.Package => JsonSerializer.Deserialize<PackageEvent>(body)!,
            WebhookEventType.PageBuild => JsonSerializer.Deserialize<PageBuildEvent>(body)!,
            WebhookEventType.Ping => JsonSerializer.Deserialize<PingEvent>(body)!,
            WebhookEventType.Project => JsonSerializer.Deserialize<ProjectEvent>(body)!,
            WebhookEventType.ProjectCard => JsonSerializer.Deserialize<ProjectCardEvent>(body)!,
            WebhookEventType.ProjectColumn => JsonSerializer.Deserialize<ProjectColumnEvent>(body)!,
            WebhookEventType.ProjectsV2Item => JsonSerializer.Deserialize<ProjectsV2ItemEvent>(body)!,
            WebhookEventType.Public => JsonSerializer.Deserialize<PublicEvent>(body)!,
            WebhookEventType.PullRequest => JsonSerializer.Deserialize<PullRequestEvent>(body)!,
            WebhookEventType.PullRequestReview => JsonSerializer.Deserialize<PullRequestReviewEvent>(body)!,
            WebhookEventType.PullRequestReviewComment => JsonSerializer.Deserialize<PullRequestReviewCommentEvent>(body)!,
            WebhookEventType.PullRequestReviewThread => JsonSerializer.Deserialize<PullRequestReviewThreadEvent>(body)!,
            WebhookEventType.Push => JsonSerializer.Deserialize<PushEvent>(body)!,
            WebhookEventType.Release => JsonSerializer.Deserialize<ReleaseEvent>(body)!,
            WebhookEventType.RegistryPackage => JsonSerializer.Deserialize<RegistryPackageEvent>(body)!,
            WebhookEventType.Repository => JsonSerializer.Deserialize<RepositoryEvent>(body)!,
            WebhookEventType.RepositoryDispatch => JsonSerializer.Deserialize<RepositoryDispatchEvent>(body)!,
            WebhookEventType.RepositoryImport => JsonSerializer.Deserialize<RepositoryImportEvent>(body)!,
            WebhookEventType.RepositoryVulnerabilityAlert => JsonSerializer.Deserialize<RepositoryVulnerabilityAlertEvent>(body)!,
            WebhookEventType.SecretScanningAlert => JsonSerializer.Deserialize<SecretScanningAlertEvent>(body)!,
            WebhookEventType.SecurityAdvisory => JsonSerializer.Deserialize<SecurityAdvisoryEvent>(body)!,
            WebhookEventType.Sponsorship => JsonSerializer.Deserialize<SponsorshipEvent>(body)!,
            WebhookEventType.Star => JsonSerializer.Deserialize<StarEvent>(body)!,
            WebhookEventType.Status => JsonSerializer.Deserialize<StatusEvent>(body)!,
            WebhookEventType.Team => JsonSerializer.Deserialize<TeamEvent>(body)!,
            WebhookEventType.TeamAdd => JsonSerializer.Deserialize<TeamAddEvent>(body)!,
            WebhookEventType.Watch => JsonSerializer.Deserialize<WatchEvent>(body)!,
            WebhookEventType.WorkflowDispatch => JsonSerializer.Deserialize<WorkflowDispatchEvent>(body)!,
            WebhookEventType.WorkflowJob => JsonSerializer.Deserialize<WorkflowJobEvent>(body)!,
            WebhookEventType.WorkflowRun => JsonSerializer.Deserialize<WorkflowRunEvent>(body)!,
            _ => throw new JsonException("Unable to deserialize event"),
        };

    private Task ProcessBranchProtectionRuleWebhookAsync(WebhookHeaders headers, BranchProtectionRuleEvent branchProtectionRuleEvent) =>
        branchProtectionRuleEvent.Action switch
        {
            BranchProtectionRuleActionValue.Created
                => this.ProcessBranchProtectionRuleWebhookAsync(headers, branchProtectionRuleEvent, BranchProtectionRuleAction.Created),
            BranchProtectionRuleActionValue.Deleted
                => this.ProcessBranchProtectionRuleWebhookAsync(headers, branchProtectionRuleEvent, BranchProtectionRuleAction.Deleted),
            BranchProtectionRuleActionValue.Edited
                => this.ProcessBranchProtectionRuleWebhookAsync(headers, branchProtectionRuleEvent, BranchProtectionRuleAction.Edited),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessBranchProtectionRuleWebhookAsync(
        WebhookHeaders headers,
        BranchProtectionRuleEvent branchProtectionRuleEvent,
        BranchProtectionRuleAction action) => Task.CompletedTask;

    private Task ProcessCheckRunWebhookAsync(WebhookHeaders headers, CheckRunEvent checkRunEvent) =>
        checkRunEvent.Action switch
        {
            CheckRunActionValue.Completed => this.ProcessCheckRunWebhookAsync(headers, checkRunEvent, CheckRunAction.Completed),
            CheckRunActionValue.Created => this.ProcessCheckRunWebhookAsync(headers, checkRunEvent, CheckRunAction.Created),
            CheckRunActionValue.RequestedAction
                => this.ProcessCheckRunWebhookAsync(headers, checkRunEvent, CheckRunAction.RequestedAction),
            CheckRunActionValue.Rerequested => this.ProcessCheckRunWebhookAsync(headers, checkRunEvent, CheckRunAction.Rerequested),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessCheckRunWebhookAsync(WebhookHeaders headers, CheckRunEvent checkRunEvent, CheckRunAction action) =>
        Task.CompletedTask;

    private Task ProcessCheckSuiteWebhookAsync(WebhookHeaders headers, CheckSuiteEvent checkSuiteEvent) =>
        checkSuiteEvent.Action switch
        {
            CheckSuiteActionValue.Completed => this.ProcessCheckSuiteWebhookAsync(headers, checkSuiteEvent, CheckSuiteAction.Completed),
            CheckSuiteActionValue.Requested => this.ProcessCheckSuiteWebhookAsync(headers, checkSuiteEvent, CheckSuiteAction.Requested),
            CheckSuiteActionValue.Rerequested
                => this.ProcessCheckSuiteWebhookAsync(headers, checkSuiteEvent, CheckSuiteAction.Rerequested),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessCheckSuiteWebhookAsync(
        WebhookHeaders headers,
        CheckSuiteEvent checkSuiteEvent,
        CheckSuiteAction action) => Task.CompletedTask;

    private Task ProcessCodeScanningAlertWebhookAsync(WebhookHeaders headers, CodeScanningAlertEvent codeScanningAlertEvent) =>
        codeScanningAlertEvent.Action switch
        {
            CodeScanningAlertActionValue.AppearedInBranch
                => this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.AppearedInBranch),
            CodeScanningAlertActionValue.ClosedByUser
                => this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.ClosedByUser),
            CodeScanningAlertActionValue.Created
                => this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.Created),
            CodeScanningAlertActionValue.Fixed
                => this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.Fixed),
            CodeScanningAlertActionValue.Reopened
                => this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.Reopened),
            CodeScanningAlertActionValue.ReopenedByUser
                => this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.ReopenedByUser),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessCodeScanningAlertWebhookAsync(
        WebhookHeaders headers,
        CodeScanningAlertEvent codeScanningAlertEvent,
        CodeScanningAlertAction action) => Task.CompletedTask;

    private Task ProcessCommitCommentWebhookAsync(WebhookHeaders headers, CommitCommentEvent commitCommentEvent) =>
        commitCommentEvent.Action switch
        {
            CommitCommentActionValue.Created
                => this.ProcessCommitCommentWebhookAsync(headers, commitCommentEvent, CommitCommentAction.Created),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessCommitCommentWebhookAsync(
        WebhookHeaders headers,
        CommitCommentEvent commitCommentEvent,
        CommitCommentAction action) => Task.CompletedTask;

    private Task ProcessContentReferenceWebhookAsync(WebhookHeaders headers, ContentReferenceEvent contentReferenceEvent) =>
        contentReferenceEvent.Action switch
        {
            ContentReferenceActionValue.Created
                => this.ProcessContentReferenceWebhookAsync(headers, contentReferenceEvent, ContentReferenceAction.Created),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessContentReferenceWebhookAsync(
        WebhookHeaders headers,
        ContentReferenceEvent contentReferenceEvent,
        ContentReferenceAction action) => Task.CompletedTask;

    [PublicAPI]
    protected virtual Task ProcessCreateWebhookAsync(WebhookHeaders headers, CreateEvent createEvent) => Task.CompletedTask;

    [PublicAPI]
    protected virtual Task ProcessDeleteWebhookAsync(WebhookHeaders headers, DeleteEvent deleteEvent) => Task.CompletedTask;

    private Task ProcessDependabotAlertWebhookAsync(WebhookHeaders headers, DependabotAlertEvent dependabotAlertEvent) =>
        dependabotAlertEvent.Action switch
        {
            DependabotAlertActionValue.Created
                => this.ProcessDependabotAlertWebhookAsync(headers, dependabotAlertEvent, DependabotAlertAction.Created),
            DependabotAlertActionValue.Dismissed
                => this.ProcessDependabotAlertWebhookAsync(headers, dependabotAlertEvent, DependabotAlertAction.Dismissed),
            DependabotAlertActionValue.Fixed
                => this.ProcessDependabotAlertWebhookAsync(headers, dependabotAlertEvent, DependabotAlertAction.Fixed),
            DependabotAlertActionValue.Reintroduced
                => this.ProcessDependabotAlertWebhookAsync(headers, dependabotAlertEvent, DependabotAlertAction.Reintroduced),
            DependabotAlertActionValue.Reopened
                => this.ProcessDependabotAlertWebhookAsync(headers, dependabotAlertEvent, DependabotAlertAction.Reopened),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessDependabotAlertWebhookAsync(
        WebhookHeaders headers,
        DependabotAlertEvent dependabotAlertEvent,
        DependabotAlertAction action) => Task.CompletedTask;

    private Task ProcessDeployKeyWebhookAsync(WebhookHeaders headers, DeployKeyEvent deployKeyEvent) =>
        deployKeyEvent.Action switch
        {
            DeployKeyActionValue.Created => this.ProcessDeployKeyWebhookAsync(headers, deployKeyEvent, DeployKeyAction.Created),
            DeployKeyActionValue.Deleted => this.ProcessDeployKeyWebhookAsync(headers, deployKeyEvent, DeployKeyAction.Deleted),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessDeployKeyWebhookAsync(
        WebhookHeaders headers,
        DeployKeyEvent deployKeyEvent,
        DeployKeyAction action) => Task.CompletedTask;

    private Task ProcessDeploymentWebhookAsync(WebhookHeaders headers, DeploymentEvent deploymentEvent) =>
        deploymentEvent.Action switch
        {
            DeploymentActionValue.Created => this.ProcessDeploymentWebhookAsync(headers, deploymentEvent, DeploymentAction.Created),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessDeploymentWebhookAsync(
        WebhookHeaders headers,
        DeploymentEvent deploymentEvent,
        DeploymentAction action) => Task.CompletedTask;

    private Task ProcessDeploymentProtectionRuleWebhookAsync(WebhookHeaders headers, DeploymentProtectionRuleEvent deploymentProtectionRuleEvent) =>
        deploymentProtectionRuleEvent.Action switch
        {
            DeploymentProtectionRuleActionValue.Requested => this.ProcessDeployProtectionRuleWebhookAsync(headers, deploymentProtectionRuleEvent, DeploymentProtectionRuleAction.Requested),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessDeployProtectionRuleWebhookAsync(
        WebhookHeaders headers,
        DeploymentProtectionRuleEvent deploymentProtectionRuleEvent,
        DeploymentProtectionRuleAction action) => Task.CompletedTask;

    private Task ProcessDeploymentStatusWebhookAsync(WebhookHeaders headers, DeploymentStatusEvent deploymentStatusEvent) =>
        deploymentStatusEvent.Action switch
        {
            DeploymentStatusActionValue.Created
                => this.ProcessDeploymentStatusWebhookAsync(headers, deploymentStatusEvent, DeploymentStatusAction.Created),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessDeploymentStatusWebhookAsync(
        WebhookHeaders headers,
        DeploymentStatusEvent deploymentStatusEvent,
        DeploymentStatusAction action) => Task.CompletedTask;

    private Task ProcessDiscussionWebhookAsync(WebhookHeaders headers, DiscussionEvent discussionEvent) =>
        discussionEvent.Action switch
        {
            DiscussionActionValue.Answered => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Answered),
            DiscussionActionValue.CategoryChanged
                => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.CategoryChanged),
            DiscussionActionValue.Created => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Created),
            DiscussionActionValue.Deleted => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Deleted),
            DiscussionActionValue.Edited => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Edited),
            DiscussionActionValue.Labeled => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Labeled),
            DiscussionActionValue.Locked => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Locked),
            DiscussionActionValue.Pinned => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Pinned),
            DiscussionActionValue.Transferred
                => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Transferred),
            DiscussionActionValue.Unanswered
                => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Unanswered),
            DiscussionActionValue.Unlabeled => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Unlabeled),
            DiscussionActionValue.Unlocked => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Unlocked),
            DiscussionActionValue.Unpinned => this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Unpinned),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessDiscussionWebhookAsync(
        WebhookHeaders headers,
        DiscussionEvent discussionEvent,
        DiscussionAction action) => Task.CompletedTask;

    private Task ProcessDiscussionCommentWebhookAsync(WebhookHeaders headers, DiscussionCommentEvent discussionCommentEvent) =>
        discussionCommentEvent.Action switch
        {
            DiscussionCommentActionValue.Created
                => this.ProcessDiscussionCommentWebhookAsync(headers, discussionCommentEvent, DiscussionCommentAction.Created),
            DiscussionCommentActionValue.Deleted
                => this.ProcessDiscussionCommentWebhookAsync(headers, discussionCommentEvent, DiscussionCommentAction.Deleted),
            DiscussionCommentActionValue.Edited
                => this.ProcessDiscussionCommentWebhookAsync(headers, discussionCommentEvent, DiscussionCommentAction.Edited),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessDiscussionCommentWebhookAsync(
        WebhookHeaders headers,
        DiscussionCommentEvent discussionCommentEvent,
        DiscussionCommentAction action) => Task.CompletedTask;

    [PublicAPI]
    protected virtual Task ProcessForkWebhookAsync(WebhookHeaders headers, ForkEvent forkEvent) => Task.CompletedTask;

    private Task ProcessGithubAppAuthorizationWebhookAsync(
        WebhookHeaders headers,
        GithubAppAuthorizationEvent githubAppAuthorizationEvent) =>
        githubAppAuthorizationEvent.Action switch
        {
            GithubAppAuthorizationActionValue.Revoked
                => this.ProcessGithubAppAuthorizationWebhookAsync(
                    headers,
                    githubAppAuthorizationEvent,
                    GithubAppAuthorizationAction.Revoked),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessGithubAppAuthorizationWebhookAsync(
        WebhookHeaders headers,
        GithubAppAuthorizationEvent githubAppAuthorizationEvent,
        GithubAppAuthorizationAction action) => Task.CompletedTask;

    [PublicAPI]
    protected virtual Task ProcessGollumWebhookAsync(WebhookHeaders headers, GollumEvent gollumEvent) => Task.CompletedTask;

    private Task ProcessInstallationWebhookAsync(WebhookHeaders headers, InstallationEvent installationEvent) =>
        installationEvent.Action switch
        {
            InstallationActionValue.Created
                => this.ProcessInstallationWebhookAsync(headers, installationEvent, InstallationAction.Created),
            InstallationActionValue.Deleted
                => this.ProcessInstallationWebhookAsync(headers, installationEvent, InstallationAction.Deleted),
            InstallationActionValue.NewPermissionsAccepted
                => this.ProcessInstallationWebhookAsync(headers, installationEvent, InstallationAction.NewPermissionsAccepted),
            InstallationActionValue.Suspend
                => this.ProcessInstallationWebhookAsync(headers, installationEvent, InstallationAction.Suspend),
            InstallationActionValue.Unsuspend
                => this.ProcessInstallationWebhookAsync(headers, installationEvent, InstallationAction.Unsuspend),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessInstallationWebhookAsync(
        WebhookHeaders headers,
        InstallationEvent installationEvent,
        InstallationAction action) => Task.CompletedTask;

    private Task ProcessInstallationRepositoriesWebhookAsync(
        WebhookHeaders headers,
        InstallationRepositoriesEvent installationRepositoriesEvent) =>
        installationRepositoriesEvent.Action switch
        {
            InstallationRepositoriesActionValue.Added
                => this.ProcessInstallationRepositoriesWebhookAsync(
                    headers,
                    installationRepositoriesEvent,
                    InstallationRepositoriesAction.Added),
            InstallationRepositoriesActionValue.Removed
                => this.ProcessInstallationRepositoriesWebhookAsync(
                    headers,
                    installationRepositoriesEvent,
                    InstallationRepositoriesAction.Removed),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessInstallationTargetWebhookAsync(
        WebhookHeaders headers,
        InstallationTargetEvent installationTargetEvent,
        InstallationTargetAction action) => Task.CompletedTask;

    private Task ProcessInstallationTargetWebhookAsync(
        WebhookHeaders headers,
        InstallationTargetEvent installationTargetEvent) =>
        installationTargetEvent.Action switch
        {
            InstallationTargetActionValue.Renamed
                => this.ProcessInstallationTargetWebhookAsync(
                    headers,
                    installationTargetEvent,
                    InstallationTargetAction.Renamed),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessInstallationRepositoriesWebhookAsync(
        WebhookHeaders headers,
        InstallationRepositoriesEvent installationRepositoriesEvent,
        InstallationRepositoriesAction action) => Task.CompletedTask;

    private Task ProcessIssueCommentWebhookAsync(WebhookHeaders headers, IssueCommentEvent issueCommentEvent) =>
        issueCommentEvent.Action switch
        {
            IssueCommentActionValue.Created
                => this.ProcessIssueCommentWebhookAsync(headers, issueCommentEvent, IssueCommentAction.Created),
            IssueCommentActionValue.Deleted
                => this.ProcessIssueCommentWebhookAsync(headers, issueCommentEvent, IssueCommentAction.Deleted),
            IssueCommentActionValue.Edited
                => this.ProcessIssueCommentWebhookAsync(headers, issueCommentEvent, IssueCommentAction.Edited),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessIssueCommentWebhookAsync(
        WebhookHeaders headers,
        IssueCommentEvent issueCommentEvent,
        IssueCommentAction action) => Task.CompletedTask;

    private Task ProcessIssuesWebhookAsync(WebhookHeaders headers, IssuesEvent issuesEvent) =>
        issuesEvent.Action switch
        {
            IssuesActionValue.Assigned => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Assigned),
            IssuesActionValue.Closed => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Closed),
            IssuesActionValue.Deleted => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Deleted),
            IssuesActionValue.Demilestoned => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Demilestoned),
            IssuesActionValue.Edited => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Edited),
            IssuesActionValue.Labeled => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Labeled),
            IssuesActionValue.Locked => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Locked),
            IssuesActionValue.Milestoned => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Milestoned),
            IssuesActionValue.Opened => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Opened),
            IssuesActionValue.Pinned => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Pinned),
            IssuesActionValue.Reopened => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Reopened),
            IssuesActionValue.Transferred => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Transferred),
            IssuesActionValue.Unassigned => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Unassigned),
            IssuesActionValue.Unlabeled => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Unlabeled),
            IssuesActionValue.Unlocked => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Unlocked),
            IssuesActionValue.Unpinned => this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Unpinned),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessIssuesWebhookAsync(WebhookHeaders headers, IssuesEvent issuesEvent, IssuesAction action) =>
        Task.CompletedTask;

    private Task ProcessLabelWebhookAsync(WebhookHeaders headers, LabelEvent labelEvent) =>
        labelEvent.Action switch
        {
            LabelActionValue.Created => this.ProcessLabelWebhookAsync(headers, labelEvent, LabelAction.Created),
            LabelActionValue.Deleted => this.ProcessLabelWebhookAsync(headers, labelEvent, LabelAction.Deleted),
            LabelActionValue.Edited => this.ProcessLabelWebhookAsync(headers, labelEvent, LabelAction.Edited),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessLabelWebhookAsync(WebhookHeaders headers, LabelEvent labelEvent, LabelAction action) =>
        Task.CompletedTask;

    private Task ProcessMarketplacePurchaseWebhookAsync(WebhookHeaders headers, MarketplacePurchaseEvent marketplacePurchaseEvent) =>
        marketplacePurchaseEvent.Action switch
        {
            MarketplacePurchaseActionValue.Cancelled
                => this.ProcessMarketplacePurchaseWebhookAsync(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.Cancelled),
            MarketplacePurchaseActionValue.Changed
                => this.ProcessMarketplacePurchaseWebhookAsync(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.Changed),
            MarketplacePurchaseActionValue.PendingChange
                => this.ProcessMarketplacePurchaseWebhookAsync(
                    headers,
                    marketplacePurchaseEvent,
                    MarketplacePurchaseAction.PendingChange),
            MarketplacePurchaseActionValue.PendingChangeCancelled
                => this.ProcessMarketplacePurchaseWebhookAsync(
                    headers,
                    marketplacePurchaseEvent,
                    MarketplacePurchaseAction.PendingChangeCancelled),
            MarketplacePurchaseActionValue.Purchased
                => this.ProcessMarketplacePurchaseWebhookAsync(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.Purchased),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessMarketplacePurchaseWebhookAsync(
        WebhookHeaders headers,
        MarketplacePurchaseEvent marketplacePurchaseEvent,
        MarketplacePurchaseAction action) => Task.CompletedTask;

    private Task ProcessMemberWebhookAsync(WebhookHeaders headers, MemberEvent memberEvent) =>
        memberEvent.Action switch
        {
            MemberActionValue.Added => this.ProcessMemberWebhookAsync(headers, memberEvent, MemberAction.Added),
            MemberActionValue.Edited => this.ProcessMemberWebhookAsync(headers, memberEvent, MemberAction.Edited),
            MemberActionValue.Removed => this.ProcessMemberWebhookAsync(headers, memberEvent, MemberAction.Removed),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessMemberWebhookAsync(WebhookHeaders headers, MemberEvent memberEvent, MemberAction action) =>
        Task.CompletedTask;

    private Task ProcessMembershipWebhookAsync(WebhookHeaders headers, MembershipEvent membershipEvent) =>
        membershipEvent.Action switch
        {
            MembershipActionValue.Added => this.ProcessMembershipWebhookAsync(headers, membershipEvent, MembershipAction.Added),
            MembershipActionValue.Removed => this.ProcessMembershipWebhookAsync(headers, membershipEvent, MembershipAction.Removed),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessMembershipWebhookAsync(
        WebhookHeaders headers,
        MembershipEvent membershipEvent,
        MembershipAction action) => Task.CompletedTask;

    private Task ProcessMergeGroupWebhookAsync(WebhookHeaders headers, MergeGroupEvent mergeGroupEvent) =>
        mergeGroupEvent.Action switch
        {
            MergeGroupActionValue.ChecksRequested => this.ProcessMergeGroupWebhookAsync(headers, mergeGroupEvent, MergeGroupAction.ChecksRequested),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessMergeGroupWebhookAsync(
        WebhookHeaders headers,
        MergeGroupEvent mergeGroupEvent,
        MergeGroupAction action) => Task.CompletedTask;

    private Task ProcessMetaWebhookAsync(WebhookHeaders headers, MetaEvent metaEvent) =>
        metaEvent.Action switch
        {
            MetaActionValue.Deleted => this.ProcessMetaWebhookAsync(headers, metaEvent, MetaAction.Deleted),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessMetaWebhookAsync(WebhookHeaders headers, MetaEvent metaEvent, MetaAction action) =>
        Task.CompletedTask;

    private Task ProcessMilestoneWebhookAsync(WebhookHeaders headers, MilestoneEvent milestoneEvent) =>
        milestoneEvent.Action switch
        {
            MilestoneActionValue.Closed => this.ProcessMilestoneWebhookAsync(headers, milestoneEvent, MilestoneAction.Closed),
            MilestoneActionValue.Created => this.ProcessMilestoneWebhookAsync(headers, milestoneEvent, MilestoneAction.Created),
            MilestoneActionValue.Deleted => this.ProcessMilestoneWebhookAsync(headers, milestoneEvent, MilestoneAction.Deleted),
            MilestoneActionValue.Edited => this.ProcessMilestoneWebhookAsync(headers, milestoneEvent, MilestoneAction.Edited),
            MilestoneActionValue.Opened => this.ProcessMilestoneWebhookAsync(headers, milestoneEvent, MilestoneAction.Opened),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessMilestoneWebhookAsync(
        WebhookHeaders headers,
        MilestoneEvent milestoneEvent,
        MilestoneAction action) => Task.CompletedTask;

    private Task ProcessOrgBlockWebhookAsync(WebhookHeaders headers, OrgBlockEvent orgBlockEvent) =>
        orgBlockEvent.Action switch
        {
            OrgBlockActionValue.Blocked => this.ProcessOrgBlockWebhookAsync(headers, orgBlockEvent, OrgBlockAction.Blocked),
            OrgBlockActionValue.Unblocked => this.ProcessOrgBlockWebhookAsync(headers, orgBlockEvent, OrgBlockAction.Unblocked),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessOrgBlockWebhookAsync(WebhookHeaders headers, OrgBlockEvent orgBlockEvent, OrgBlockAction action) =>
        Task.CompletedTask;

    private Task ProcessOrganizationWebhookAsync(WebhookHeaders headers, OrganizationEvent organizationEvent) =>
        organizationEvent.Action switch
        {
            OrganizationActionValue.Deleted
                => this.ProcessOrganizationWebhookAsync(headers, organizationEvent, OrganizationAction.Deleted),
            OrganizationActionValue.MemberAdded
                => this.ProcessOrganizationWebhookAsync(headers, organizationEvent, OrganizationAction.MemberAdded),
            OrganizationActionValue.MemberInvited
                => this.ProcessOrganizationWebhookAsync(headers, organizationEvent, OrganizationAction.MemberInvited),
            OrganizationActionValue.MemberRemoved
                => this.ProcessOrganizationWebhookAsync(headers, organizationEvent, OrganizationAction.MemberRemoved),
            OrganizationActionValue.Renamed
                => this.ProcessOrganizationWebhookAsync(headers, organizationEvent, OrganizationAction.Renamed),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessOrganizationWebhookAsync(
        WebhookHeaders headers,
        OrganizationEvent organizationEvent,
        OrganizationAction action) => Task.CompletedTask;

    private Task ProcessPackageWebhookAsync(WebhookHeaders headers, PackageEvent packageEvent) =>
        packageEvent.Action switch
        {
            PackageActionValue.Published => this.ProcessPackageWebhookAsync(headers, packageEvent, PackageAction.Published),
            PackageActionValue.Updated => this.ProcessPackageWebhookAsync(headers, packageEvent, PackageAction.Updated),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessPackageWebhookAsync(WebhookHeaders headers, PackageEvent packageEvent, PackageAction action) =>
        Task.CompletedTask;

    [PublicAPI]
    protected virtual Task ProcessPageBuildWebhookAsync(WebhookHeaders headers, PageBuildEvent pageBuildEvent) => Task.CompletedTask;

    [PublicAPI]
    protected virtual Task ProcessPingWebhookAsync(WebhookHeaders headers, PingEvent pingEvent) => Task.CompletedTask;

    private Task ProcessProjectWebhookAsync(WebhookHeaders headers, ProjectEvent projectEvent) =>
        projectEvent.Action switch
        {
            ProjectActionValue.Closed => this.ProcessProjectWebhookAsync(headers, projectEvent, ProjectAction.Closed),
            ProjectActionValue.Created => this.ProcessProjectWebhookAsync(headers, projectEvent, ProjectAction.Created),
            ProjectActionValue.Deleted => this.ProcessProjectWebhookAsync(headers, projectEvent, ProjectAction.Deleted),
            ProjectActionValue.Edited => this.ProcessProjectWebhookAsync(headers, projectEvent, ProjectAction.Edited),
            ProjectActionValue.Reopened => this.ProcessProjectWebhookAsync(headers, projectEvent, ProjectAction.Reopened),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessProjectWebhookAsync(WebhookHeaders headers, ProjectEvent projectEvent, ProjectAction action) =>
        Task.CompletedTask;

    private Task ProcessProjectCardWebhookAsync(WebhookHeaders headers, ProjectCardEvent projectCardEvent) =>
        projectCardEvent.Action switch
        {
            ProjectCardActionValue.Converted
                => this.ProcessProjectCardWebhookAsync(headers, projectCardEvent, ProjectCardAction.Converted),
            ProjectCardActionValue.Created => this.ProcessProjectCardWebhookAsync(headers, projectCardEvent, ProjectCardAction.Created),
            ProjectCardActionValue.Deleted => this.ProcessProjectCardWebhookAsync(headers, projectCardEvent, ProjectCardAction.Deleted),
            ProjectCardActionValue.Edited => this.ProcessProjectCardWebhookAsync(headers, projectCardEvent, ProjectCardAction.Edited),
            ProjectCardActionValue.Moved => this.ProcessProjectCardWebhookAsync(headers, projectCardEvent, ProjectCardAction.Moved),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessProjectCardWebhookAsync(
        WebhookHeaders headers,
        ProjectCardEvent projectCardEvent,
        ProjectCardAction action) => Task.CompletedTask;

    private Task ProcessProjectColumnWebhookAsync(WebhookHeaders headers, ProjectColumnEvent projectColumnEvent) =>
        projectColumnEvent.Action switch
        {
            ProjectColumnActionValue.Created
                => this.ProcessProjectColumnWebhookAsync(headers, projectColumnEvent, ProjectColumnAction.Created),
            ProjectColumnActionValue.Deleted
                => this.ProcessProjectColumnWebhookAsync(headers, projectColumnEvent, ProjectColumnAction.Deleted),
            ProjectColumnActionValue.Edited
                => this.ProcessProjectColumnWebhookAsync(headers, projectColumnEvent, ProjectColumnAction.Edited),
            ProjectColumnActionValue.Moved
                => this.ProcessProjectColumnWebhookAsync(headers, projectColumnEvent, ProjectColumnAction.Moved),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessProjectColumnWebhookAsync(
        WebhookHeaders headers,
        ProjectColumnEvent projectColumnEvent,
        ProjectColumnAction action) => Task.CompletedTask;

    [PublicAPI]
    protected virtual Task ProcessPublicWebhookAsync(WebhookHeaders headers, PublicEvent publicEvent) => Task.CompletedTask;

    private Task ProcessPullRequestWebhookAsync(WebhookHeaders headers, PullRequestEvent pullRequestEvent) =>
        pullRequestEvent.Action switch
        {
            PullRequestActionValue.Assigned
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Assigned),
            PullRequestActionValue.AutoMergeDisabled
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.AutoMergeDisabled),
            PullRequestActionValue.AutoMergeEnabled
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.AutoMergeEnabled),
            PullRequestActionValue.Closed => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Closed),
            PullRequestActionValue.ConvertedToDraft
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.ConvertedToDraft),
            PullRequestActionValue.Dequeued =>
                this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Dequeued),
            PullRequestActionValue.Demilestoned =>
                this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Demilestoned),
            PullRequestActionValue.Edited => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Edited),
            PullRequestActionValue.Labeled => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Labeled),
            PullRequestActionValue.Locked => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Locked),
            PullRequestActionValue.Milestoned => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Milestoned),
            PullRequestActionValue.Opened => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Opened),
            PullRequestActionValue.Queued
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Queued),
            PullRequestActionValue.ReadyForReview
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.ReadyForReview),
            PullRequestActionValue.Reopened
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Reopened),
            PullRequestActionValue.ReviewRequestRemoved
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.ReviewRequestRemoved),
            PullRequestActionValue.ReviewRequested
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.ReviewRequested),
            PullRequestActionValue.Synchronize
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Synchronize),
            PullRequestActionValue.Unassigned
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Unassigned),
            PullRequestActionValue.Unlabeled
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Unlabeled),
            PullRequestActionValue.Unlocked
                => this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Unlocked),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessPullRequestWebhookAsync(
        WebhookHeaders headers,
        PullRequestEvent pullRequestEvent,
        PullRequestAction action) => Task.CompletedTask;

    private Task ProcessPullRequestReviewWebhookAsync(WebhookHeaders headers, PullRequestReviewEvent pullRequestReviewEvent) =>
        pullRequestReviewEvent.Action switch
        {
            PullRequestReviewActionValue.Dismissed
                => this.ProcessPullRequestReviewWebhookAsync(headers, pullRequestReviewEvent, PullRequestReviewAction.Dismissed),
            PullRequestReviewActionValue.Edited
                => this.ProcessPullRequestReviewWebhookAsync(headers, pullRequestReviewEvent, PullRequestReviewAction.Edited),
            PullRequestReviewActionValue.Submitted
                => this.ProcessPullRequestReviewWebhookAsync(headers, pullRequestReviewEvent, PullRequestReviewAction.Submitted),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessPullRequestReviewWebhookAsync(
        WebhookHeaders headers,
        PullRequestReviewEvent pullRequestReviewEvent,
        PullRequestReviewAction action) => Task.CompletedTask;

    private Task ProcessPullRequestReviewCommentWebhookAsync(
        WebhookHeaders headers,
        PullRequestReviewCommentEvent pullRequestReviewCommentEvent) =>
        pullRequestReviewCommentEvent.Action switch
        {
            PullRequestReviewCommentActionValue.Created
                => this.ProcessPullRequestReviewCommentWebhookAsync(
                    headers,
                    pullRequestReviewCommentEvent,
                    PullRequestReviewCommentAction.Created),
            PullRequestReviewCommentActionValue.Deleted
                => this.ProcessPullRequestReviewCommentWebhookAsync(
                    headers,
                    pullRequestReviewCommentEvent,
                    PullRequestReviewCommentAction.Deleted),
            PullRequestReviewCommentActionValue.Edited
                => this.ProcessPullRequestReviewCommentWebhookAsync(
                    headers,
                    pullRequestReviewCommentEvent,
                    PullRequestReviewCommentAction.Edited),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessPullRequestReviewCommentWebhookAsync(
        WebhookHeaders headers,
        PullRequestReviewCommentEvent pullRequestReviewCommentEvent,
        PullRequestReviewCommentAction action) => Task.CompletedTask;

    private Task ProcessPullRequestReviewThreadWebhookAsync(
        WebhookHeaders headers,
        PullRequestReviewThreadEvent pullRequestReviewThreadEvent) =>
        pullRequestReviewThreadEvent.Action switch
        {
            PullRequestReviewThreadActionValue.Resolved
                => this.ProcessPullRequestReviewThreadWebhookAsync(
                    headers,
                    pullRequestReviewThreadEvent,
                    PullRequestReviewThreadAction.Resolved),
            PullRequestReviewThreadActionValue.Unresolved
                => this.ProcessPullRequestReviewThreadWebhookAsync(
                    headers,
                    pullRequestReviewThreadEvent,
                    PullRequestReviewThreadAction.Unresolved),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessPullRequestReviewThreadWebhookAsync(
        WebhookHeaders headers,
        PullRequestReviewThreadEvent pullRequestReviewThreadEvent,
        PullRequestReviewThreadAction action) => Task.CompletedTask;

    [PublicAPI]
    protected virtual Task ProcessPushWebhookAsync(WebhookHeaders headers, PushEvent pushEvent) => Task.CompletedTask;

    private Task ProcessReleaseWebhookAsync(WebhookHeaders headers, ReleaseEvent releaseEvent) =>
        releaseEvent.Action switch
        {
            ReleaseActionValue.Created => this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Created),
            ReleaseActionValue.Deleted => this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Deleted),
            ReleaseActionValue.Edited => this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Edited),
            ReleaseActionValue.Prereleased => this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Prereleased),
            ReleaseActionValue.Published => this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Published),
            ReleaseActionValue.Released => this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Released),
            ReleaseActionValue.Unpublished => this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Unpublished),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessReleaseWebhookAsync(WebhookHeaders headers, ReleaseEvent releaseEvent, ReleaseAction action) =>
        Task.CompletedTask;

    private Task ProcessRegistryPackageWebhookAsync(WebhookHeaders headers, RegistryPackageEvent registryPackageEvent) =>
        registryPackageEvent.Action switch
        {
            RegistryPackageActionValue.Published => this.ProcessRegistryPackageWebhookAsync(
                headers,
                registryPackageEvent,
                RegistryPackageAction.Published),
            RegistryPackageActionValue.Updated => this.ProcessRegistryPackageWebhookAsync(
                headers,
                registryPackageEvent,
                RegistryPackageAction.Published),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessRegistryPackageWebhookAsync(
        WebhookHeaders headers,
        RegistryPackageEvent registryPackageEvent,
        RegistryPackageAction action) => Task.CompletedTask;

    private Task ProcessRepositoryWebhookAsync(WebhookHeaders headers, RepositoryEvent repositoryEvent) =>
        repositoryEvent.Action switch
        {
            RepositoryActionValue.Archived => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Archived),
            RepositoryActionValue.Created => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Created),
            RepositoryActionValue.Deleted => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Deleted),
            RepositoryActionValue.Edited => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Edited),
            RepositoryActionValue.Privatized
                => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Privatized),
            RepositoryActionValue.Publicized
                => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Publicized),
            RepositoryActionValue.Renamed => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Renamed),
            RepositoryActionValue.Transferred
                => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Transferred),
            RepositoryActionValue.Unarchived
                => this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Unarchived),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessRepositoryWebhookAsync(
        WebhookHeaders headers,
        RepositoryEvent repositoryEvent,
        RepositoryAction action) => Task.CompletedTask;

    private Task ProcessRepositoryDispatchWebhookAsync(WebhookHeaders headers, RepositoryDispatchEvent repositoryDispatchEvent) =>
        repositoryDispatchEvent.Action switch
        {
            RepositoryDispatchActionValue.OnDemandTest
                => this.ProcessRepositoryDispatchWebhookAsync(headers, repositoryDispatchEvent, RepositoryDispatchAction.OnDemandTest),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessRepositoryDispatchWebhookAsync(
        WebhookHeaders headers,
        RepositoryDispatchEvent repositoryDispatchEvent,
        RepositoryDispatchAction action) => Task.CompletedTask;

    [PublicAPI]
    protected virtual Task ProcessRepositoryImportWebhookAsync(WebhookHeaders headers, RepositoryImportEvent repositoryImportEvent) =>
        Task.CompletedTask;

    private Task ProcessRepositoryVulnerabilityAlertWebhookAsync(
        WebhookHeaders headers,
        RepositoryVulnerabilityAlertEvent repositoryVulnerabilityAlertEvent) =>
        repositoryVulnerabilityAlertEvent.Action switch
        {
            RepositoryVulnerabilityAlertActionValue.Create
                => this.ProcessRepositoryVulnerabilityAlertWebhookAsync(
                    headers,
                    repositoryVulnerabilityAlertEvent,
                    RepositoryVulnerabilityAlertAction.Create),
            RepositoryVulnerabilityAlertActionValue.Dismiss
                => this.ProcessRepositoryVulnerabilityAlertWebhookAsync(
                    headers,
                    repositoryVulnerabilityAlertEvent,
                    RepositoryVulnerabilityAlertAction.Dismiss),
            RepositoryVulnerabilityAlertActionValue.Resolve
                => this.ProcessRepositoryVulnerabilityAlertWebhookAsync(
                    headers,
                    repositoryVulnerabilityAlertEvent,
                    RepositoryVulnerabilityAlertAction.Resolve),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessRepositoryVulnerabilityAlertWebhookAsync(
        WebhookHeaders headers,
        RepositoryVulnerabilityAlertEvent repositoryVulnerabilityAlertEvent,
        RepositoryVulnerabilityAlertAction action) => Task.CompletedTask;

    private Task ProcessSecretScanningAlertWebhookAsync(WebhookHeaders headers, SecretScanningAlertEvent secretScanningAlertEvent) =>
        secretScanningAlertEvent.Action switch
        {
            SecretScanningAlertActionValue.Created
                => this.ProcessSecretScanningAlertWebhookAsync(headers, secretScanningAlertEvent, SecretScanningAlertAction.Created),
            SecretScanningAlertActionValue.Reopened
                => this.ProcessSecretScanningAlertWebhookAsync(headers, secretScanningAlertEvent, SecretScanningAlertAction.Reopened),
            SecretScanningAlertActionValue.Resolved
                => this.ProcessSecretScanningAlertWebhookAsync(headers, secretScanningAlertEvent, SecretScanningAlertAction.Resolved),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessSecretScanningAlertWebhookAsync(
        WebhookHeaders headers,
        SecretScanningAlertEvent secretScanningAlertEvent,
        SecretScanningAlertAction action) => Task.CompletedTask;

    private Task ProcessSecurityAdvisoryWebhookAsync(WebhookHeaders headers, SecurityAdvisoryEvent securityAdvisoryEvent) =>
        securityAdvisoryEvent.Action switch
        {
            SecurityAdvisoryActionValue.Performed
                => this.ProcessSecurityAdvisoryWebhookAsync(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Performed),
            SecurityAdvisoryActionValue.Published
                => this.ProcessSecurityAdvisoryWebhookAsync(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Published),
            SecurityAdvisoryActionValue.Updated
                => this.ProcessSecurityAdvisoryWebhookAsync(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Updated),
            SecurityAdvisoryActionValue.Withdrawn
                => this.ProcessSecurityAdvisoryWebhookAsync(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Withdrawn),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessSecurityAdvisoryWebhookAsync(
        WebhookHeaders headers,
        SecurityAdvisoryEvent securityAdvisoryEvent,
        SecurityAdvisoryAction action) => Task.CompletedTask;

    private Task ProcessSponsorshipWebhookAsync(WebhookHeaders headers, SponsorshipEvent sponsorshipEvent) =>
        sponsorshipEvent.Action switch
        {
            SponsorshipActionValue.Cancelled
                => this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.Cancelled),
            SponsorshipActionValue.Created => this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.Created),
            SponsorshipActionValue.Edited => this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.Edited),
            SponsorshipActionValue.PendingCancellation
                => this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.PendingCancellation),
            SponsorshipActionValue.PendingTierChange
                => this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.PendingTierChange),
            SponsorshipActionValue.TierChanged
                => this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.TierChanged),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessSponsorshipWebhookAsync(
        WebhookHeaders headers,
        SponsorshipEvent sponsorshipEvent,
        SponsorshipAction action) => Task.CompletedTask;

    private Task ProcessStarWebhookAsync(WebhookHeaders headers, StarEvent starEvent) =>
        starEvent.Action switch
        {
            StarActionValue.Created => this.ProcessStarWebhookAsync(headers, starEvent, StarAction.Created),
            StarActionValue.Deleted => this.ProcessStarWebhookAsync(headers, starEvent, StarAction.Deleted),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessStarWebhookAsync(WebhookHeaders headers, StarEvent starEvent, StarAction action) =>
        Task.CompletedTask;

    [PublicAPI]
    protected virtual Task ProcessStatusWebhookAsync(WebhookHeaders headers, StatusEvent statusEvent) => Task.CompletedTask;

    private Task ProcessTeamWebhookAsync(WebhookHeaders headers, TeamEvent teamEvent) =>
        teamEvent.Action switch
        {
            TeamActionValue.AddedToRepository => this.ProcessTeamWebhookAsync(headers, teamEvent, TeamAction.AddedToRepository),
            TeamActionValue.Created => this.ProcessTeamWebhookAsync(headers, teamEvent, TeamAction.Created),
            TeamActionValue.Deleted => this.ProcessTeamWebhookAsync(headers, teamEvent, TeamAction.Deleted),
            TeamActionValue.Edited => this.ProcessTeamWebhookAsync(headers, teamEvent, TeamAction.Edited),
            TeamActionValue.RemovedFromRepository => this.ProcessTeamWebhookAsync(headers, teamEvent, TeamAction.RemovedFromRepository),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessTeamWebhookAsync(WebhookHeaders headers, TeamEvent teamEvent, TeamAction action) =>
        Task.CompletedTask;

    [PublicAPI]
    protected virtual Task ProcessTeamAddWebhookAsync(WebhookHeaders headers, TeamAddEvent teamAddEvent) => Task.CompletedTask;

    private Task ProcessWatchWebhookAsync(WebhookHeaders headers, WatchEvent watchEvent) =>
        watchEvent.Action switch
        {
            WatchActionValue.Started => this.ProcessWatchWebhookAsync(headers, watchEvent, WatchAction.Started),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessWatchWebhookAsync(WebhookHeaders headers, WatchEvent watchEvent, WatchAction action) =>
        Task.CompletedTask;

    [PublicAPI]
    protected virtual Task ProcessWorkflowDispatchWebhookAsync(WebhookHeaders headers, WorkflowDispatchEvent workflowDispatchEvent) =>
        Task.CompletedTask;

    private Task ProcessWorkflowJobWebhookAsync(WebhookHeaders headers, WorkflowJobEvent workflowJobEvent) =>
        workflowJobEvent.Action switch
        {
            WorkflowJobActionValue.Queued
                => this.ProcessWorkflowJobWebhookAsync(headers, workflowJobEvent, WorkflowJobAction.Queued),
            WorkflowJobActionValue.InProgress
                => this.ProcessWorkflowJobWebhookAsync(headers, workflowJobEvent, WorkflowJobAction.InProgress),
            WorkflowJobActionValue.Completed
                => this.ProcessWorkflowJobWebhookAsync(headers, workflowJobEvent, WorkflowJobAction.Completed),
            WorkflowJobActionValue.Waiting
                => this.ProcessWorkflowJobWebhookAsync(headers, workflowJobEvent, WorkflowJobAction.Waiting),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessWorkflowJobWebhookAsync(
        WebhookHeaders headers,
        WorkflowJobEvent workflowJobEvent,
        WorkflowJobAction action) => Task.CompletedTask;

    private Task ProcessWorkflowRunWebhookAsync(WebhookHeaders headers, WorkflowRunEvent workflowRunEvent) =>
        workflowRunEvent.Action switch
        {
            WorkflowRunActionValue.Completed
                => this.ProcessWorkflowRunWebhookAsync(headers, workflowRunEvent, WorkflowRunAction.Completed),
            WorkflowRunActionValue.Requested
                => this.ProcessWorkflowRunWebhookAsync(headers, workflowRunEvent, WorkflowRunAction.Requested),
            _ => Task.CompletedTask,
        };

    [PublicAPI]
    protected virtual Task ProcessWorkflowRunWebhookAsync(
        WebhookHeaders headers,
        WorkflowRunEvent workflowRunEvent,
        WorkflowRunAction action) => Task.CompletedTask;
}
