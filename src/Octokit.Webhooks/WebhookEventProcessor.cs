namespace Octokit.Webhooks
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Microsoft.Extensions.Primitives;
    using Octokit.Webhooks.Events;
    using Octokit.Webhooks.Events.BranchProtectionRule;
    using Octokit.Webhooks.Events.CheckRun;
    using Octokit.Webhooks.Events.CheckSuite;
    using Octokit.Webhooks.Events.CodeScanningAlert;
    using Octokit.Webhooks.Events.CommitComment;
    using Octokit.Webhooks.Events.ContentReference;
    using Octokit.Webhooks.Events.DeployKey;
    using Octokit.Webhooks.Events.Deployment;
    using Octokit.Webhooks.Events.DeploymentStatus;
    using Octokit.Webhooks.Events.Discussion;
    using Octokit.Webhooks.Events.DiscussionComment;
    using Octokit.Webhooks.Events.GithubAppAuthorization;
    using Octokit.Webhooks.Events.Installation;
    using Octokit.Webhooks.Events.InstallationRepositories;
    using Octokit.Webhooks.Events.IssueComment;
    using Octokit.Webhooks.Events.Issues;
    using Octokit.Webhooks.Events.Label;
    using Octokit.Webhooks.Events.MarketplacePurchase;
    using Octokit.Webhooks.Events.Member;
    using Octokit.Webhooks.Events.Membership;
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
            if (headers is null)
            {
                throw new ArgumentNullException(nameof(headers));
            }

            if (body is null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            return this.ProcessWebhookAsync(WebhookHeaders.Parse(headers), body);
        }

        [PublicAPI]
        public virtual Task ProcessWebhookAsync(WebhookHeaders headers, string body)
        {
            switch (headers.Event)
            {
                case WebhookEventType.BranchProtectionRule:
                    return this.ProcessBranchProtectionRuleWebhook(headers, body);
                case WebhookEventType.CheckRun:
                    return this.ProcessCheckRunWebhook(headers, body);
                case WebhookEventType.CheckSuite:
                    return this.ProcessCheckSuiteWebhook(headers, body);
                case WebhookEventType.CodeScanningAlert:
                    return this.ProcessCodeScanningAlertWebhook(headers, body);
                case WebhookEventType.CommitComment:
                    return this.ProcessCommitCommentWebhook(headers, body);
                case WebhookEventType.ContentReference:
                    return this.ProcessContentReferenceWebhook(headers, body);
                case WebhookEventType.Create:
                    return this.ProcessCreateWebhook(headers, JsonSerializer.Deserialize<CreateEvent>(body)!);
                case WebhookEventType.Delete:
                    return this.ProcessDeleteWebhook(headers, JsonSerializer.Deserialize<DeleteEvent>(body)!);
                case WebhookEventType.DeployKey:
                    return this.ProcessDeployKeyWebhook(headers, body);
                case WebhookEventType.Deployment:
                    return this.ProcessDeploymentWebhook(headers, body);
                case WebhookEventType.DeploymentStatus:
                    return this.ProcessDeploymentStatusWebhook(headers, body);
                case WebhookEventType.Discussion:
                    return this.ProcessDiscussionWebhook(headers, body);
                case WebhookEventType.DiscussionComment:
                    return this.ProcessDiscussionCommentWebhook(headers, body);
                case WebhookEventType.Fork:
                    return this.ProcessForkWebhook(headers, JsonSerializer.Deserialize<ForkEvent>(body)!);
                case WebhookEventType.GithubAppAuthorization:
                    return this.ProcessGithubAppAuthorizationWebhook(headers, body);
                case WebhookEventType.Gollum:
                    return this.ProcessGollumWebhook(headers, JsonSerializer.Deserialize<GollumEvent>(body)!);
                case WebhookEventType.Installation:
                    return this.ProcessInstallationWebhook(headers, body);
                case WebhookEventType.InstallationRepositories:
                    return this.ProcessInstallationRepositoriesWebhook(headers, body);
                case WebhookEventType.IssueComment:
                    return this.ProcessIssueCommentWebhook(headers, body);
                case WebhookEventType.Issues:
                    return this.ProcessIssuesWebhook(headers, body);
                case WebhookEventType.Label:
                    return this.ProcessLabelWebhook(headers, body);
                case WebhookEventType.MarketplacePurchase:
                    return this.ProcessMarketplacePurchaseWebhook(headers, body);
                case WebhookEventType.Member:
                    return this.ProcessMemberWebhook(headers, body);
                case WebhookEventType.Membership:
                    return this.ProcessMembershipWebhook(headers, body);
                case WebhookEventType.Meta:
                    return this.ProcessMetaWebhook(headers, body);
                case WebhookEventType.Milestone:
                    return this.ProcessMilestoneWebhook(headers, body);
                case WebhookEventType.OrgBlock:
                    return this.ProcessOrgBlockWebhook(headers, body);
                case WebhookEventType.Organization:
                    return this.ProcessOrganizationWebhook(headers, body);
                case WebhookEventType.Package:
                    return this.ProcessPackageWebhook(headers, body);
                case WebhookEventType.PageBuild:
                    return this.ProcessPageBuildWebhook(headers, JsonSerializer.Deserialize<PageBuildEvent>(body)!);
                case WebhookEventType.Ping:
                    return this.ProcessPingWebhook(headers, JsonSerializer.Deserialize<PingEvent>(body)!);
                case WebhookEventType.Project:
                    return this.ProcessProjectWebhook(headers, body);
                case WebhookEventType.ProjectCard:
                    return this.ProcessProjectCardWebhook(headers, body);
                case WebhookEventType.ProjectColumn:
                    return this.ProcessProjectColumnWebhook(headers, body);
                case WebhookEventType.Public:
                    return this.ProcessPublicWebhook(headers, JsonSerializer.Deserialize<PublicEvent>(body)!);
                case WebhookEventType.PullRequest:
                    return this.ProcessPullRequestWebhook(headers, body);
                case WebhookEventType.PullRequestReview:
                    return this.ProcessPullRequestReviewWebhook(headers, body);
                case WebhookEventType.PullRequestReviewComment:
                    return this.ProcessPullRequestReviewCommentWebhook(headers, body);
                case WebhookEventType.Push:
                    return this.ProcessPushWebhook(headers, JsonSerializer.Deserialize<PushEvent>(body)!);
                case WebhookEventType.Release:
                    return this.ProcessReleaseWebhook(headers, body);
                case WebhookEventType.Repository:
                    return this.ProcessRepositoryWebhook(headers, body);
                case WebhookEventType.RepositoryDispatch:
                    return this.ProcessRepositoryDispatchWebhook(headers, body);
                case WebhookEventType.RepositoryImport:
                    return this.ProcessRepositoryImportWebhook(headers, JsonSerializer.Deserialize<RepositoryImportEvent>(body)!);
                case WebhookEventType.RepositoryVulnerabilityAlert:
                    return this.ProcessRepositoryVulnerabilityAlertWebhook(headers, body);
                case WebhookEventType.SecretScanningAlert:
                    return this.ProcessSecretScanningAlertWebhook(headers, body);
                case WebhookEventType.SecurityAdvisory:
                    return this.ProcessSecurityAdvisoryWebhook(headers, body);
                case WebhookEventType.Sponsorship:
                    return this.ProcessSponsorshipWebhook(headers, body);
                case WebhookEventType.Star:
                    return this.ProcessStarWebhook(headers, body);
                case WebhookEventType.Status:
                    return this.ProcessStatusWebhook(headers, JsonSerializer.Deserialize<StatusEvent>(body)!);
                case WebhookEventType.Team:
                    return this.ProcessTeamWebhook(headers, body);
                case WebhookEventType.TeamAdd:
                    return this.ProcessTeamAddWebhook(headers, JsonSerializer.Deserialize<TeamAddEvent>(body)!);
                case WebhookEventType.Watch:
                    return this.ProcessWatchWebhook(headers, body);
                case WebhookEventType.WorkflowDispatch:
                    return this.ProcessWorkflowDispatchWebhook(headers, JsonSerializer.Deserialize<WorkflowDispatchEvent>(body)!);
                case WebhookEventType.WorkflowJob:
                    return this.ProcessWorkflowJobWebhook(headers, body);
                case WebhookEventType.WorkflowRun:
                    return this.ProcessWorkflowRunWebhook(headers, body);
            }

            return Task.CompletedTask;
        }

        private Task ProcessBranchProtectionRuleWebhook(WebhookHeaders headers, string body)
        {
            var branchProtectionRuleEvent = JsonSerializer.Deserialize<BranchProtectionRuleEvent>(body)!;
            switch (branchProtectionRuleEvent.Action)
            {
                case BranchProtectionRuleActionValue.Created:
                    return this.ProcessBranchProtectionRuleWebhook(headers, branchProtectionRuleEvent, BranchProtectionRuleAction.Created);
                case BranchProtectionRuleActionValue.Deleted:
                    return this.ProcessBranchProtectionRuleWebhook(headers, branchProtectionRuleEvent, BranchProtectionRuleAction.Deleted);
                case BranchProtectionRuleActionValue.Edited:
                    return this.ProcessBranchProtectionRuleWebhook(headers, branchProtectionRuleEvent, BranchProtectionRuleAction.Edited);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessBranchProtectionRuleWebhook(WebhookHeaders headers, BranchProtectionRuleEvent branchProtectionRuleEvent, BranchProtectionRuleAction action) => Task.CompletedTask;

        private Task ProcessCheckRunWebhook(WebhookHeaders headers, string body)
        {
            var checkRunEvent = JsonSerializer.Deserialize<CheckRunEvent>(body)!;
            switch (checkRunEvent.Action)
            {
                case CheckRunActionValue.Completed:
                    return this.ProcessCheckRunWebhook(headers, checkRunEvent, CheckRunAction.Completed);
                case CheckRunActionValue.Created:
                    return this.ProcessCheckRunWebhook(headers, checkRunEvent, CheckRunAction.Created);
                case CheckRunActionValue.RequestedAction:
                    return this.ProcessCheckRunWebhook(headers, checkRunEvent, CheckRunAction.RequestedAction);
                case CheckRunActionValue.Rerequested:
                    return this.ProcessCheckRunWebhook(headers, checkRunEvent, CheckRunAction.Rerequested);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessCheckRunWebhook(WebhookHeaders headers, CheckRunEvent checkRunEvent, CheckRunAction action) => Task.CompletedTask;

        private Task ProcessCheckSuiteWebhook(WebhookHeaders headers, string body)
        {
            var checkSuiteEvent = JsonSerializer.Deserialize<CheckSuiteEvent>(body)!;
            switch (checkSuiteEvent.Action)
            {
                case CheckSuiteActionValue.Completed:
                    return this.ProcessCheckSuiteWebhook(headers, checkSuiteEvent, CheckSuiteAction.Completed);
                case CheckSuiteActionValue.Requested:
                    return this.ProcessCheckSuiteWebhook(headers, checkSuiteEvent, CheckSuiteAction.Requested);
                case CheckSuiteActionValue.Rerequested:
                    return this.ProcessCheckSuiteWebhook(headers, checkSuiteEvent, CheckSuiteAction.Rerequested);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessCheckSuiteWebhook(WebhookHeaders headers, CheckSuiteEvent checkSuiteEvent, CheckSuiteAction action) => Task.CompletedTask;

        private Task ProcessCodeScanningAlertWebhook(WebhookHeaders headers, string body)
        {
            var codeScanningAlertEvent = JsonSerializer.Deserialize<CodeScanningAlertEvent>(body)!;
            switch (codeScanningAlertEvent.Action)
            {
                case CodeScanningAlertActionValue.AppearedInBranch:
                    return this.ProcessCodeScanningAlertWebhook(headers, codeScanningAlertEvent, CodeScanningAlertAction.AppearedInBranch);
                case CodeScanningAlertActionValue.ClosedByUser:
                    return this.ProcessCodeScanningAlertWebhook(headers, codeScanningAlertEvent, CodeScanningAlertAction.ClosedByUser);
                case CodeScanningAlertActionValue.Created:
                    return this.ProcessCodeScanningAlertWebhook(headers, codeScanningAlertEvent, CodeScanningAlertAction.Created);
                case CodeScanningAlertActionValue.Fixed:
                    return this.ProcessCodeScanningAlertWebhook(headers, codeScanningAlertEvent, CodeScanningAlertAction.Fixed);
                case CodeScanningAlertActionValue.Reopened:
                    return this.ProcessCodeScanningAlertWebhook(headers, codeScanningAlertEvent, CodeScanningAlertAction.Reopened);
                case CodeScanningAlertActionValue.ReopenedByUser:
                    return this.ProcessCodeScanningAlertWebhook(headers, codeScanningAlertEvent, CodeScanningAlertAction.ReopenedByUser);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessCodeScanningAlertWebhook(WebhookHeaders headers, CodeScanningAlertEvent codeScanningAlertEvent, CodeScanningAlertAction action) => Task.CompletedTask;

        private Task ProcessCommitCommentWebhook(WebhookHeaders headers, string body)
        {
            var commitCommentEvent = JsonSerializer.Deserialize<CommitCommentEvent>(body)!;
            switch (commitCommentEvent.Action)
            {
                case CommitCommentActionValue.Created:
                    return this.ProcessCommitCommentWebhook(headers, commitCommentEvent, CommitCommentAction.Created);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessCommitCommentWebhook(WebhookHeaders headers, CommitCommentEvent commitCommentEvent, CommitCommentAction action) => Task.CompletedTask;

        private Task ProcessContentReferenceWebhook(WebhookHeaders headers, string body)
        {
            var contentReferenceEvent = JsonSerializer.Deserialize<ContentReferenceEvent>(body)!;
            switch (contentReferenceEvent.Action)
            {
                case ContentReferenceActionValue.Created:
                    return this.ProcessContentReferenceWebhook(headers, contentReferenceEvent, ContentReferenceAction.Created);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessContentReferenceWebhook(WebhookHeaders headers, ContentReferenceEvent contentReferenceEvent, ContentReferenceAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessCreateWebhook(WebhookHeaders headers, CreateEvent createEvent) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessDeleteWebhook(WebhookHeaders headers, DeleteEvent deleteEvent) => Task.CompletedTask;

        private Task ProcessDeployKeyWebhook(WebhookHeaders headers, string body)
        {
            var deployKeyEvent = JsonSerializer.Deserialize<DeployKeyEvent>(body)!;
            switch (deployKeyEvent.Action)
            {
                case DeployKeyActionValue.Created:
                    return this.ProcessDeployKeyWebhook(headers, deployKeyEvent, DeployKeyAction.Created);
                case DeployKeyActionValue.Deleted:
                    return this.ProcessDeployKeyWebhook(headers, deployKeyEvent, DeployKeyAction.Deleted);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessDeployKeyWebhook(WebhookHeaders headers, DeployKeyEvent deployKeyEvent, DeployKeyAction action) => Task.CompletedTask;

        private Task ProcessDeploymentWebhook(WebhookHeaders headers, string body)
        {
            var deploymentEvent = JsonSerializer.Deserialize<DeploymentEvent>(body)!;
            switch (deploymentEvent.Action)
            {
                case DeploymentActionValue.Created:
                    return this.ProcessDeploymentWebhook(headers, deploymentEvent, DeploymentAction.Created);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessDeploymentWebhook(WebhookHeaders headers, DeploymentEvent deploymentEvent, DeploymentAction action) => Task.CompletedTask;

        private Task ProcessDeploymentStatusWebhook(WebhookHeaders headers, string body)
        {
            var deploymentStatusEvent = JsonSerializer.Deserialize<DeploymentStatusEvent>(body)!;
            switch (deploymentStatusEvent.Action)
            {
                case DeploymentStatusActionValue.Created:
                    return this.ProcessDeploymentStatusWebhook(headers, deploymentStatusEvent, DeploymentStatusAction.Created);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessDeploymentStatusWebhook(WebhookHeaders headers, DeploymentStatusEvent deploymentStatusEvent, DeploymentStatusAction action) => Task.CompletedTask;

        private Task ProcessDiscussionWebhook(WebhookHeaders headers, string body)
        {
            var discussionEvent = JsonSerializer.Deserialize<DiscussionEvent>(body)!;
            switch (discussionEvent.Action)
            {
                case DiscussionActionValue.Answered:
                    return this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Answered);
                case DiscussionActionValue.CategoryChanged:
                    return this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.CategoryChanged);
                case DiscussionActionValue.Created:
                    return this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Created);
                case DiscussionActionValue.Deleted:
                    return this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Deleted);
                case DiscussionActionValue.Edited:
                    return this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Edited);
                case DiscussionActionValue.Labeled:
                    return this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Labeled);
                case DiscussionActionValue.Locked:
                    return this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Locked);
                case DiscussionActionValue.Pinned:
                    return this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Pinned);
                case DiscussionActionValue.Transferred:
                    return this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Transferred);
                case DiscussionActionValue.Unanswered:
                    return this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Unanswered);
                case DiscussionActionValue.Unlabeled:
                    return this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Unlabeled);
                case DiscussionActionValue.Unlocked:
                    return this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Unlocked);
                case DiscussionActionValue.Unpinned:
                    return this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Unpinned);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessDiscussionWebhook(WebhookHeaders headers, DiscussionEvent discussionEvent, DiscussionAction action) => Task.CompletedTask;

        private Task ProcessDiscussionCommentWebhook(WebhookHeaders headers, string body)
        {
            var discussionCommentEvent = JsonSerializer.Deserialize<DiscussionCommentEvent>(body)!;
            switch (discussionCommentEvent.Action)
            {
                case DiscussionCommentActionValue.Created:
                    return this.ProcessDiscussionCommentWebhook(headers, discussionCommentEvent, DiscussionCommentAction.Created);
                case DiscussionCommentActionValue.Deleted:
                    return this.ProcessDiscussionCommentWebhook(headers, discussionCommentEvent, DiscussionCommentAction.Deleted);
                case DiscussionCommentActionValue.Edited:
                    return this.ProcessDiscussionCommentWebhook(headers, discussionCommentEvent, DiscussionCommentAction.Edited);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessDiscussionCommentWebhook(WebhookHeaders headers, DiscussionCommentEvent discussionCommentEvent, DiscussionCommentAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessForkWebhook(WebhookHeaders headers, ForkEvent forkEvent) => Task.CompletedTask;

        private Task ProcessGithubAppAuthorizationWebhook(WebhookHeaders headers, string body)
        {
            var githubAppAuthorizationEvent = JsonSerializer.Deserialize<GithubAppAuthorizationEvent>(body)!;
            switch (githubAppAuthorizationEvent.Action)
            {
                case GithubAppAuthorizationActionValue.Revoked:
                    return this.ProcessGithubAppAuthorizationWebhook(headers, githubAppAuthorizationEvent, GithubAppAuthorizationAction.Revoked);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessGithubAppAuthorizationWebhook(WebhookHeaders headers, GithubAppAuthorizationEvent githubAppAuthorizationEvent, GithubAppAuthorizationAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessGollumWebhook(WebhookHeaders headers, GollumEvent gollumEvent) => Task.CompletedTask;

        private Task ProcessInstallationWebhook(WebhookHeaders headers, string body)
        {
            var installationEvent = JsonSerializer.Deserialize<InstallationEvent>(body)!;
            switch (installationEvent.Action)
            {
                case InstallationActionValue.Created:
                    return this.ProcessInstallationWebhook(headers, installationEvent, InstallationAction.Created);
                case InstallationActionValue.Deleted:
                    return this.ProcessInstallationWebhook(headers, installationEvent, InstallationAction.Deleted);
                case InstallationActionValue.NewPermissionsAccepted:
                    return this.ProcessInstallationWebhook(headers, installationEvent, InstallationAction.NewPermissionsAccepted);
                case InstallationActionValue.Suspend:
                    return this.ProcessInstallationWebhook(headers, installationEvent, InstallationAction.Suspend);
                case InstallationActionValue.Unsuspend:
                    return this.ProcessInstallationWebhook(headers, installationEvent, InstallationAction.Unsuspend);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessInstallationWebhook(WebhookHeaders headers, InstallationEvent installationEvent, InstallationAction action) => Task.CompletedTask;

        private Task ProcessInstallationRepositoriesWebhook(WebhookHeaders headers, string body)
        {
            var installationRepositoriesEvent = JsonSerializer.Deserialize<InstallationRepositoriesEvent>(body)!;
            switch (installationRepositoriesEvent.Action)
            {
                case InstallationRepositoriesActionValue.Added:
                    return this.ProcessInstallationRepositoriesWebhook(headers, installationRepositoriesEvent, InstallationRepositoriesAction.Added);
                case InstallationRepositoriesActionValue.Removed:
                    return this.ProcessInstallationRepositoriesWebhook(headers, installationRepositoriesEvent, InstallationRepositoriesAction.Removed);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessInstallationRepositoriesWebhook(WebhookHeaders headers, InstallationRepositoriesEvent installationRepositoriesEvent, InstallationRepositoriesAction action) => Task.CompletedTask;

        private Task ProcessIssueCommentWebhook(WebhookHeaders headers, string body)
        {
            var issueCommentEvent = JsonSerializer.Deserialize<IssueCommentEvent>(body)!;
            switch (issueCommentEvent.Action)
            {
                case IssueCommentActionValue.Created:
                    return this.ProcessIssueCommentWebhook(headers, issueCommentEvent, IssueCommentAction.Created);
                case IssueCommentActionValue.Deleted:
                    return this.ProcessIssueCommentWebhook(headers, issueCommentEvent, IssueCommentAction.Deleted);
                case IssueCommentActionValue.Edited:
                    return this.ProcessIssueCommentWebhook(headers, issueCommentEvent, IssueCommentAction.Edited);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessIssueCommentWebhook(WebhookHeaders headers, IssueCommentEvent issueCommentEvent, IssueCommentAction action) => Task.CompletedTask;

        private Task ProcessIssuesWebhook(WebhookHeaders headers, string body)
        {
            var issuesEvent = JsonSerializer.Deserialize<IssuesEvent>(body)!;
            switch (issuesEvent.Action)
            {
                case IssuesActionValue.Assigned:
                    return this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Assigned);
                case IssuesActionValue.Closed:
                    return this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Closed);
                case IssuesActionValue.Deleted:
                    return this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Deleted);
                case IssuesActionValue.Demilestoned:
                    return this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Demilestoned);
                case IssuesActionValue.Edited:
                    return this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Edited);
                case IssuesActionValue.Labeled:
                    return this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Labeled);
                case IssuesActionValue.Locked:
                    return this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Locked);
                case IssuesActionValue.Milestoned:
                    return this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Milestoned);
                case IssuesActionValue.Opened:
                    return this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Opened);
                case IssuesActionValue.Pinned:
                    return this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Pinned);
                case IssuesActionValue.Reopened:
                    return this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Reopened);
                case IssuesActionValue.Transferred:
                    return this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Transferred);
                case IssuesActionValue.Unassigned:
                    return this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Unassigned);
                case IssuesActionValue.Unlabeled:
                    return this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Unlabeled);
                case IssuesActionValue.Unlocked:
                    return this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Unlocked);
                case IssuesActionValue.Unpinned:
                    return this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Unpinned);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessIssuesWebhook(WebhookHeaders headers, IssuesEvent issuesEvent, IssuesAction action) => Task.CompletedTask;

        private Task ProcessLabelWebhook(WebhookHeaders headers, string body)
        {
            var labelEvent = JsonSerializer.Deserialize<LabelEvent>(body)!;
            switch (labelEvent.Action)
            {
                case LabelActionValue.Created:
                    return this.ProcessLabelWebhook(headers, labelEvent, LabelAction.Created);
                case LabelActionValue.Deleted:
                    return this.ProcessLabelWebhook(headers, labelEvent, LabelAction.Deleted);
                case LabelActionValue.Edited:
                    return this.ProcessLabelWebhook(headers, labelEvent, LabelAction.Edited);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessLabelWebhook(WebhookHeaders headers, LabelEvent labelEvent, LabelAction action) => Task.CompletedTask;

        private Task ProcessMarketplacePurchaseWebhook(WebhookHeaders headers, string body)
        {
            var marketplacePurchaseEvent = JsonSerializer.Deserialize<MarketplacePurchaseEvent>(body)!;
            switch (marketplacePurchaseEvent.Action)
            {
                case MarketplacePurchaseActionValue.Cancelled:
                    return this.ProcessMarketplacePurchaseWebhook(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.Cancelled);
                case MarketplacePurchaseActionValue.Changed:
                    return this.ProcessMarketplacePurchaseWebhook(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.Changed);
                case MarketplacePurchaseActionValue.PendingChange:
                    return this.ProcessMarketplacePurchaseWebhook(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.PendingChange);
                case MarketplacePurchaseActionValue.PendingChangeCancelled:
                    return this.ProcessMarketplacePurchaseWebhook(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.PendingChangeCancelled);
                case MarketplacePurchaseActionValue.Purchased:
                    return this.ProcessMarketplacePurchaseWebhook(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.Purchased);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessMarketplacePurchaseWebhook(WebhookHeaders headers, MarketplacePurchaseEvent marketplacePurchaseEvent, MarketplacePurchaseAction action) => Task.CompletedTask;

        private Task ProcessMemberWebhook(WebhookHeaders headers, string body)
        {
            var memberEvent = JsonSerializer.Deserialize<MemberEvent>(body)!;
            switch (memberEvent.Action)
            {
                case MemberActionValue.Added:
                    return this.ProcessMemberWebhook(headers, memberEvent, MemberAction.Added);
                case MemberActionValue.Edited:
                    return this.ProcessMemberWebhook(headers, memberEvent, MemberAction.Edited);
                case MemberActionValue.Removed:
                    return this.ProcessMemberWebhook(headers, memberEvent, MemberAction.Removed);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessMemberWebhook(WebhookHeaders headers, MemberEvent memberEvent, MemberAction action) => Task.CompletedTask;

        private Task ProcessMembershipWebhook(WebhookHeaders headers, string body)
        {
            var membershipEvent = JsonSerializer.Deserialize<MembershipEvent>(body)!;
            switch (membershipEvent.Action)
            {
                case MembershipActionValue.Added:
                    return this.ProcessMembershipWebhook(headers, membershipEvent, MembershipAction.Added);
                case MembershipActionValue.Removed:
                    return this.ProcessMembershipWebhook(headers, membershipEvent, MembershipAction.Removed);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessMembershipWebhook(WebhookHeaders headers, MembershipEvent membershipEvent, MembershipAction action) => Task.CompletedTask;

        private Task ProcessMetaWebhook(WebhookHeaders headers, string body)
        {
            var metaEvent = JsonSerializer.Deserialize<MetaEvent>(body)!;
            switch (metaEvent.Action)
            {
                case MetaActionValue.Deleted:
                    return this.ProcessMetaWebhook(headers, metaEvent, MetaAction.Deleted);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessMetaWebhook(WebhookHeaders headers, MetaEvent metaEvent, MetaAction action) => Task.CompletedTask;

        private Task ProcessMilestoneWebhook(WebhookHeaders headers, string body)
        {
            var milestoneEvent = JsonSerializer.Deserialize<MilestoneEvent>(body)!;
            switch (milestoneEvent.Action)
            {
                case MilestoneActionValue.Closed:
                    return this.ProcessMilestoneWebhook(headers, milestoneEvent, MilestoneAction.Closed);
                case MilestoneActionValue.Created:
                    return this.ProcessMilestoneWebhook(headers, milestoneEvent, MilestoneAction.Created);
                case MilestoneActionValue.Deleted:
                    return this.ProcessMilestoneWebhook(headers, milestoneEvent, MilestoneAction.Deleted);
                case MilestoneActionValue.Edited:
                    return this.ProcessMilestoneWebhook(headers, milestoneEvent, MilestoneAction.Edited);
                case MilestoneActionValue.Opened:
                    return this.ProcessMilestoneWebhook(headers, milestoneEvent, MilestoneAction.Opened);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessMilestoneWebhook(WebhookHeaders headers, MilestoneEvent milestoneEvent, MilestoneAction action) => Task.CompletedTask;

        private Task ProcessOrgBlockWebhook(WebhookHeaders headers, string body)
        {
            var orgBlockEvent = JsonSerializer.Deserialize<OrgBlockEvent>(body)!;
            switch (orgBlockEvent.Action)
            {
                case OrgBlockActionValue.Blocked:
                    return this.ProcessOrgBlockWebhook(headers, orgBlockEvent, OrgBlockAction.Blocked);
                case OrgBlockActionValue.Unblocked:
                    return this.ProcessOrgBlockWebhook(headers, orgBlockEvent, OrgBlockAction.Unblocked);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessOrgBlockWebhook(WebhookHeaders headers, OrgBlockEvent orgBlockEvent, OrgBlockAction action) => Task.CompletedTask;

        private Task ProcessOrganizationWebhook(WebhookHeaders headers, string body)
        {
            var organizationEvent = JsonSerializer.Deserialize<OrganizationEvent>(body)!;
            switch (organizationEvent.Action)
            {
                case OrganizationActionValue.Deleted:
                    return this.ProcessOrganizationWebhook(headers, organizationEvent, OrganizationAction.Deleted);
                case OrganizationActionValue.MemberAdded:
                    return this.ProcessOrganizationWebhook(headers, organizationEvent, OrganizationAction.MemberAdded);
                case OrganizationActionValue.MemberInvited:
                    return this.ProcessOrganizationWebhook(headers, organizationEvent, OrganizationAction.MemberInvited);
                case OrganizationActionValue.MemberRemoved:
                    return this.ProcessOrganizationWebhook(headers, organizationEvent, OrganizationAction.MemberRemoved);
                case OrganizationActionValue.Renamed:
                    return this.ProcessOrganizationWebhook(headers, organizationEvent, OrganizationAction.Renamed);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessOrganizationWebhook(WebhookHeaders headers, OrganizationEvent organizationEvent, OrganizationAction action) => Task.CompletedTask;

        private Task ProcessPackageWebhook(WebhookHeaders headers, string body)
        {
            var packageEvent = JsonSerializer.Deserialize<PackageEvent>(body)!;
            switch (packageEvent.Action)
            {
                case PackageActionValue.Published:
                    return this.ProcessPackageWebhook(headers, packageEvent, PackageAction.Published);
                case PackageActionValue.Updated:
                    return this.ProcessPackageWebhook(headers, packageEvent, PackageAction.Updated);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessPackageWebhook(WebhookHeaders headers, PackageEvent packageEvent, PackageAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessPageBuildWebhook(WebhookHeaders headers, PageBuildEvent pageBuildEvent) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessPingWebhook(WebhookHeaders headers, PingEvent pingEvent) => Task.CompletedTask;

        private Task ProcessProjectWebhook(WebhookHeaders headers, string body)
        {
            var projectEvent = JsonSerializer.Deserialize<ProjectEvent>(body)!;
            switch (projectEvent.Action)
            {
                case ProjectActionValue.Closed:
                    return this.ProcessProjectWebhook(headers, projectEvent, ProjectAction.Closed);
                case ProjectActionValue.Created:
                    return this.ProcessProjectWebhook(headers, projectEvent, ProjectAction.Created);
                case ProjectActionValue.Deleted:
                    return this.ProcessProjectWebhook(headers, projectEvent, ProjectAction.Deleted);
                case ProjectActionValue.Edited:
                    return this.ProcessProjectWebhook(headers, projectEvent, ProjectAction.Edited);
                case ProjectActionValue.Reopened:
                    return this.ProcessProjectWebhook(headers, projectEvent, ProjectAction.Reopened);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessProjectWebhook(WebhookHeaders headers, ProjectEvent projectEvent, ProjectAction action) => Task.CompletedTask;

        private Task ProcessProjectCardWebhook(WebhookHeaders headers, string body)
        {
            var projectCardEvent = JsonSerializer.Deserialize<ProjectCardEvent>(body)!;
            switch (projectCardEvent.Action)
            {
                case ProjectCardActionValue.Converted:
                    return this.ProcessProjectCardWebhook(headers, projectCardEvent, ProjectCardAction.Converted);
                case ProjectCardActionValue.Created:
                    return this.ProcessProjectCardWebhook(headers, projectCardEvent, ProjectCardAction.Created);
                case ProjectCardActionValue.Deleted:
                    return this.ProcessProjectCardWebhook(headers, projectCardEvent, ProjectCardAction.Deleted);
                case ProjectCardActionValue.Edited:
                    return this.ProcessProjectCardWebhook(headers, projectCardEvent, ProjectCardAction.Edited);
                case ProjectCardActionValue.Moved:
                    return this.ProcessProjectCardWebhook(headers, projectCardEvent, ProjectCardAction.Moved);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessProjectCardWebhook(WebhookHeaders headers, ProjectCardEvent projectCardEvent, ProjectCardAction action) => Task.CompletedTask;

        private Task ProcessProjectColumnWebhook(WebhookHeaders headers, string body)
        {
            var projectColumnEvent = JsonSerializer.Deserialize<ProjectColumnEvent>(body)!;
            switch (projectColumnEvent.Action)
            {
                case ProjectColumnActionValue.Created:
                    return this.ProcessProjectColumnWebhook(headers, projectColumnEvent, ProjectColumnAction.Created);
                case ProjectColumnActionValue.Deleted:
                    return this.ProcessProjectColumnWebhook(headers, projectColumnEvent, ProjectColumnAction.Deleted);
                case ProjectColumnActionValue.Edited:
                    return this.ProcessProjectColumnWebhook(headers, projectColumnEvent, ProjectColumnAction.Edited);
                case ProjectColumnActionValue.Moved:
                    return this.ProcessProjectColumnWebhook(headers, projectColumnEvent, ProjectColumnAction.Moved);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessProjectColumnWebhook(WebhookHeaders headers, ProjectColumnEvent projectColumnEvent, ProjectColumnAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessPublicWebhook(WebhookHeaders headers, PublicEvent publicEvent) => Task.CompletedTask;

        private Task ProcessPullRequestWebhook(WebhookHeaders headers, string body)
        {
            var pullRequestEvent = JsonSerializer.Deserialize<PullRequestEvent>(body)!;
            switch (pullRequestEvent.Action)
            {
                case PullRequestActionValue.Assigned:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Assigned);
                case PullRequestActionValue.AutoMergeDisabled:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.AutoMergeDisabled);
                case PullRequestActionValue.AutoMergeEnabled:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.AutoMergeEnabled);
                case PullRequestActionValue.Closed:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Closed);
                case PullRequestActionValue.ConvertedToDraft:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.ConvertedToDraft);
                case PullRequestActionValue.Edited:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Edited);
                case PullRequestActionValue.Labeled:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Labeled);
                case PullRequestActionValue.Locked:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Locked);
                case PullRequestActionValue.Opened:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Opened);
                case PullRequestActionValue.ReadyForReview:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.ReadyForReview);
                case PullRequestActionValue.Reopened:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Reopened);
                case PullRequestActionValue.ReviewRequestRemoved:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.ReviewRequestRemoved);
                case PullRequestActionValue.ReviewRequested:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.ReviewRequested);
                case PullRequestActionValue.Synchronize:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Synchronize);
                case PullRequestActionValue.Unassigned:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Unassigned);
                case PullRequestActionValue.Unlabeled:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Unlabeled);
                case PullRequestActionValue.Unlocked:
                    return this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Unlocked);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessPullRequestWebhook(WebhookHeaders headers, PullRequestEvent pullRequestEvent, PullRequestAction action) => Task.CompletedTask;

        private Task ProcessPullRequestReviewWebhook(WebhookHeaders headers, string body)
        {
            var pullRequestReviewEvent = JsonSerializer.Deserialize<PullRequestReviewEvent>(body)!;
            switch (pullRequestReviewEvent.Action)
            {
                case PullRequestReviewActionValue.Dismissed:
                    return this.ProcessPullRequestReviewWebhook(headers, pullRequestReviewEvent, PullRequestReviewAction.Dismissed);
                case PullRequestReviewActionValue.Edited:
                    return this.ProcessPullRequestReviewWebhook(headers, pullRequestReviewEvent, PullRequestReviewAction.Edited);
                case PullRequestReviewActionValue.Submitted:
                    return this.ProcessPullRequestReviewWebhook(headers, pullRequestReviewEvent, PullRequestReviewAction.Submitted);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessPullRequestReviewWebhook(WebhookHeaders headers, PullRequestReviewEvent pullRequestReviewEvent, PullRequestReviewAction action) => Task.CompletedTask;

        private Task ProcessPullRequestReviewCommentWebhook(WebhookHeaders headers, string body)
        {
            var pullRequestReviewCommentEvent = JsonSerializer.Deserialize<PullRequestReviewCommentEvent>(body)!;
            switch (pullRequestReviewCommentEvent.Action)
            {
                case PullRequestReviewCommentActionValue.Created:
                    return this.ProcessPullRequestReviewCommentWebhook(headers, pullRequestReviewCommentEvent, PullRequestReviewCommentAction.Created);
                case PullRequestReviewCommentActionValue.Deleted:
                    return this.ProcessPullRequestReviewCommentWebhook(headers, pullRequestReviewCommentEvent, PullRequestReviewCommentAction.Deleted);
                case PullRequestReviewCommentActionValue.Edited:
                    return this.ProcessPullRequestReviewCommentWebhook(headers, pullRequestReviewCommentEvent, PullRequestReviewCommentAction.Edited);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessPullRequestReviewCommentWebhook(WebhookHeaders headers, PullRequestReviewCommentEvent pullRequestReviewCommentEvent, PullRequestReviewCommentAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessPushWebhook(WebhookHeaders headers, PushEvent pushEvent) => Task.CompletedTask;

        private Task ProcessReleaseWebhook(WebhookHeaders headers, string body)
        {
            var releaseEvent = JsonSerializer.Deserialize<ReleaseEvent>(body)!;
            switch (releaseEvent.Action)
            {
                case ReleaseActionValue.Created:
                    return this.ProcessReleaseWebhook(headers, releaseEvent, ReleaseAction.Created);
                case ReleaseActionValue.Deleted:
                    return this.ProcessReleaseWebhook(headers, releaseEvent, ReleaseAction.Deleted);
                case ReleaseActionValue.Edited:
                    return this.ProcessReleaseWebhook(headers, releaseEvent, ReleaseAction.Edited);
                case ReleaseActionValue.Prereleased:
                    return this.ProcessReleaseWebhook(headers, releaseEvent, ReleaseAction.Prereleased);
                case ReleaseActionValue.Published:
                    return this.ProcessReleaseWebhook(headers, releaseEvent, ReleaseAction.Published);
                case ReleaseActionValue.Released:
                    return this.ProcessReleaseWebhook(headers, releaseEvent, ReleaseAction.Released);
                case ReleaseActionValue.Unpublished:
                    return this.ProcessReleaseWebhook(headers, releaseEvent, ReleaseAction.Unpublished);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessReleaseWebhook(WebhookHeaders headers, ReleaseEvent releaseEvent, ReleaseAction action) => Task.CompletedTask;

        private Task ProcessRepositoryWebhook(WebhookHeaders headers, string body)
        {
            var repositoryEvent = JsonSerializer.Deserialize<RepositoryEvent>(body)!;
            switch (repositoryEvent.Action)
            {
                case RepositoryActionValue.Archived:
                    return this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Archived);
                case RepositoryActionValue.Created:
                    return this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Created);
                case RepositoryActionValue.Deleted:
                    return this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Deleted);
                case RepositoryActionValue.Edited:
                    return this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Edited);
                case RepositoryActionValue.Privatized:
                    return this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Privatized);
                case RepositoryActionValue.Publicized:
                    return this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Publicized);
                case RepositoryActionValue.Renamed:
                    return this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Renamed);
                case RepositoryActionValue.Transferred:
                    return this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Transferred);
                case RepositoryActionValue.Unarchived:
                    return this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Unarchived);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessRepositoryWebhook(WebhookHeaders headers, RepositoryEvent repositoryEvent, RepositoryAction action) => Task.CompletedTask;

        private Task ProcessRepositoryDispatchWebhook(WebhookHeaders headers, string body)
        {
            var repositoryDispatchEvent = JsonSerializer.Deserialize<RepositoryDispatchEvent>(body)!;
            switch (repositoryDispatchEvent.Action)
            {
                case RepositoryDispatchActionValue.OnDemandTest:
                    return this.ProcessRepositoryDispatchWebhook(headers, repositoryDispatchEvent, RepositoryDispatchAction.OnDemandTest);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessRepositoryDispatchWebhook(WebhookHeaders headers, RepositoryDispatchEvent repositoryDispatchEvent, RepositoryDispatchAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessRepositoryImportWebhook(WebhookHeaders headers, RepositoryImportEvent repositoryImportEvent) => Task.CompletedTask;

        private Task ProcessRepositoryVulnerabilityAlertWebhook(WebhookHeaders headers, string body)
        {
            var repositoryVulnerabilityAlertEvent = JsonSerializer.Deserialize<RepositoryVulnerabilityAlertEvent>(body)!;
            switch (repositoryVulnerabilityAlertEvent.Action)
            {
                case RepositoryVulnerabilityAlertActionValue.Create:
                    return this.ProcessRepositoryVulnerabilityAlertWebhook(headers, repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction.Create);
                case RepositoryVulnerabilityAlertActionValue.Dismiss:
                    return this.ProcessRepositoryVulnerabilityAlertWebhook(headers, repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction.Dismiss);
                case RepositoryVulnerabilityAlertActionValue.Resolve:
                    return this.ProcessRepositoryVulnerabilityAlertWebhook(headers, repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction.Resolve);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessRepositoryVulnerabilityAlertWebhook(WebhookHeaders headers, RepositoryVulnerabilityAlertEvent repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction action) => Task.CompletedTask;

        private Task ProcessSecretScanningAlertWebhook(WebhookHeaders headers, string body)
        {
            var secretScanningAlertEvent = JsonSerializer.Deserialize<SecretScanningAlertEvent>(body)!;
            switch (secretScanningAlertEvent.Action)
            {
                case SecretScanningAlertActionValue.Created:
                    return this.ProcessSecretScanningAlertWebhook(headers, secretScanningAlertEvent, SecretScanningAlertAction.Created);
                case SecretScanningAlertActionValue.Reopened:
                    return this.ProcessSecretScanningAlertWebhook(headers, secretScanningAlertEvent, SecretScanningAlertAction.Reopened);
                case SecretScanningAlertActionValue.Resolved:
                    return this.ProcessSecretScanningAlertWebhook(headers, secretScanningAlertEvent, SecretScanningAlertAction.Resolved);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessSecretScanningAlertWebhook(WebhookHeaders headers, SecretScanningAlertEvent secretScanningAlertEvent, SecretScanningAlertAction action) => Task.CompletedTask;

        private Task ProcessSecurityAdvisoryWebhook(WebhookHeaders headers, string body)
        {
            var securityAdvisoryEvent = JsonSerializer.Deserialize<SecurityAdvisoryEvent>(body)!;
            switch (securityAdvisoryEvent.Action)
            {
                case SecurityAdvisoryActionValue.Performed:
                    return this.ProcessSecurityAdvisoryWebhook(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Performed);
                case SecurityAdvisoryActionValue.Published:
                    return this.ProcessSecurityAdvisoryWebhook(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Published);
                case SecurityAdvisoryActionValue.Updated:
                    return this.ProcessSecurityAdvisoryWebhook(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Updated);
                case SecurityAdvisoryActionValue.Withdrawn:
                    return this.ProcessSecurityAdvisoryWebhook(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Withdrawn);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessSecurityAdvisoryWebhook(WebhookHeaders headers, SecurityAdvisoryEvent securityAdvisoryEvent, SecurityAdvisoryAction action) => Task.CompletedTask;

        private Task ProcessSponsorshipWebhook(WebhookHeaders headers, string body)
        {
            var sponsorshipEvent = JsonSerializer.Deserialize<SponsorshipEvent>(body)!;
            switch (sponsorshipEvent.Action)
            {
                case SponsorshipActionValue.Cancelled:
                    return this.ProcessSponsorshipWebhook(headers, sponsorshipEvent, SponsorshipAction.Cancelled);
                case SponsorshipActionValue.Created:
                    return this.ProcessSponsorshipWebhook(headers, sponsorshipEvent, SponsorshipAction.Created);
                case SponsorshipActionValue.Edited:
                    return this.ProcessSponsorshipWebhook(headers, sponsorshipEvent, SponsorshipAction.Edited);
                case SponsorshipActionValue.PendingCancellation:
                    return this.ProcessSponsorshipWebhook(headers, sponsorshipEvent, SponsorshipAction.PendingCancellation);
                case SponsorshipActionValue.PendingTierChange:
                    return this.ProcessSponsorshipWebhook(headers, sponsorshipEvent, SponsorshipAction.PendingTierChange);
                case SponsorshipActionValue.TierChanged:
                    return this.ProcessSponsorshipWebhook(headers, sponsorshipEvent, SponsorshipAction.TierChanged);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessSponsorshipWebhook(WebhookHeaders headers, SponsorshipEvent sponsorshipEvent, SponsorshipAction action) => Task.CompletedTask;

        private Task ProcessStarWebhook(WebhookHeaders headers, string body)
        {
            var starEvent = JsonSerializer.Deserialize<StarEvent>(body)!;
            switch (starEvent.Action)
            {
                case StarActionValue.Created:
                    return this.ProcessStarWebhook(headers, starEvent, StarAction.Created);
                case StarActionValue.Deleted:
                    return this.ProcessStarWebhook(headers, starEvent, StarAction.Deleted);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessStarWebhook(WebhookHeaders headers, StarEvent starEvent, StarAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessStatusWebhook(WebhookHeaders headers, StatusEvent statusEvent) => Task.CompletedTask;

        private Task ProcessTeamWebhook(WebhookHeaders headers, string body)
        {
            var teamEvent = JsonSerializer.Deserialize<TeamEvent>(body)!;
            switch (teamEvent.Action)
            {
                case TeamActionValue.AddedToRepository:
                    return this.ProcessTeamWebhook(headers, teamEvent, TeamAction.AddedToRepository);
                case TeamActionValue.Created:
                    return this.ProcessTeamWebhook(headers, teamEvent, TeamAction.Created);
                case TeamActionValue.Deleted:
                    return this.ProcessTeamWebhook(headers, teamEvent, TeamAction.Deleted);
                case TeamActionValue.Edited:
                    return this.ProcessTeamWebhook(headers, teamEvent, TeamAction.Edited);
                case TeamActionValue.RemovedFromRepository:
                    return this.ProcessTeamWebhook(headers, teamEvent, TeamAction.RemovedFromRepository);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessTeamWebhook(WebhookHeaders headers, TeamEvent teamEvent, TeamAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessTeamAddWebhook(WebhookHeaders headers, TeamAddEvent teamAddEvent) => Task.CompletedTask;

        private Task ProcessWatchWebhook(WebhookHeaders headers, string body)
        {
            var watchEvent = JsonSerializer.Deserialize<WatchEvent>(body)!;
            switch (watchEvent.Action)
            {
                case WatchActionValue.Started:
                    return this.ProcessWatchWebhook(headers, watchEvent, WatchAction.Started);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessWatchWebhook(WebhookHeaders headers, WatchEvent watchEvent, WatchAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessWorkflowDispatchWebhook(WebhookHeaders headers, WorkflowDispatchEvent workflowDispatchEvent) => Task.CompletedTask;

        private Task ProcessWorkflowJobWebhook(WebhookHeaders headers, string body)
        {
            var workflowJobEvent = JsonSerializer.Deserialize<WorkflowJobEvent>(body)!;
            switch (workflowJobEvent.Action)
            {
                case WorkflowJobActionValue.Completed:
                    return this.ProcessWorkflowJobWebhook(headers, workflowJobEvent, WorkflowJobAction.Completed);
                case WorkflowJobActionValue.Started:
                    return this.ProcessWorkflowJobWebhook(headers, workflowJobEvent, WorkflowJobAction.Started);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessWorkflowJobWebhook(WebhookHeaders headers, WorkflowJobEvent workflowJobEvent, WorkflowJobAction action) => Task.CompletedTask;

        private Task ProcessWorkflowRunWebhook(WebhookHeaders headers, string body)
        {
            var workflowRunEvent = JsonSerializer.Deserialize<WorkflowRunEvent>(body)!;
            switch (workflowRunEvent.Action)
            {
                case WorkflowRunActionValue.Completed:
                    return this.ProcessWorkflowRunWebhook(headers, workflowRunEvent, WorkflowRunAction.Completed);
                case WorkflowRunActionValue.Requested:
                    return this.ProcessWorkflowRunWebhook(headers, workflowRunEvent, WorkflowRunAction.Requested);
            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessWorkflowRunWebhook(WebhookHeaders headers, WorkflowRunEvent workflowRunEvent, WorkflowRunAction action) => Task.CompletedTask;
    }
}
