namespace JamieMagee.Octokit.Webhooks
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using JamieMagee.Octokit.Webhooks.Events;
    using JamieMagee.Octokit.Webhooks.Events.BranchProtectionRule;
    using JamieMagee.Octokit.Webhooks.Events.CheckRun;
    using JamieMagee.Octokit.Webhooks.Events.CheckSuite;
    using JamieMagee.Octokit.Webhooks.Events.CodeScanningAlert;
    using JamieMagee.Octokit.Webhooks.Events.CommitComment;
    using JamieMagee.Octokit.Webhooks.Events.ContentReference;
    using JamieMagee.Octokit.Webhooks.Events.DeployKey;
    using JamieMagee.Octokit.Webhooks.Events.Deployment;
    using JamieMagee.Octokit.Webhooks.Events.DeploymentStatus;
    using JamieMagee.Octokit.Webhooks.Events.Discussion;
    using JamieMagee.Octokit.Webhooks.Events.DiscussionComment;
    using JamieMagee.Octokit.Webhooks.Events.GithubAppAuthorization;
    using JamieMagee.Octokit.Webhooks.Events.Installation;
    using JamieMagee.Octokit.Webhooks.Events.InstallationRepositories;
    using JamieMagee.Octokit.Webhooks.Events.IssueComment;
    using JamieMagee.Octokit.Webhooks.Events.Issues;
    using JamieMagee.Octokit.Webhooks.Events.Label;
    using JamieMagee.Octokit.Webhooks.Events.MarketplacePurchase;
    using JamieMagee.Octokit.Webhooks.Events.Member;
    using JamieMagee.Octokit.Webhooks.Events.Membership;
    using JamieMagee.Octokit.Webhooks.Events.Meta;
    using JamieMagee.Octokit.Webhooks.Events.Milestone;
    using JamieMagee.Octokit.Webhooks.Events.Organization;
    using JamieMagee.Octokit.Webhooks.Events.OrgBlock;
    using JamieMagee.Octokit.Webhooks.Events.Package;
    using JamieMagee.Octokit.Webhooks.Events.Project;
    using JamieMagee.Octokit.Webhooks.Events.ProjectCard;
    using JamieMagee.Octokit.Webhooks.Events.ProjectColumn;
    using JamieMagee.Octokit.Webhooks.Events.PullRequest;
    using JamieMagee.Octokit.Webhooks.Events.PullRequestReview;
    using JamieMagee.Octokit.Webhooks.Events.PullRequestReviewComment;
    using JamieMagee.Octokit.Webhooks.Events.Release;
    using JamieMagee.Octokit.Webhooks.Events.Repository;
    using JamieMagee.Octokit.Webhooks.Events.RepositoryDispatch;
    using JamieMagee.Octokit.Webhooks.Events.RepositoryVulnerabilityAlert;
    using JamieMagee.Octokit.Webhooks.Events.SecretScanningAlert;
    using JamieMagee.Octokit.Webhooks.Events.SecurityAdvisory;
    using JamieMagee.Octokit.Webhooks.Events.Sponsorship;
    using JamieMagee.Octokit.Webhooks.Events.Star;
    using JamieMagee.Octokit.Webhooks.Events.Team;
    using JamieMagee.Octokit.Webhooks.Events.Watch;
    using JamieMagee.Octokit.Webhooks.Events.WorkflowJob;
    using JamieMagee.Octokit.Webhooks.Events.WorkflowRun;
    using JetBrains.Annotations;
    using Microsoft.Extensions.Primitives;

    public abstract class WebhookProcessor
    {
        [PublicAPI]
        public virtual void ProcessWebhook(IDictionary<string, StringValues> headers, string body)
        {
            if (headers is null)
            {
                throw new ArgumentNullException(nameof(headers));
            }

            if (body is null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            this.ProcessWebhook(WebhookHeaders.Parse(headers), body);
        }

        [PublicAPI]
        public virtual void ProcessWebhook(WebhookHeaders headers, string body)
        {
            switch (headers.Event)
            {
                case WebhookEventType.BranchProtectionRule:
                    this.ProcessBranchProtectionRuleWebhook(headers, body);
                    break;
                case WebhookEventType.CheckRun:
                    this.ProcessCheckRunWebhook(headers, body);
                    break;
                case WebhookEventType.CheckSuite:
                    this.ProcessCheckSuiteWebhook(headers, body);
                    break;
                case WebhookEventType.CodeScanningAlert:
                    this.ProcessCodeScanningAlertWebhook(headers, body);
                    break;
                case WebhookEventType.CommitComment:
                    this.ProcessCommitCommentWebhook(headers, body);
                    break;
                case WebhookEventType.ContentReference:
                    this.ProcessContentReferenceWebhook(headers, body);
                    break;
                case WebhookEventType.Create:
                    this.ProcessCreateWebhook(headers, JsonSerializer.Deserialize<CreateEvent>(body)!);
                    break;
                case WebhookEventType.Delete:
                    this.ProcessDeleteWebhook(headers, JsonSerializer.Deserialize<DeleteEvent>(body)!);
                    break;
                case WebhookEventType.DeployKey:
                    this.ProcessDeployKeyWebhook(headers, body);
                    break;
                case WebhookEventType.Deployment:
                    this.ProcessDeploymentWebhook(headers, body);
                    break;
                case WebhookEventType.DeploymentStatus:
                    this.ProcessDeploymentStatusWebhook(headers, body);
                    break;
                case WebhookEventType.Discussion:
                    this.ProcessDiscussionWebhook(headers, body);
                    break;
                case WebhookEventType.DiscussionComment:
                    this.ProcessDiscussionCommentWebhook(headers, body);
                    break;
                case WebhookEventType.Fork:
                    this.ProcessForkWebhook(headers, JsonSerializer.Deserialize<ForkEvent>(body)!);
                    break;
                case WebhookEventType.GithubAppAuthorization:
                    this.ProcessGithubAppAuthorizationWebhook(headers, body);
                    break;
                case WebhookEventType.Gollum:
                    this.ProcessGollumWebhook(headers, JsonSerializer.Deserialize<GollumEvent>(body)!);
                    break;
                case WebhookEventType.Installation:
                    this.ProcessInstallationWebhook(headers, body);
                    break;
                case WebhookEventType.InstallationRepositories:
                    this.ProcessInstallationRepositoriesWebhook(headers, body);
                    break;
                case WebhookEventType.IssueComment:
                    this.ProcessIssueCommentWebhook(headers, body);
                    break;
                case WebhookEventType.Issues:
                    this.ProcessIssuesWebhook(headers, body);
                    break;
                case WebhookEventType.Label:
                    this.ProcessLabelWebhook(headers, body);
                    break;
                case WebhookEventType.MarketplacePurchase:
                    this.ProcessMarketplacePurchaseWebhook(headers, body);
                    break;
                case WebhookEventType.Member:
                    this.ProcessMemberWebhook(headers, body);
                    break;
                case WebhookEventType.Membership:
                    this.ProcessMembershipWebhook(headers, body);
                    break;
                case WebhookEventType.Meta:
                    this.ProcessMetaWebhook(headers, body);
                    break;
                case WebhookEventType.Milestone:
                    this.ProcessMilestoneWebhook(headers, body);
                    break;
                case WebhookEventType.OrgBlock:
                    this.ProcessOrgBlockWebhook(headers, body);
                    break;
                case WebhookEventType.Organization:
                    this.ProcessOrganizationWebhook(headers, body);
                    break;
                case WebhookEventType.Package:
                    this.ProcessPackageWebhook(headers, body);
                    break;
                case WebhookEventType.PageBuild:
                    this.ProcessPageBuildWebhook(headers, JsonSerializer.Deserialize<PageBuildEvent>(body)!);
                    break;
                case WebhookEventType.Ping:
                    this.ProcessPingWebhook(headers, JsonSerializer.Deserialize<PingEvent>(body)!);
                    break;
                case WebhookEventType.Project:
                    this.ProcessProjectWebhook(headers, body);
                    break;
                case WebhookEventType.ProjectCard:
                    this.ProcessProjectCardWebhook(headers, body);
                    break;
                case WebhookEventType.ProjectColumn:
                    this.ProcessProjectColumnWebhook(headers, body);
                    break;
                case WebhookEventType.Public:
                    this.ProcessPublicWebhook(headers, JsonSerializer.Deserialize<PublicEvent>(body)!);
                    break;
                case WebhookEventType.PullRequest:
                    this.ProcessPullRequestWebhook(headers, body);
                    break;
                case WebhookEventType.PullRequestReview:
                    this.ProcessPullRequestReviewWebhook(headers, body);
                    break;
                case WebhookEventType.PullRequestReviewComment:
                    this.ProcessPullRequestReviewCommentWebhook(headers, body);
                    break;
                case WebhookEventType.Push:
                    this.ProcessPushWebhook(headers, JsonSerializer.Deserialize<PushEvent>(body)!);
                    break;
                case WebhookEventType.Release:
                    this.ProcessReleaseWebhook(headers, body);
                    break;
                case WebhookEventType.Repository:
                    this.ProcessRepositoryWebhook(headers, body);
                    break;
                case WebhookEventType.RepositoryDispatch:
                    this.ProcessRepositoryDispatchWebhook(headers, body);
                    break;
                case WebhookEventType.RepositoryImport:
                    this.ProcessRepositoryImportWebhook(headers, JsonSerializer.Deserialize<RepositoryImportEvent>(body)!);
                    break;
                case WebhookEventType.RepositoryVulnerabilityAlert:
                    this.ProcessRepositoryVulnerabilityAlertWebhook(headers, body);
                    break;
                case WebhookEventType.SecretScanningAlert:
                    this.ProcessSecretScanningAlertWebhook(headers, body);
                    break;
                case WebhookEventType.SecurityAdvisory:
                    this.ProcessSecurityAdvisoryWebhook(headers, body);
                    break;
                case WebhookEventType.Sponsorship:
                    this.ProcessSponsorshipWebhook(headers, body);
                    break;
                case WebhookEventType.Star:
                    this.ProcessStarWebhook(headers, body);
                    break;
                case WebhookEventType.Status:
                    this.ProcessStatusWebhook(headers, JsonSerializer.Deserialize<StatusEvent>(body)!);
                    break;
                case WebhookEventType.Team:
                    this.ProcessTeamWebhook(headers, body);
                    break;
                case WebhookEventType.TeamAdd:
                    this.ProcessTeamAddWebhook(headers, JsonSerializer.Deserialize<TeamAddEvent>(body)!);
                    break;
                case WebhookEventType.Watch:
                    this.ProcessWatchWebhook(headers, body);
                    break;
                case WebhookEventType.WorkflowDispatch:
                    this.ProcessWorkflowDispatchWebhook(headers, JsonSerializer.Deserialize<WorkflowDispatchEvent>(body)!);
                    break;
                case WebhookEventType.WorkflowJob:
                    this.ProcessWorkflowJobWebhook(headers, body);
                    break;
                case WebhookEventType.WorkflowRun:
                    this.ProcessWorkflowRunWebhook(headers, body);
                    break;
            }
        }

        private void ProcessBranchProtectionRuleWebhook(WebhookHeaders headers, string body)
        {
            var branchProtectionRuleEvent = JsonSerializer.Deserialize<BranchProtectionRuleEvent>(body)!;
            switch (branchProtectionRuleEvent.Action)
            {
                case BranchProtectionRuleActionValue.Created:
                    this.ProcessBranchProtectionRuleWebhook(headers, branchProtectionRuleEvent, BranchProtectionRuleAction.Created);
                    break;
                case BranchProtectionRuleActionValue.Deleted:
                    this.ProcessBranchProtectionRuleWebhook(headers, branchProtectionRuleEvent, BranchProtectionRuleAction.Deleted);
                    break;
                case BranchProtectionRuleActionValue.Edited:
                    this.ProcessBranchProtectionRuleWebhook(headers, branchProtectionRuleEvent, BranchProtectionRuleAction.Edited);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessBranchProtectionRuleWebhook(WebhookHeaders headers, BranchProtectionRuleEvent branchProtectionRuleEvent, BranchProtectionRuleAction action)
        {
        }

        private void ProcessCheckRunWebhook(WebhookHeaders headers, string body)
        {
            var checkRunEvent = JsonSerializer.Deserialize<CheckRunEvent>(body)!;
            switch (checkRunEvent.Action)
            {
                case CheckRunActionValue.Completed:
                    this.ProcessCheckRunWebhook(headers, checkRunEvent, CheckRunAction.Completed);
                    break;
                case CheckRunActionValue.Created:
                    this.ProcessCheckRunWebhook(headers, checkRunEvent, CheckRunAction.Created);
                    break;
                case CheckRunActionValue.RequestedAction:
                    this.ProcessCheckRunWebhook(headers, checkRunEvent, CheckRunAction.RequestedAction);
                    break;
                case CheckRunActionValue.Rerequested:
                    this.ProcessCheckRunWebhook(headers, checkRunEvent, CheckRunAction.Rerequested);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessCheckRunWebhook(WebhookHeaders headers, CheckRunEvent checkRunEvent, CheckRunAction action)
        {
        }

        private void ProcessCheckSuiteWebhook(WebhookHeaders headers, string body)
        {
            var checkSuiteEvent = JsonSerializer.Deserialize<CheckSuiteEvent>(body)!;
            switch (checkSuiteEvent.Action)
            {
                case CheckSuiteActionValue.Completed:
                    this.ProcessCheckSuiteWebhook(headers, checkSuiteEvent, CheckSuiteAction.Completed);
                    break;
                case CheckSuiteActionValue.Requested:
                    this.ProcessCheckSuiteWebhook(headers, checkSuiteEvent, CheckSuiteAction.Requested);
                    break;
                case CheckSuiteActionValue.Rerequested:
                    this.ProcessCheckSuiteWebhook(headers, checkSuiteEvent, CheckSuiteAction.Rerequested);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessCheckSuiteWebhook(WebhookHeaders headers, CheckSuiteEvent checkSuiteEvent, CheckSuiteAction action)
        {
        }

        private void ProcessCodeScanningAlertWebhook(WebhookHeaders headers, string body)
        {
            var codeScanningAlertEvent = JsonSerializer.Deserialize<CodeScanningAlertEvent>(body)!;
            switch (codeScanningAlertEvent.Action)
            {
                case CodeScanningAlertActionValue.AppearedInBranch:
                    this.ProcessCodeScanningAlertWebhook(headers, codeScanningAlertEvent, CodeScanningAlertAction.AppearedInBranch);
                    break;
                case CodeScanningAlertActionValue.ClosedByUser:
                    this.ProcessCodeScanningAlertWebhook(headers, codeScanningAlertEvent, CodeScanningAlertAction.ClosedByUser);
                    break;
                case CodeScanningAlertActionValue.Created:
                    this.ProcessCodeScanningAlertWebhook(headers, codeScanningAlertEvent, CodeScanningAlertAction.Created);
                    break;
                case CodeScanningAlertActionValue.Fixed:
                    this.ProcessCodeScanningAlertWebhook(headers, codeScanningAlertEvent, CodeScanningAlertAction.Fixed);
                    break;
                case CodeScanningAlertActionValue.Reopened:
                    this.ProcessCodeScanningAlertWebhook(headers, codeScanningAlertEvent, CodeScanningAlertAction.Reopened);
                    break;
                case CodeScanningAlertActionValue.ReopenedByUser:
                    this.ProcessCodeScanningAlertWebhook(headers, codeScanningAlertEvent, CodeScanningAlertAction.ReopenedByUser);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessCodeScanningAlertWebhook(WebhookHeaders headers, CodeScanningAlertEvent codeScanningAlertEvent, CodeScanningAlertAction action)
        {
        }

        private void ProcessCommitCommentWebhook(WebhookHeaders headers, string body)
        {
            var commitCommentEvent = JsonSerializer.Deserialize<CommitCommentEvent>(body)!;
            switch (commitCommentEvent.Action)
            {
                case CommitCommentActionValue.Created:
                    this.ProcessCommitCommentWebhook(headers, commitCommentEvent, CommitCommentAction.Created);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessCommitCommentWebhook(WebhookHeaders headers, CommitCommentEvent commitCommentEvent, CommitCommentAction action)
        {
        }

        private void ProcessContentReferenceWebhook(WebhookHeaders headers, string body)
        {
            var contentReferenceEvent = JsonSerializer.Deserialize<ContentReferenceEvent>(body)!;
            switch (contentReferenceEvent.Action)
            {
                case ContentReferenceActionValue.Created:
                    this.ProcessContentReferenceWebhook(headers, contentReferenceEvent, ContentReferenceAction.Created);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessContentReferenceWebhook(WebhookHeaders headers, ContentReferenceEvent contentReferenceEvent, ContentReferenceAction action)
        {
        }

        [PublicAPI]
        protected virtual void ProcessCreateWebhook(WebhookHeaders headers, CreateEvent createEvent)
        {
        }

        [PublicAPI]
        protected virtual void ProcessDeleteWebhook(WebhookHeaders headers, DeleteEvent deleteEvent)
        {
        }

        private void ProcessDeployKeyWebhook(WebhookHeaders headers, string body)
        {
            var deployKeyEvent = JsonSerializer.Deserialize<DeployKeyEvent>(body)!;
            switch (deployKeyEvent.Action)
            {
                case DeployKeyActionValue.Created:
                    this.ProcessDeployKeyWebhook(headers, deployKeyEvent, DeployKeyAction.Created);
                    break;
                case DeployKeyActionValue.Deleted:
                    this.ProcessDeployKeyWebhook(headers, deployKeyEvent, DeployKeyAction.Deleted);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessDeployKeyWebhook(WebhookHeaders headers, DeployKeyEvent deployKeyEvent, DeployKeyAction action)
        {
        }

        private void ProcessDeploymentWebhook(WebhookHeaders headers, string body)
        {
            var deploymentEvent = JsonSerializer.Deserialize<DeploymentEvent>(body)!;
            switch (deploymentEvent.Action)
            {
                case DeploymentActionValue.Created:
                    this.ProcessDeploymentWebhook(headers, deploymentEvent, DeploymentAction.Created);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessDeploymentWebhook(WebhookHeaders headers, DeploymentEvent deploymentEvent, DeploymentAction action)
        {
        }

        private void ProcessDeploymentStatusWebhook(WebhookHeaders headers, string body)
        {
            var deploymentStatusEvent = JsonSerializer.Deserialize<DeploymentStatusEvent>(body)!;
            switch (deploymentStatusEvent.Action)
            {
                case DeploymentStatusActionValue.Created:
                    this.ProcessDeploymentStatusWebhook(headers, deploymentStatusEvent, DeploymentStatusAction.Created);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessDeploymentStatusWebhook(WebhookHeaders headers, DeploymentStatusEvent deploymentStatusEvent, DeploymentStatusAction action)
        {
        }

        private void ProcessDiscussionWebhook(WebhookHeaders headers, string body)
        {
            var discussionEvent = JsonSerializer.Deserialize<DiscussionEvent>(body)!;
            switch (discussionEvent.Action)
            {
                case DiscussionActionValue.Answered:
                    this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Answered);
                    break;
                case DiscussionActionValue.CategoryChanged:
                    this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.CategoryChanged);
                    break;
                case DiscussionActionValue.Created:
                    this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Created);
                    break;
                case DiscussionActionValue.Deleted:
                    this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Deleted);
                    break;
                case DiscussionActionValue.Edited:
                    this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Edited);
                    break;
                case DiscussionActionValue.Labeled:
                    this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Labeled);
                    break;
                case DiscussionActionValue.Locked:
                    this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Locked);
                    break;
                case DiscussionActionValue.Pinned:
                    this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Pinned);
                    break;
                case DiscussionActionValue.Transferred:
                    this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Transferred);
                    break;
                case DiscussionActionValue.Unanswered:
                    this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Unanswered);
                    break;
                case DiscussionActionValue.Unlabeled:
                    this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Unlabeled);
                    break;
                case DiscussionActionValue.Unlocked:
                    this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Unlocked);
                    break;
                case DiscussionActionValue.Unpinned:
                    this.ProcessDiscussionWebhook(headers, discussionEvent, DiscussionAction.Unpinned);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessDiscussionWebhook(WebhookHeaders headers, DiscussionEvent discussionEvent, DiscussionAction action)
        {
        }

        private void ProcessDiscussionCommentWebhook(WebhookHeaders headers, string body)
        {
            var discussionCommentEvent = JsonSerializer.Deserialize<DiscussionCommentEvent>(body)!;
            switch (discussionCommentEvent.Action)
            {
                case DiscussionCommentActionValue.Created:
                    this.ProcessDiscussionCommentWebhook(headers, discussionCommentEvent, DiscussionCommentAction.Created);
                    break;
                case DiscussionCommentActionValue.Deleted:
                    this.ProcessDiscussionCommentWebhook(headers, discussionCommentEvent, DiscussionCommentAction.Deleted);
                    break;
                case DiscussionCommentActionValue.Edited:
                    this.ProcessDiscussionCommentWebhook(headers, discussionCommentEvent, DiscussionCommentAction.Edited);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessDiscussionCommentWebhook(WebhookHeaders headers, DiscussionCommentEvent discussionCommentEvent, DiscussionCommentAction action)
        {
        }

        [PublicAPI]
        protected virtual void ProcessForkWebhook(WebhookHeaders headers, ForkEvent forkEvent)
        {
        }

        private void ProcessGithubAppAuthorizationWebhook(WebhookHeaders headers, string body)
        {
            var githubAppAuthorizationEvent = JsonSerializer.Deserialize<GithubAppAuthorizationEvent>(body)!;
            switch (githubAppAuthorizationEvent.Action)
            {
                case GithubAppAuthorizationActionValue.Revoked:
                    this.ProcessGithubAppAuthorizationWebhook(headers, githubAppAuthorizationEvent, GithubAppAuthorizationAction.Revoked);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessGithubAppAuthorizationWebhook(WebhookHeaders headers, GithubAppAuthorizationEvent githubAppAuthorizationEvent, GithubAppAuthorizationAction action)
        {
        }

        [PublicAPI]
        protected virtual void ProcessGollumWebhook(WebhookHeaders headers, GollumEvent gollumEvent)
        {
        }

        private void ProcessInstallationWebhook(WebhookHeaders headers, string body)
        {
            var installationEvent = JsonSerializer.Deserialize<InstallationEvent>(body)!;
            switch (installationEvent.Action)
            {
                case InstallationActionValue.Created:
                    this.ProcessInstallationWebhook(headers, installationEvent, InstallationAction.Created);
                    break;
                case InstallationActionValue.Deleted:
                    this.ProcessInstallationWebhook(headers, installationEvent, InstallationAction.Deleted);
                    break;
                case InstallationActionValue.NewPermissionsAccepted:
                    this.ProcessInstallationWebhook(headers, installationEvent, InstallationAction.NewPermissionsAccepted);
                    break;
                case InstallationActionValue.Suspend:
                    this.ProcessInstallationWebhook(headers, installationEvent, InstallationAction.Suspend);
                    break;
                case InstallationActionValue.Unsuspend:
                    this.ProcessInstallationWebhook(headers, installationEvent, InstallationAction.Unsuspend);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessInstallationWebhook(WebhookHeaders headers, InstallationEvent installationEvent, InstallationAction action)
        {
        }

        private void ProcessInstallationRepositoriesWebhook(WebhookHeaders headers, string body)
        {
            var installationRepositoriesEvent = JsonSerializer.Deserialize<InstallationRepositoriesEvent>(body)!;
            switch (installationRepositoriesEvent.Action)
            {
                case InstallationRepositoriesActionValue.Added:
                    this.ProcessInstallationRepositoriesWebhook(headers, installationRepositoriesEvent, InstallationRepositoriesAction.Added);
                    break;
                case InstallationRepositoriesActionValue.Removed:
                    this.ProcessInstallationRepositoriesWebhook(headers, installationRepositoriesEvent, InstallationRepositoriesAction.Removed);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessInstallationRepositoriesWebhook(WebhookHeaders headers, InstallationRepositoriesEvent installationRepositoriesEvent, InstallationRepositoriesAction action)
        {
        }

        private void ProcessIssueCommentWebhook(WebhookHeaders headers, string body)
        {
            var issueCommentEvent = JsonSerializer.Deserialize<IssueCommentEvent>(body)!;
            switch (issueCommentEvent.Action)
            {
                case IssueCommentActionValue.Created:
                    this.ProcessIssueCommentWebhook(headers, issueCommentEvent, IssueCommentAction.Created);
                    break;
                case IssueCommentActionValue.Deleted:
                    this.ProcessIssueCommentWebhook(headers, issueCommentEvent, IssueCommentAction.Deleted);
                    break;
                case IssueCommentActionValue.Edited:
                    this.ProcessIssueCommentWebhook(headers, issueCommentEvent, IssueCommentAction.Edited);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessIssueCommentWebhook(WebhookHeaders headers, IssueCommentEvent issueCommentEvent, IssueCommentAction action)
        {
        }

        private void ProcessIssuesWebhook(WebhookHeaders headers, string body)
        {
            var issuesEvent = JsonSerializer.Deserialize<IssuesEvent>(body)!;
            switch (issuesEvent.Action)
            {
                case IssuesActionValue.Assigned:
                    this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Assigned);
                    break;
                case IssuesActionValue.Closed:
                    this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Closed);
                    break;
                case IssuesActionValue.Deleted:
                    this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Deleted);
                    break;
                case IssuesActionValue.Demilestoned:
                    this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Demilestoned);
                    break;
                case IssuesActionValue.Edited:
                    this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Edited);
                    break;
                case IssuesActionValue.Labeled:
                    this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Labeled);
                    break;
                case IssuesActionValue.Locked:
                    this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Locked);
                    break;
                case IssuesActionValue.Milestoned:
                    this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Milestoned);
                    break;
                case IssuesActionValue.Opened:
                    this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Opened);
                    break;
                case IssuesActionValue.Pinned:
                    this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Pinned);
                    break;
                case IssuesActionValue.Reopened:
                    this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Reopened);
                    break;
                case IssuesActionValue.Transferred:
                    this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Transferred);
                    break;
                case IssuesActionValue.Unassigned:
                    this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Unassigned);
                    break;
                case IssuesActionValue.Unlabeled:
                    this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Unlabeled);
                    break;
                case IssuesActionValue.Unlocked:
                    this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Unlocked);
                    break;
                case IssuesActionValue.Unpinned:
                    this.ProcessIssuesWebhook(headers, issuesEvent, IssuesAction.Unpinned);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessIssuesWebhook(WebhookHeaders headers, IssuesEvent issuesEvent, IssuesAction action)
        {
        }

        private void ProcessLabelWebhook(WebhookHeaders headers, string body)
        {
            var labelEvent = JsonSerializer.Deserialize<LabelEvent>(body)!;
            switch (labelEvent.Action)
            {
                case LabelActionValue.Created:
                    this.ProcessLabelWebhook(headers, labelEvent, LabelAction.Created);
                    break;
                case LabelActionValue.Deleted:
                    this.ProcessLabelWebhook(headers, labelEvent, LabelAction.Deleted);
                    break;
                case LabelActionValue.Edited:
                    this.ProcessLabelWebhook(headers, labelEvent, LabelAction.Edited);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessLabelWebhook(WebhookHeaders headers, LabelEvent labelEvent, LabelAction action)
        {
        }

        private void ProcessMarketplacePurchaseWebhook(WebhookHeaders headers, string body)
        {
            var marketplacePurchaseEvent = JsonSerializer.Deserialize<MarketplacePurchaseEvent>(body)!;
            switch (marketplacePurchaseEvent.Action)
            {
                case MarketplacePurchaseActionValue.Cancelled:
                    this.ProcessMarketplacePurchaseWebhook(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.Cancelled);
                    break;
                case MarketplacePurchaseActionValue.Changed:
                    this.ProcessMarketplacePurchaseWebhook(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.Changed);
                    break;
                case MarketplacePurchaseActionValue.PendingChange:
                    this.ProcessMarketplacePurchaseWebhook(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.PendingChange);
                    break;
                case MarketplacePurchaseActionValue.PendingChangeCancelled:
                    this.ProcessMarketplacePurchaseWebhook(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.PendingChangeCancelled);
                    break;
                case MarketplacePurchaseActionValue.Purchased:
                    this.ProcessMarketplacePurchaseWebhook(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.Purchased);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessMarketplacePurchaseWebhook(WebhookHeaders headers, MarketplacePurchaseEvent marketplacePurchaseEvent, MarketplacePurchaseAction action)
        {
        }

        private void ProcessMemberWebhook(WebhookHeaders headers, string body)
        {
            var memberEvent = JsonSerializer.Deserialize<MemberEvent>(body)!;
            switch (memberEvent.Action)
            {
                case MemberActionValue.Added:
                    this.ProcessMemberWebhook(headers, memberEvent, MemberAction.Added);
                    break;
                case MemberActionValue.Edited:
                    this.ProcessMemberWebhook(headers, memberEvent, MemberAction.Edited);
                    break;
                case MemberActionValue.Removed:
                    this.ProcessMemberWebhook(headers, memberEvent, MemberAction.Removed);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessMemberWebhook(WebhookHeaders headers, MemberEvent memberEvent, MemberAction action)
        {
        }

        private void ProcessMembershipWebhook(WebhookHeaders headers, string body)
        {
            var membershipEvent = JsonSerializer.Deserialize<MembershipEvent>(body)!;
            switch (membershipEvent.Action)
            {
                case MembershipActionValue.Added:
                    this.ProcessMembershipWebhook(headers, membershipEvent, MembershipAction.Added);
                    break;
                case MembershipActionValue.Removed:
                    this.ProcessMembershipWebhook(headers, membershipEvent, MembershipAction.Removed);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessMembershipWebhook(WebhookHeaders headers, MembershipEvent membershipEvent, MembershipAction action)
        {
        }

        private void ProcessMetaWebhook(WebhookHeaders headers, string body)
        {
            var metaEvent = JsonSerializer.Deserialize<MetaEvent>(body)!;
            switch (metaEvent.Action)
            {
                case MetaActionValue.Deleted:
                    this.ProcessMetaWebhook(headers, metaEvent, MetaAction.Deleted);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessMetaWebhook(WebhookHeaders headers, MetaEvent metaEvent, MetaAction action)
        {
        }

        private void ProcessMilestoneWebhook(WebhookHeaders headers, string body)
        {
            var milestoneEvent = JsonSerializer.Deserialize<MilestoneEvent>(body)!;
            switch (milestoneEvent.Action)
            {
                case MilestoneActionValue.Closed:
                    this.ProcessMilestoneWebhook(headers, milestoneEvent, MilestoneAction.Closed);
                    break;
                case MilestoneActionValue.Created:
                    this.ProcessMilestoneWebhook(headers, milestoneEvent, MilestoneAction.Created);
                    break;
                case MilestoneActionValue.Deleted:
                    this.ProcessMilestoneWebhook(headers, milestoneEvent, MilestoneAction.Deleted);
                    break;
                case MilestoneActionValue.Edited:
                    this.ProcessMilestoneWebhook(headers, milestoneEvent, MilestoneAction.Edited);
                    break;
                case MilestoneActionValue.Opened:
                    this.ProcessMilestoneWebhook(headers, milestoneEvent, MilestoneAction.Opened);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessMilestoneWebhook(WebhookHeaders headers, MilestoneEvent milestoneEvent, MilestoneAction action)
        {
        }

        private void ProcessOrgBlockWebhook(WebhookHeaders headers, string body)
        {
            var orgBlockEvent = JsonSerializer.Deserialize<OrgBlockEvent>(body)!;
            switch (orgBlockEvent.Action)
            {
                case OrgBlockActionValue.Blocked:
                    this.ProcessOrgBlockWebhook(headers, orgBlockEvent, OrgBlockAction.Blocked);
                    break;
                case OrgBlockActionValue.Unblocked:
                    this.ProcessOrgBlockWebhook(headers, orgBlockEvent, OrgBlockAction.Unblocked);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessOrgBlockWebhook(WebhookHeaders headers, OrgBlockEvent orgBlockEvent, OrgBlockAction action)
        {
        }

        private void ProcessOrganizationWebhook(WebhookHeaders headers, string body)
        {
            var organizationEvent = JsonSerializer.Deserialize<OrganizationEvent>(body)!;
            switch (organizationEvent.Action)
            {
                case OrganizationActionValue.Deleted:
                    this.ProcessOrganizationWebhook(headers, organizationEvent, OrganizationAction.Deleted);
                    break;
                case OrganizationActionValue.MemberAdded:
                    this.ProcessOrganizationWebhook(headers, organizationEvent, OrganizationAction.MemberAdded);
                    break;
                case OrganizationActionValue.MemberInvited:
                    this.ProcessOrganizationWebhook(headers, organizationEvent, OrganizationAction.MemberInvited);
                    break;
                case OrganizationActionValue.MemberRemoved:
                    this.ProcessOrganizationWebhook(headers, organizationEvent, OrganizationAction.MemberRemoved);
                    break;
                case OrganizationActionValue.Renamed:
                    this.ProcessOrganizationWebhook(headers, organizationEvent, OrganizationAction.Renamed);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessOrganizationWebhook(WebhookHeaders headers, OrganizationEvent organizationEvent, OrganizationAction action)
        {
        }

        private void ProcessPackageWebhook(WebhookHeaders headers, string body)
        {
            var packageEvent = JsonSerializer.Deserialize<PackageEvent>(body)!;
            switch (packageEvent.Action)
            {
                case PackageActionValue.Published:
                    this.ProcessPackageWebhook(headers, packageEvent, PackageAction.Published);
                    break;
                case PackageActionValue.Updated:
                    this.ProcessPackageWebhook(headers, packageEvent, PackageAction.Updated);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessPackageWebhook(WebhookHeaders headers, PackageEvent packageEvent, PackageAction action)
        {
        }

        [PublicAPI]
        protected virtual void ProcessPageBuildWebhook(WebhookHeaders headers, PageBuildEvent pageBuildEvent)
        {
        }

        [PublicAPI]
        protected virtual void ProcessPingWebhook(WebhookHeaders headers, PingEvent pingEvent)
        {
        }

        private void ProcessProjectWebhook(WebhookHeaders headers, string body)
        {
            var projectEvent = JsonSerializer.Deserialize<ProjectEvent>(body)!;
            switch (projectEvent.Action)
            {
                case ProjectActionValue.Closed:
                    this.ProcessProjectWebhook(headers, projectEvent, ProjectAction.Closed);
                    break;
                case ProjectActionValue.Created:
                    this.ProcessProjectWebhook(headers, projectEvent, ProjectAction.Created);
                    break;
                case ProjectActionValue.Deleted:
                    this.ProcessProjectWebhook(headers, projectEvent, ProjectAction.Deleted);
                    break;
                case ProjectActionValue.Edited:
                    this.ProcessProjectWebhook(headers, projectEvent, ProjectAction.Edited);
                    break;
                case ProjectActionValue.Reopened:
                    this.ProcessProjectWebhook(headers, projectEvent, ProjectAction.Reopened);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessProjectWebhook(WebhookHeaders headers, ProjectEvent projectEvent, ProjectAction action)
        {
        }

        private void ProcessProjectCardWebhook(WebhookHeaders headers, string body)
        {
            var projectCardEvent = JsonSerializer.Deserialize<ProjectCardEvent>(body)!;
            switch (projectCardEvent.Action)
            {
                case ProjectCardActionValue.Converted:
                    this.ProcessProjectCardWebhook(headers, projectCardEvent, ProjectCardAction.Converted);
                    break;
                case ProjectCardActionValue.Created:
                    this.ProcessProjectCardWebhook(headers, projectCardEvent, ProjectCardAction.Created);
                    break;
                case ProjectCardActionValue.Deleted:
                    this.ProcessProjectCardWebhook(headers, projectCardEvent, ProjectCardAction.Deleted);
                    break;
                case ProjectCardActionValue.Edited:
                    this.ProcessProjectCardWebhook(headers, projectCardEvent, ProjectCardAction.Edited);
                    break;
                case ProjectCardActionValue.Moved:
                    this.ProcessProjectCardWebhook(headers, projectCardEvent, ProjectCardAction.Moved);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessProjectCardWebhook(WebhookHeaders headers, ProjectCardEvent projectCardEvent, ProjectCardAction action)
        {
        }

        private void ProcessProjectColumnWebhook(WebhookHeaders headers, string body)
        {
            var projectColumnEvent = JsonSerializer.Deserialize<ProjectColumnEvent>(body)!;
            switch (projectColumnEvent.Action)
            {
                case ProjectColumnActionValue.Created:
                    this.ProcessProjectColumnWebhook(headers, projectColumnEvent, ProjectColumnAction.Created);
                    break;
                case ProjectColumnActionValue.Deleted:
                    this.ProcessProjectColumnWebhook(headers, projectColumnEvent, ProjectColumnAction.Deleted);
                    break;
                case ProjectColumnActionValue.Edited:
                    this.ProcessProjectColumnWebhook(headers, projectColumnEvent, ProjectColumnAction.Edited);
                    break;
                case ProjectColumnActionValue.Moved:
                    this.ProcessProjectColumnWebhook(headers, projectColumnEvent, ProjectColumnAction.Moved);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessProjectColumnWebhook(WebhookHeaders headers, ProjectColumnEvent projectColumnEvent, ProjectColumnAction action)
        {
        }

        [PublicAPI]
        protected virtual void ProcessPublicWebhook(WebhookHeaders headers, PublicEvent publicEvent)
        {
        }

        private void ProcessPullRequestWebhook(WebhookHeaders headers, string body)
        {
            var pullRequestEvent = JsonSerializer.Deserialize<PullRequestEvent>(body)!;
            switch (pullRequestEvent.Action)
            {
                case PullRequestActionValue.Assigned:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Assigned);
                    break;
                case PullRequestActionValue.AutoMergeDisabled:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.AutoMergeDisabled);
                    break;
                case PullRequestActionValue.AutoMergeEnabled:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.AutoMergeEnabled);
                    break;
                case PullRequestActionValue.Closed:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Closed);
                    break;
                case PullRequestActionValue.ConvertedToDraft:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.ConvertedToDraft);
                    break;
                case PullRequestActionValue.Edited:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Edited);
                    break;
                case PullRequestActionValue.Labeled:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Labeled);
                    break;
                case PullRequestActionValue.Locked:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Locked);
                    break;
                case PullRequestActionValue.Opened:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Opened);
                    break;
                case PullRequestActionValue.ReadyForReview:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.ReadyForReview);
                    break;
                case PullRequestActionValue.Reopened:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Reopened);
                    break;
                case PullRequestActionValue.ReviewRequestRemoved:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.ReviewRequestRemoved);
                    break;
                case PullRequestActionValue.ReviewRequested:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.ReviewRequested);
                    break;
                case PullRequestActionValue.Synchronize:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Synchronize);
                    break;
                case PullRequestActionValue.Unassigned:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Unassigned);
                    break;
                case PullRequestActionValue.Unlabeled:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Unlabeled);
                    break;
                case PullRequestActionValue.Unlocked:
                    this.ProcessPullRequestWebhook(headers, pullRequestEvent, PullRequestAction.Unlocked);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessPullRequestWebhook(WebhookHeaders headers, PullRequestEvent pullRequestEvent, PullRequestAction action)
        {
        }

        private void ProcessPullRequestReviewWebhook(WebhookHeaders headers, string body)
        {
            var pullRequestReviewEvent = JsonSerializer.Deserialize<PullRequestReviewEvent>(body)!;
            switch (pullRequestReviewEvent.Action)
            {
                case PullRequestReviewActionValue.Dismissed:
                    this.ProcessPullRequestReviewWebhook(headers, pullRequestReviewEvent, PullRequestReviewAction.Dismissed);
                    break;
                case PullRequestReviewActionValue.Edited:
                    this.ProcessPullRequestReviewWebhook(headers, pullRequestReviewEvent, PullRequestReviewAction.Edited);
                    break;
                case PullRequestReviewActionValue.Submitted:
                    this.ProcessPullRequestReviewWebhook(headers, pullRequestReviewEvent, PullRequestReviewAction.Submitted);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessPullRequestReviewWebhook(WebhookHeaders headers, PullRequestReviewEvent pullRequestReviewEvent, PullRequestReviewAction action)
        {
        }

        private void ProcessPullRequestReviewCommentWebhook(WebhookHeaders headers, string body)
        {
            var pullRequestReviewCommentEvent = JsonSerializer.Deserialize<PullRequestReviewCommentEvent>(body)!;
            switch (pullRequestReviewCommentEvent.Action)
            {
                case PullRequestReviewCommentActionValue.Created:
                    this.ProcessPullRequestReviewCommentWebhook(headers, pullRequestReviewCommentEvent, PullRequestReviewCommentAction.Created);
                    break;
                case PullRequestReviewCommentActionValue.Deleted:
                    this.ProcessPullRequestReviewCommentWebhook(headers, pullRequestReviewCommentEvent, PullRequestReviewCommentAction.Deleted);
                    break;
                case PullRequestReviewCommentActionValue.Edited:
                    this.ProcessPullRequestReviewCommentWebhook(headers, pullRequestReviewCommentEvent, PullRequestReviewCommentAction.Edited);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessPullRequestReviewCommentWebhook(WebhookHeaders headers, PullRequestReviewCommentEvent pullRequestReviewCommentEvent, PullRequestReviewCommentAction action)
        {
        }

        [PublicAPI]
        protected virtual void ProcessPushWebhook(WebhookHeaders headers, PushEvent pushEvent)
        {
        }

        private void ProcessReleaseWebhook(WebhookHeaders headers, string body)
        {
            var releaseEvent = JsonSerializer.Deserialize<ReleaseEvent>(body)!;
            switch (releaseEvent.Action)
            {
                case ReleaseActionValue.Created:
                    this.ProcessReleaseWebhook(headers, releaseEvent, ReleaseAction.Created);
                    break;
                case ReleaseActionValue.Deleted:
                    this.ProcessReleaseWebhook(headers, releaseEvent, ReleaseAction.Deleted);
                    break;
                case ReleaseActionValue.Edited:
                    this.ProcessReleaseWebhook(headers, releaseEvent, ReleaseAction.Edited);
                    break;
                case ReleaseActionValue.Prereleased:
                    this.ProcessReleaseWebhook(headers, releaseEvent, ReleaseAction.Prereleased);
                    break;
                case ReleaseActionValue.Published:
                    this.ProcessReleaseWebhook(headers, releaseEvent, ReleaseAction.Published);
                    break;
                case ReleaseActionValue.Released:
                    this.ProcessReleaseWebhook(headers, releaseEvent, ReleaseAction.Released);
                    break;
                case ReleaseActionValue.Unpublished:
                    this.ProcessReleaseWebhook(headers, releaseEvent, ReleaseAction.Unpublished);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessReleaseWebhook(WebhookHeaders headers, ReleaseEvent releaseEvent, ReleaseAction action)
        {
        }

        private void ProcessRepositoryWebhook(WebhookHeaders headers, string body)
        {
            var repositoryEvent = JsonSerializer.Deserialize<RepositoryEvent>(body)!;
            switch (repositoryEvent.Action)
            {
                case RepositoryActionValue.Archived:
                    this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Archived);
                    break;
                case RepositoryActionValue.Created:
                    this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Created);
                    break;
                case RepositoryActionValue.Deleted:
                    this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Deleted);
                    break;
                case RepositoryActionValue.Edited:
                    this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Edited);
                    break;
                case RepositoryActionValue.Privatized:
                    this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Privatized);
                    break;
                case RepositoryActionValue.Publicized:
                    this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Publicized);
                    break;
                case RepositoryActionValue.Renamed:
                    this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Renamed);
                    break;
                case RepositoryActionValue.Transferred:
                    this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Transferred);
                    break;
                case RepositoryActionValue.Unarchived:
                    this.ProcessRepositoryWebhook(headers, repositoryEvent, RepositoryAction.Unarchived);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessRepositoryWebhook(WebhookHeaders headers, RepositoryEvent repositoryEvent, RepositoryAction action)
        {
        }

        private void ProcessRepositoryDispatchWebhook(WebhookHeaders headers, string body)
        {
            var repositoryDispatchEvent = JsonSerializer.Deserialize<RepositoryDispatchEvent>(body)!;
            switch (repositoryDispatchEvent.Action)
            {
                case RepositoryDispatchActionValue.OnDemandTest:
                    this.ProcessRepositoryDispatchWebhook(headers, repositoryDispatchEvent, RepositoryDispatchAction.OnDemandTest);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessRepositoryDispatchWebhook(WebhookHeaders headers, RepositoryDispatchEvent repositoryDispatchEvent, RepositoryDispatchAction action)
        {
        }

        [PublicAPI]
        protected virtual void ProcessRepositoryImportWebhook(WebhookHeaders headers, RepositoryImportEvent repositoryImportEvent)
        {
        }

        private void ProcessRepositoryVulnerabilityAlertWebhook(WebhookHeaders headers, string body)
        {
            var repositoryVulnerabilityAlertEvent = JsonSerializer.Deserialize<RepositoryVulnerabilityAlertEvent>(body)!;
            switch (repositoryVulnerabilityAlertEvent.Action)
            {
                case RepositoryVulnerabilityAlertActionValue.Create:
                    this.ProcessRepositoryVulnerabilityAlertWebhook(headers, repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction.Create);
                    break;
                case RepositoryVulnerabilityAlertActionValue.Dismiss:
                    this.ProcessRepositoryVulnerabilityAlertWebhook(headers, repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction.Dismiss);
                    break;
                case RepositoryVulnerabilityAlertActionValue.Resolve:
                    this.ProcessRepositoryVulnerabilityAlertWebhook(headers, repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction.Resolve);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessRepositoryVulnerabilityAlertWebhook(WebhookHeaders headers, RepositoryVulnerabilityAlertEvent repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction action)
        {
        }

        private void ProcessSecretScanningAlertWebhook(WebhookHeaders headers, string body)
        {
            var secretScanningAlertEvent = JsonSerializer.Deserialize<SecretScanningAlertEvent>(body)!;
            switch (secretScanningAlertEvent.Action)
            {
                case SecretScanningAlertActionValue.Created:
                    this.ProcessSecretScanningAlertWebhook(headers, secretScanningAlertEvent, SecretScanningAlertAction.Created);
                    break;
                case SecretScanningAlertActionValue.Reopened:
                    this.ProcessSecretScanningAlertWebhook(headers, secretScanningAlertEvent, SecretScanningAlertAction.Reopened);
                    break;
                case SecretScanningAlertActionValue.Resolved:
                    this.ProcessSecretScanningAlertWebhook(headers, secretScanningAlertEvent, SecretScanningAlertAction.Resolved);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessSecretScanningAlertWebhook(WebhookHeaders headers, SecretScanningAlertEvent secretScanningAlertEvent, SecretScanningAlertAction action)
        {
        }

        private void ProcessSecurityAdvisoryWebhook(WebhookHeaders headers, string body)
        {
            var securityAdvisoryEvent = JsonSerializer.Deserialize<SecurityAdvisoryEvent>(body)!;
            switch (securityAdvisoryEvent.Action)
            {
                case SecurityAdvisoryActionValue.Performed:
                    this.ProcessSecurityAdvisoryWebhook(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Performed);
                    break;
                case SecurityAdvisoryActionValue.Published:
                    this.ProcessSecurityAdvisoryWebhook(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Published);
                    break;
                case SecurityAdvisoryActionValue.Updated:
                    this.ProcessSecurityAdvisoryWebhook(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Updated);
                    break;
                case SecurityAdvisoryActionValue.Withdrawn:
                    this.ProcessSecurityAdvisoryWebhook(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Withdrawn);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessSecurityAdvisoryWebhook(WebhookHeaders headers, SecurityAdvisoryEvent securityAdvisoryEvent, SecurityAdvisoryAction action)
        {
        }

        private void ProcessSponsorshipWebhook(WebhookHeaders headers, string body)
        {
            var sponsorshipEvent = JsonSerializer.Deserialize<SponsorshipEvent>(body)!;
            switch (sponsorshipEvent.Action)
            {
                case SponsorshipActionValue.Cancelled:
                    this.ProcessSponsorshipWebhook(headers, sponsorshipEvent, SponsorshipAction.Cancelled);
                    break;
                case SponsorshipActionValue.Created:
                    this.ProcessSponsorshipWebhook(headers, sponsorshipEvent, SponsorshipAction.Created);
                    break;
                case SponsorshipActionValue.Edited:
                    this.ProcessSponsorshipWebhook(headers, sponsorshipEvent, SponsorshipAction.Edited);
                    break;
                case SponsorshipActionValue.PendingCancellation:
                    this.ProcessSponsorshipWebhook(headers, sponsorshipEvent, SponsorshipAction.PendingCancellation);
                    break;
                case SponsorshipActionValue.PendingTierChange:
                    this.ProcessSponsorshipWebhook(headers, sponsorshipEvent, SponsorshipAction.PendingTierChange);
                    break;
                case SponsorshipActionValue.TierChanged:
                    this.ProcessSponsorshipWebhook(headers, sponsorshipEvent, SponsorshipAction.TierChanged);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessSponsorshipWebhook(WebhookHeaders headers, SponsorshipEvent sponsorshipEvent, SponsorshipAction action)
        {
        }

        private void ProcessStarWebhook(WebhookHeaders headers, string body)
        {
            var starEvent = JsonSerializer.Deserialize<StarEvent>(body)!;
            switch (starEvent.Action)
            {
                case StarActionValue.Created:
                    this.ProcessStarWebhook(headers, starEvent, StarAction.Created);
                    break;
                case StarActionValue.Deleted:
                    this.ProcessStarWebhook(headers, starEvent, StarAction.Deleted);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessStarWebhook(WebhookHeaders headers, StarEvent starEvent, StarAction action)
        {
        }

        [PublicAPI]
        protected virtual void ProcessStatusWebhook(WebhookHeaders headers, StatusEvent statusEvent)
        {
        }

        private void ProcessTeamWebhook(WebhookHeaders headers, string body)
        {
            var teamEvent = JsonSerializer.Deserialize<TeamEvent>(body)!;
            switch (teamEvent.Action)
            {
                case TeamActionValue.AddedToRepository:
                    this.ProcessTeamWebhook(headers, teamEvent, TeamAction.AddedToRepository);
                    break;
                case TeamActionValue.Created:
                    this.ProcessTeamWebhook(headers, teamEvent, TeamAction.Created);
                    break;
                case TeamActionValue.Deleted:
                    this.ProcessTeamWebhook(headers, teamEvent, TeamAction.Deleted);
                    break;
                case TeamActionValue.Edited:
                    this.ProcessTeamWebhook(headers, teamEvent, TeamAction.Edited);
                    break;
                case TeamActionValue.RemovedFromRepository:
                    this.ProcessTeamWebhook(headers, teamEvent, TeamAction.RemovedFromRepository);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessTeamWebhook(WebhookHeaders headers, TeamEvent teamEvent, TeamAction action)
        {
        }

        [PublicAPI]
        protected virtual void ProcessTeamAddWebhook(WebhookHeaders headers, TeamAddEvent teamAddEvent)
        {
        }

        private void ProcessWatchWebhook(WebhookHeaders headers, string body)
        {
            var watchEvent = JsonSerializer.Deserialize<WatchEvent>(body)!;
            switch (watchEvent.Action)
            {
                case WatchActionValue.Started:
                    this.ProcessWatchWebhook(headers, watchEvent, WatchAction.Started);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessWatchWebhook(WebhookHeaders headers, WatchEvent watchEvent, WatchAction action)
        {
        }

        [PublicAPI]
        protected virtual void ProcessWorkflowDispatchWebhook(WebhookHeaders headers, WorkflowDispatchEvent workflowDispatchEvent)
        {
        }

        private void ProcessWorkflowJobWebhook(WebhookHeaders headers, string body)
        {
            var workflowJobEvent = JsonSerializer.Deserialize<WorkflowJobEvent>(body)!;
            switch (workflowJobEvent.Action)
            {
                case WorkflowJobActionValue.Completed:
                    this.ProcessWorkflowJobWebhook(headers, workflowJobEvent, WorkflowJobAction.Completed);
                    break;
                case WorkflowJobActionValue.Started:
                    this.ProcessWorkflowJobWebhook(headers, workflowJobEvent, WorkflowJobAction.Started);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessWorkflowJobWebhook(WebhookHeaders headers, WorkflowJobEvent workflowJobEvent, WorkflowJobAction action)
        {
        }

        private void ProcessWorkflowRunWebhook(WebhookHeaders headers, string body)
        {
            var workflowRunEvent = JsonSerializer.Deserialize<WorkflowRunEvent>(body)!;
            switch (workflowRunEvent.Action)
            {
                case WorkflowRunActionValue.Completed:
                    this.ProcessWorkflowRunWebhook(headers, workflowRunEvent, WorkflowRunAction.Completed);
                    break;
                case WorkflowRunActionValue.Requested:
                    this.ProcessWorkflowRunWebhook(headers, workflowRunEvent, WorkflowRunAction.Requested);
                    break;
            }
        }

        [PublicAPI]
        protected virtual void ProcessWorkflowRunWebhook(WebhookHeaders headers, WorkflowRunEvent workflowRunEvent, WorkflowRunAction action)
        {
        }

    }
}
