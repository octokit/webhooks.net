namespace JamieMagee.Octokit.Webhooks
{
    using System;
    using System.Collections.Generic;
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
    using JamieMagee.Octokit.Webhooks.Events.TeamAdd;
    using JamieMagee.Octokit.Webhooks.Events.Watch;
    using JamieMagee.Octokit.Webhooks.Events.WorkflowJob;
    using JamieMagee.Octokit.Webhooks.Events.WorkflowRun;
    using Microsoft.Extensions.Primitives;

    public abstract class WebhookProcessor
    {
        public virtual void Process(IDictionary<string, StringValues> headers, string body)
        {
            if (headers is null)
            {
                throw new ArgumentNullException(nameof(headers));
            }

            if (body is null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            var message = WebhookPayload.Parse(headers, body);
            this.ProcessMessage(message);
        }

        public virtual void ProcessMessage(WebhookPayload payload)
        {
            if (payload is null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            switch (payload.Headers.Event)
            {
                case WebhookEventType.BranchProtectionRule:
                    this.ProcessBranchProtectionRuleMessage(payload, (BranchProtectionRuleEvent)payload.Body!);
                    break;
                case WebhookEventType.CheckRun:
                    this.ProcessCheckRunMessage(payload, (CheckRunEvent)payload.Body!);
                    break;
                case WebhookEventType.CheckSuite:
                    this.ProcessCheckSuiteMessage(payload, (CheckSuiteEvent)payload.Body!);
                    break;
                case WebhookEventType.CodeScanningAlert:
                    this.ProcessCodeScanningAlertMessage(payload, (CodeScanningAlertEvent)payload.Body!);
                    break;
                case WebhookEventType.CommitComment:
                    this.ProcessCommitCommentMessage(payload, (CommitCommentEvent)payload.Body!);
                    break;
                case WebhookEventType.ContentReference:
                    this.ProcessContentReferenceMessage(payload, (ContentReferenceEvent)payload.Body!);
                    break;
                case WebhookEventType.Create:
                    this.ProcessCreateMessage(payload, (CreateEvent)payload.Body!);
                    break;
                case WebhookEventType.Delete:
                    this.ProcessDeleteMessage(payload, (DeleteEvent)payload.Body!);
                    break;
                case WebhookEventType.DeployKey:
                    this.ProcessDeployKeyMessage(payload, (DeployKeyEvent)payload.Body!);
                    break;
                case WebhookEventType.Deployment:
                    this.ProcessDeploymentMessage(payload, (DeploymentEvent)payload.Body!);
                    break;
                case WebhookEventType.DeploymentStatus:
                    this.ProcessDeploymentStatusMessage(payload, (DeploymentStatusEvent)payload.Body!);
                    break;
                case WebhookEventType.Discussion:
                    this.ProcessDiscussionMessage(payload, (DiscussionEvent)payload.Body!);
                    break;
                case WebhookEventType.DiscussionComment:
                    this.ProcessDiscussionCommentMessage(payload, (DiscussionCommentEvent)payload.Body!);
                    break;
                case WebhookEventType.Fork:
                    this.ProcessForkMessage(payload, (ForkEvent)payload.Body!);
                    break;
                case WebhookEventType.GithubAppAuthorization:
                    this.ProcessGithubAppAuthorizationMessage(payload, (GithubAppAuthorizationEvent)payload.Body!);
                    break;
                case WebhookEventType.Gollum:
                    this.ProcessGollumMessage(payload, (GollumEvent)payload.Body!);
                    break;
                case WebhookEventType.Installation:
                    this.ProcessInstallationMessage(payload, (InstallationEvent)payload.Body!);
                    break;
                case WebhookEventType.InstallationRepositories:
                    this.ProcessInstallationRepositoriesMessage(payload, (InstallationRepositoriesEvent)payload.Body!);
                    break;
                case WebhookEventType.IssueComment:
                    this.ProcessIssueCommentMessage(payload, (IssueCommentEvent)payload.Body!);
                    break;
                case WebhookEventType.Issues:
                    this.ProcessIssuesMessage(payload, (IssuesEvent)payload.Body!);
                    break;
                case WebhookEventType.Label:
                    this.ProcessLabelMessage(payload, (LabelEvent)payload.Body!);
                    break;
                case WebhookEventType.MarketplacePurchase:
                    this.ProcessMarketplacePurchaseMessage(payload, (MarketplacePurchaseEvent)payload.Body!);
                    break;
                case WebhookEventType.Member:
                    this.ProcessMemberMessage(payload, (MemberEvent)payload.Body!);
                    break;
                case WebhookEventType.Membership:
                    this.ProcessMembershipMessage(payload, (MembershipEvent)payload.Body!);
                    break;
                case WebhookEventType.Meta:
                    this.ProcessMetaMessage(payload, (MetaEvent)payload.Body!);
                    break;
                case WebhookEventType.Milestone:
                    this.ProcessMilestoneMessage(payload, (MilestoneEvent)payload.Body!);
                    break;
                case WebhookEventType.OrgBlock:
                    this.ProcessOrgBlockMessage(payload, (OrgBlockEvent)payload.Body!);
                    break;
                case WebhookEventType.Organization:
                    this.ProcessOrganizationMessage(payload, (OrganizationEvent)payload.Body!);
                    break;
                case WebhookEventType.Package:
                    this.ProcessPackageMessage(payload, (PackageEvent)payload.Body!);
                    break;
                case WebhookEventType.PageBuild:
                    this.ProcessPageBuildMessage(payload, (PageBuildEvent)payload.Body!);
                    break;
                case WebhookEventType.Ping:
                    this.ProcessPingMessage(payload, (PingEvent)payload.Body!);
                    break;
                case WebhookEventType.Project:
                    this.ProcessProjectMessage(payload, (ProjectEvent)payload.Body!);
                    break;
                case WebhookEventType.ProjectCard:
                    this.ProcessProjectCardMessage(payload, (ProjectCardEvent)payload.Body!);
                    break;
                case WebhookEventType.ProjectColumn:
                    this.ProcessProjectColumnMessage(payload, (ProjectColumnEvent)payload.Body!);
                    break;
                case WebhookEventType.Public:
                    this.ProcessPublicMessage(payload, (PublicEvent)payload.Body!);
                    break;
                case WebhookEventType.PullRequest:
                    this.ProcessPullRequestMessage(payload, (PullRequestEvent)payload.Body!);
                    break;
                case WebhookEventType.PullRequestReview:
                    this.ProcessPullRequestReviewMessage(payload, (PullRequestReviewEvent)payload.Body!);
                    break;
                case WebhookEventType.PullRequestReviewComment:
                    this.ProcessPullRequestReviewCommentMessage(payload, (PullRequestReviewCommentEvent)payload.Body!);
                    break;
                case WebhookEventType.Push:
                    this.ProcessPushMessage(payload, (PushEvent)payload.Body!);
                    break;
                case WebhookEventType.Release:
                    this.ProcessReleaseMessage(payload, (ReleaseEvent)payload.Body!);
                    break;
                case WebhookEventType.Repository:
                    this.ProcessRepositoryMessage(payload, (RepositoryEvent)payload.Body!);
                    break;
                case WebhookEventType.RepositoryDispatch:
                    this.ProcessRepositoryDispatchMessage(payload, (RepositoryDispatchEvent)payload.Body!);
                    break;
                case WebhookEventType.RepositoryImport:
                    this.ProcessRepositoryImportMessage(payload, (RepositoryImportEvent)payload.Body!);
                    break;
                case WebhookEventType.RepositoryVulnerabilityAlert:
                    this.ProcessRepositoryVulnerabilityAlertMessage(payload, (RepositoryVulnerabilityAlertEvent)payload.Body!);
                    break;
                case WebhookEventType.SecretScanningAlert:
                    this.ProcessSecretScanningAlertMessage(payload, (SecretScanningAlertEvent)payload.Body!);
                    break;
                case WebhookEventType.SecurityAdvisory:
                    this.ProcessSecurityAdvisoryMessage(payload, (SecurityAdvisoryEvent)payload.Body!);
                    break;
                case WebhookEventType.Sponsorship:
                    this.ProcessSponsorshipMessage(payload, (SponsorshipEvent)payload.Body!);
                    break;
                case WebhookEventType.Star:
                    this.ProcessStarMessage(payload, (StarEvent)payload.Body!);
                    break;
                case WebhookEventType.Status:
                    this.ProcessStatusMessage(payload, (StatusEvent)payload.Body!);
                    break;
                case WebhookEventType.Team:
                    this.ProcessTeamMessage(payload, (TeamEvent)payload.Body!);
                    break;
                case WebhookEventType.TeamAdd:
                    this.ProcessTeamAddMessage(payload, (TeamAddEvent)payload.Body!);
                    break;
                case WebhookEventType.Watch:
                    this.ProcessWatchMessage(payload, (WatchEvent)payload.Body!);
                    break;
                case WebhookEventType.WorkflowDispatch:
                    this.ProcessWorkflowDispatchMessage(payload, (WorkflowDispatchEvent)payload.Body!);
                    break;
                case WebhookEventType.WorkflowJob:
                    this.ProcessWorkflowJobMessage(payload, (WorkflowJobEvent)payload.Body!);
                    break;
                case WebhookEventType.WorkflowRun:
                    this.ProcessWorkflowRunMessage(payload, (WorkflowRunEvent)payload.Body!);
                    break;
            }
        }

        private void ProcessBranchProtectionRuleMessage(WebhookPayload payload, BranchProtectionRuleEvent branchProtectionRuleEvent)
        {
            switch (branchProtectionRuleEvent.Action)
            {
                case BranchProtectionRuleActionValue.Created:
                    this.ProcessBranchProtectionRuleMessage(payload, branchProtectionRuleEvent, BranchProtectionRuleAction.Created);
                    break;
                case BranchProtectionRuleActionValue.Deleted:
                    this.ProcessBranchProtectionRuleMessage(payload, branchProtectionRuleEvent, BranchProtectionRuleAction.Deleted);
                    break;
                case BranchProtectionRuleActionValue.Edited:
                    this.ProcessBranchProtectionRuleMessage(payload, branchProtectionRuleEvent, BranchProtectionRuleAction.Edited);
                    break;
            }
        }

        protected virtual void ProcessBranchProtectionRuleMessage(WebhookPayload payload, BranchProtectionRuleEvent branchProtectionRuleEvent, BranchProtectionRuleAction action)
        {
        }

        private void ProcessCheckRunMessage(WebhookPayload payload, CheckRunEvent checkRunEvent)
        {
            switch (checkRunEvent.Action)
            {
                case CheckRunActionValue.Completed:
                    this.ProcessCheckRunMessage(payload, checkRunEvent, CheckRunAction.Completed);
                    break;
                case CheckRunActionValue.Created:
                    this.ProcessCheckRunMessage(payload, checkRunEvent, CheckRunAction.Created);
                    break;
                case CheckRunActionValue.RequestedAction:
                    this.ProcessCheckRunMessage(payload, checkRunEvent, CheckRunAction.RequestedAction);
                    break;
                case CheckRunActionValue.Rerequested:
                    this.ProcessCheckRunMessage(payload, checkRunEvent, CheckRunAction.Rerequested);
                    break;
            }
        }

        protected virtual void ProcessCheckRunMessage(WebhookPayload payload, CheckRunEvent checkRunEvent, CheckRunAction action)
        {
        }

        private void ProcessCheckSuiteMessage(WebhookPayload payload, CheckSuiteEvent checkSuiteEvent)
        {
            switch (checkSuiteEvent.Action)
            {
                case CheckSuiteActionValue.Completed:
                    this.ProcessCheckSuiteMessage(payload, checkSuiteEvent, CheckSuiteAction.Completed);
                    break;
                case CheckSuiteActionValue.Requested:
                    this.ProcessCheckSuiteMessage(payload, checkSuiteEvent, CheckSuiteAction.Requested);
                    break;
                case CheckSuiteActionValue.Rerequested:
                    this.ProcessCheckSuiteMessage(payload, checkSuiteEvent, CheckSuiteAction.Rerequested);
                    break;
            }
        }

        protected virtual void ProcessCheckSuiteMessage(WebhookPayload payload, CheckSuiteEvent checkSuiteEvent, CheckSuiteAction action)
        {
        }

        private void ProcessCodeScanningAlertMessage(WebhookPayload payload, CodeScanningAlertEvent codeScanningAlertEvent)
        {
            switch (codeScanningAlertEvent.Action)
            {
                case CodeScanningAlertActionValue.AppearedInBranch:
                    this.ProcessCodeScanningAlertMessage(payload, codeScanningAlertEvent, CodeScanningAlertAction.AppearedInBranch);
                    break;
                case CodeScanningAlertActionValue.ClosedByUser:
                    this.ProcessCodeScanningAlertMessage(payload, codeScanningAlertEvent, CodeScanningAlertAction.ClosedByUser);
                    break;
                case CodeScanningAlertActionValue.Created:
                    this.ProcessCodeScanningAlertMessage(payload, codeScanningAlertEvent, CodeScanningAlertAction.Created);
                    break;
                case CodeScanningAlertActionValue.Fixed:
                    this.ProcessCodeScanningAlertMessage(payload, codeScanningAlertEvent, CodeScanningAlertAction.Fixed);
                    break;
                case CodeScanningAlertActionValue.Reopened:
                    this.ProcessCodeScanningAlertMessage(payload, codeScanningAlertEvent, CodeScanningAlertAction.Reopened);
                    break;
                case CodeScanningAlertActionValue.ReopenedByUser:
                    this.ProcessCodeScanningAlertMessage(payload, codeScanningAlertEvent, CodeScanningAlertAction.ReopenedByUser);
                    break;
            }
        }

        protected virtual void ProcessCodeScanningAlertMessage(WebhookPayload payload, CodeScanningAlertEvent codeScanningAlertEvent, CodeScanningAlertAction action)
        {
        }

        private void ProcessCommitCommentMessage(WebhookPayload payload, CommitCommentEvent commitCommentEvent)
        {
            switch (commitCommentEvent.Action)
            {
                case CommitCommentActionValue.Created:
                    this.ProcessCommitCommentMessage(payload, commitCommentEvent, CommitCommentAction.Created);
                    break;
            }
        }

        protected virtual void ProcessCommitCommentMessage(WebhookPayload payload, CommitCommentEvent commitCommentEvent, CommitCommentAction action)
        {
        }

        private void ProcessContentReferenceMessage(WebhookPayload payload, ContentReferenceEvent contentReferenceEvent)
        {
            switch (contentReferenceEvent.Action)
            {
                case ContentReferenceActionValue.Created:
                    this.ProcessContentReferenceMessage(payload, contentReferenceEvent, ContentReferenceAction.Created);
                    break;
            }
        }

        protected virtual void ProcessContentReferenceMessage(WebhookPayload payload, ContentReferenceEvent contentReferenceEvent, ContentReferenceAction action)
        {
        }

        protected virtual void ProcessCreateMessage(WebhookPayload payload, CreateEvent createEvent)
        {
        }

        protected virtual void ProcessDeleteMessage(WebhookPayload payload, DeleteEvent deleteEvent)
        {
        }

        private void ProcessDeployKeyMessage(WebhookPayload payload, DeployKeyEvent deployKeyEvent)
        {
            switch (deployKeyEvent.Action)
            {
                case DeployKeyActionValue.Created:
                    this.ProcessDeployKeyMessage(payload, deployKeyEvent, DeployKeyAction.Created);
                    break;
                case DeployKeyActionValue.Deleted:
                    this.ProcessDeployKeyMessage(payload, deployKeyEvent, DeployKeyAction.Deleted);
                    break;
            }
        }

        protected virtual void ProcessDeployKeyMessage(WebhookPayload payload, DeployKeyEvent deployKeyEvent, DeployKeyAction action)
        {
        }

        private void ProcessDeploymentMessage(WebhookPayload payload, DeploymentEvent deploymentEvent)
        {
            switch (deploymentEvent.Action)
            {
                case DeploymentActionValue.Created:
                    this.ProcessDeploymentMessage(payload, deploymentEvent, DeploymentAction.Created);
                    break;
            }
        }

        protected virtual void ProcessDeploymentMessage(WebhookPayload payload, DeploymentEvent deploymentEvent, DeploymentAction action)
        {
        }

        private void ProcessDeploymentStatusMessage(WebhookPayload payload, DeploymentStatusEvent deploymentStatusEvent)
        {
            switch (deploymentStatusEvent.Action)
            {
                case DeploymentStatusActionValue.Created:
                    this.ProcessDeploymentStatusMessage(payload, deploymentStatusEvent, DeploymentStatusAction.Created);
                    break;
            }
        }

        protected virtual void ProcessDeploymentStatusMessage(WebhookPayload payload, DeploymentStatusEvent deploymentStatusEvent, DeploymentStatusAction action)
        {
        }

        private void ProcessDiscussionMessage(WebhookPayload payload, DiscussionEvent discussionEvent)
        {
            switch (discussionEvent.Action)
            {
                case DiscussionActionValue.Answered:
                    this.ProcessDiscussionMessage(payload, discussionEvent, DiscussionAction.Answered);
                    break;
                case DiscussionActionValue.CategoryChanged:
                    this.ProcessDiscussionMessage(payload, discussionEvent, DiscussionAction.CategoryChanged);
                    break;
                case DiscussionActionValue.Created:
                    this.ProcessDiscussionMessage(payload, discussionEvent, DiscussionAction.Created);
                    break;
                case DiscussionActionValue.Deleted:
                    this.ProcessDiscussionMessage(payload, discussionEvent, DiscussionAction.Deleted);
                    break;
                case DiscussionActionValue.Edited:
                    this.ProcessDiscussionMessage(payload, discussionEvent, DiscussionAction.Edited);
                    break;
                case DiscussionActionValue.Labeled:
                    this.ProcessDiscussionMessage(payload, discussionEvent, DiscussionAction.Labeled);
                    break;
                case DiscussionActionValue.Locked:
                    this.ProcessDiscussionMessage(payload, discussionEvent, DiscussionAction.Locked);
                    break;
                case DiscussionActionValue.Pinned:
                    this.ProcessDiscussionMessage(payload, discussionEvent, DiscussionAction.Pinned);
                    break;
                case DiscussionActionValue.Transferred:
                    this.ProcessDiscussionMessage(payload, discussionEvent, DiscussionAction.Transferred);
                    break;
                case DiscussionActionValue.Unanswered:
                    this.ProcessDiscussionMessage(payload, discussionEvent, DiscussionAction.Unanswered);
                    break;
                case DiscussionActionValue.Unlabeled:
                    this.ProcessDiscussionMessage(payload, discussionEvent, DiscussionAction.Unlabeled);
                    break;
                case DiscussionActionValue.Unlocked:
                    this.ProcessDiscussionMessage(payload, discussionEvent, DiscussionAction.Unlocked);
                    break;
                case DiscussionActionValue.Unpinned:
                    this.ProcessDiscussionMessage(payload, discussionEvent, DiscussionAction.Unpinned);
                    break;
            }
        }

        protected virtual void ProcessDiscussionMessage(WebhookPayload payload, DiscussionEvent discussionEvent, DiscussionAction action)
        {
        }

        private void ProcessDiscussionCommentMessage(WebhookPayload payload, DiscussionCommentEvent discussionCommentEvent)
        {
            switch (discussionCommentEvent.Action)
            {
                case DiscussionCommentActionValue.Created:
                    this.ProcessDiscussionCommentMessage(payload, discussionCommentEvent, DiscussionCommentAction.Created);
                    break;
                case DiscussionCommentActionValue.Deleted:
                    this.ProcessDiscussionCommentMessage(payload, discussionCommentEvent, DiscussionCommentAction.Deleted);
                    break;
                case DiscussionCommentActionValue.Edited:
                    this.ProcessDiscussionCommentMessage(payload, discussionCommentEvent, DiscussionCommentAction.Edited);
                    break;
            }
        }

        protected virtual void ProcessDiscussionCommentMessage(WebhookPayload payload, DiscussionCommentEvent discussionCommentEvent, DiscussionCommentAction action)
        {
        }

        protected virtual void ProcessForkMessage(WebhookPayload payload, ForkEvent forkEvent)
        {
        }

        private void ProcessGithubAppAuthorizationMessage(WebhookPayload payload, GithubAppAuthorizationEvent githubAppAuthorizationEvent)
        {
            switch (githubAppAuthorizationEvent.Action)
            {
                case GithubAppAuthorizationActionValue.Revoked:
                    this.ProcessGithubAppAuthorizationMessage(payload, githubAppAuthorizationEvent, GithubAppAuthorizationAction.Revoked);
                    break;
            }
        }

        protected virtual void ProcessGithubAppAuthorizationMessage(WebhookPayload payload, GithubAppAuthorizationEvent githubAppAuthorizationEvent, GithubAppAuthorizationAction action)
        {
        }

        protected virtual void ProcessGollumMessage(WebhookPayload payload, GollumEvent gollumEvent)
        {
        }

        private void ProcessInstallationMessage(WebhookPayload payload, InstallationEvent installationEvent)
        {
            switch (installationEvent.Action)
            {
                case InstallationActionValue.Created:
                    this.ProcessInstallationMessage(payload, installationEvent, InstallationAction.Created);
                    break;
                case InstallationActionValue.Deleted:
                    this.ProcessInstallationMessage(payload, installationEvent, InstallationAction.Deleted);
                    break;
                case InstallationActionValue.NewPermissionsAccepted:
                    this.ProcessInstallationMessage(payload, installationEvent, InstallationAction.NewPermissionsAccepted);
                    break;
                case InstallationActionValue.Suspend:
                    this.ProcessInstallationMessage(payload, installationEvent, InstallationAction.Suspend);
                    break;
                case InstallationActionValue.Unsuspend:
                    this.ProcessInstallationMessage(payload, installationEvent, InstallationAction.Unsuspend);
                    break;
            }
        }

        protected virtual void ProcessInstallationMessage(WebhookPayload payload, InstallationEvent installationEvent, InstallationAction action)
        {
        }

        private void ProcessInstallationRepositoriesMessage(WebhookPayload payload, InstallationRepositoriesEvent installationRepositoriesEvent)
        {
            switch (installationRepositoriesEvent.Action)
            {
                case InstallationRepositoriesActionValue.Added:
                    this.ProcessInstallationRepositoriesMessage(payload, installationRepositoriesEvent, InstallationRepositoriesAction.Added);
                    break;
                case InstallationRepositoriesActionValue.Removed:
                    this.ProcessInstallationRepositoriesMessage(payload, installationRepositoriesEvent, InstallationRepositoriesAction.Removed);
                    break;
            }
        }

        protected virtual void ProcessInstallationRepositoriesMessage(WebhookPayload payload, InstallationRepositoriesEvent installationRepositoriesEvent, InstallationRepositoriesAction action)
        {
        }

        private void ProcessIssueCommentMessage(WebhookPayload payload, IssueCommentEvent issueCommentEvent)
        {
            switch (issueCommentEvent.Action)
            {
                case IssueCommentActionValue.Created:
                    this.ProcessIssueCommentMessage(payload, issueCommentEvent, IssueCommentAction.Created);
                    break;
                case IssueCommentActionValue.Deleted:
                    this.ProcessIssueCommentMessage(payload, issueCommentEvent, IssueCommentAction.Deleted);
                    break;
                case IssueCommentActionValue.Edited:
                    this.ProcessIssueCommentMessage(payload, issueCommentEvent, IssueCommentAction.Edited);
                    break;
            }
        }

        protected virtual void ProcessIssueCommentMessage(WebhookPayload payload, IssueCommentEvent issueCommentEvent, IssueCommentAction action)
        {
        }

        private void ProcessIssuesMessage(WebhookPayload payload, IssuesEvent issuesEvent)
        {
            switch (issuesEvent.Action)
            {
                case IssuesActionValue.Assigned:
                    this.ProcessIssuesMessage(payload, issuesEvent, IssuesAction.Assigned);
                    break;
                case IssuesActionValue.Closed:
                    this.ProcessIssuesMessage(payload, issuesEvent, IssuesAction.Closed);
                    break;
                case IssuesActionValue.Deleted:
                    this.ProcessIssuesMessage(payload, issuesEvent, IssuesAction.Deleted);
                    break;
                case IssuesActionValue.Demilestoned:
                    this.ProcessIssuesMessage(payload, issuesEvent, IssuesAction.Demilestoned);
                    break;
                case IssuesActionValue.Edited:
                    this.ProcessIssuesMessage(payload, issuesEvent, IssuesAction.Edited);
                    break;
                case IssuesActionValue.Labeled:
                    this.ProcessIssuesMessage(payload, issuesEvent, IssuesAction.Labeled);
                    break;
                case IssuesActionValue.Locked:
                    this.ProcessIssuesMessage(payload, issuesEvent, IssuesAction.Locked);
                    break;
                case IssuesActionValue.Milestoned:
                    this.ProcessIssuesMessage(payload, issuesEvent, IssuesAction.Milestoned);
                    break;
                case IssuesActionValue.Opened:
                    this.ProcessIssuesMessage(payload, issuesEvent, IssuesAction.Opened);
                    break;
                case IssuesActionValue.Pinned:
                    this.ProcessIssuesMessage(payload, issuesEvent, IssuesAction.Pinned);
                    break;
                case IssuesActionValue.Reopened:
                    this.ProcessIssuesMessage(payload, issuesEvent, IssuesAction.Reopened);
                    break;
                case IssuesActionValue.Transferred:
                    this.ProcessIssuesMessage(payload, issuesEvent, IssuesAction.Transferred);
                    break;
                case IssuesActionValue.Unassigned:
                    this.ProcessIssuesMessage(payload, issuesEvent, IssuesAction.Unassigned);
                    break;
                case IssuesActionValue.Unlabeled:
                    this.ProcessIssuesMessage(payload, issuesEvent, IssuesAction.Unlabeled);
                    break;
                case IssuesActionValue.Unlocked:
                    this.ProcessIssuesMessage(payload, issuesEvent, IssuesAction.Unlocked);
                    break;
                case IssuesActionValue.Unpinned:
                    this.ProcessIssuesMessage(payload, issuesEvent, IssuesAction.Unpinned);
                    break;
            }
        }

        protected virtual void ProcessIssuesMessage(WebhookPayload payload, IssuesEvent issuesEvent, IssuesAction action)
        {
        }

        private void ProcessLabelMessage(WebhookPayload payload, LabelEvent labelEvent)
        {
            switch (labelEvent.Action)
            {
                case LabelActionValue.Created:
                    this.ProcessLabelMessage(payload, labelEvent, LabelAction.Created);
                    break;
                case LabelActionValue.Deleted:
                    this.ProcessLabelMessage(payload, labelEvent, LabelAction.Deleted);
                    break;
                case LabelActionValue.Edited:
                    this.ProcessLabelMessage(payload, labelEvent, LabelAction.Edited);
                    break;
            }
        }

        protected virtual void ProcessLabelMessage(WebhookPayload payload, LabelEvent labelEvent, LabelAction action)
        {
        }

        private void ProcessMarketplacePurchaseMessage(WebhookPayload payload, MarketplacePurchaseEvent marketplacePurchaseEvent)
        {
            switch (marketplacePurchaseEvent.Action)
            {
                case MarketplacePurchaseActionValue.Cancelled:
                    this.ProcessMarketplacePurchaseMessage(payload, marketplacePurchaseEvent, MarketplacePurchaseAction.Cancelled);
                    break;
                case MarketplacePurchaseActionValue.Changed:
                    this.ProcessMarketplacePurchaseMessage(payload, marketplacePurchaseEvent, MarketplacePurchaseAction.Changed);
                    break;
                case MarketplacePurchaseActionValue.PendingChange:
                    this.ProcessMarketplacePurchaseMessage(payload, marketplacePurchaseEvent, MarketplacePurchaseAction.PendingChange);
                    break;
                case MarketplacePurchaseActionValue.PendingChangeCancelled:
                    this.ProcessMarketplacePurchaseMessage(payload, marketplacePurchaseEvent, MarketplacePurchaseAction.PendingChangeCancelled);
                    break;
                case MarketplacePurchaseActionValue.Purchased:
                    this.ProcessMarketplacePurchaseMessage(payload, marketplacePurchaseEvent, MarketplacePurchaseAction.Purchased);
                    break;
            }
        }

        protected virtual void ProcessMarketplacePurchaseMessage(WebhookPayload payload, MarketplacePurchaseEvent marketplacePurchaseEvent, MarketplacePurchaseAction action)
        {
        }

        private void ProcessMemberMessage(WebhookPayload payload, MemberEvent memberEvent)
        {
            switch (memberEvent.Action)
            {
                case MemberActionValue.Added:
                    this.ProcessMemberMessage(payload, memberEvent, MemberAction.Added);
                    break;
                case MemberActionValue.Edited:
                    this.ProcessMemberMessage(payload, memberEvent, MemberAction.Edited);
                    break;
                case MemberActionValue.Removed:
                    this.ProcessMemberMessage(payload, memberEvent, MemberAction.Removed);
                    break;
            }
        }

        protected virtual void ProcessMemberMessage(WebhookPayload payload, MemberEvent memberEvent, MemberAction action)
        {
        }

        private void ProcessMembershipMessage(WebhookPayload payload, MembershipEvent membershipEvent)
        {
            switch (membershipEvent.Action)
            {
                case MembershipActionValue.Added:
                    this.ProcessMembershipMessage(payload, membershipEvent, MembershipAction.Added);
                    break;
                case MembershipActionValue.Removed:
                    this.ProcessMembershipMessage(payload, membershipEvent, MembershipAction.Removed);
                    break;
            }
        }

        protected virtual void ProcessMembershipMessage(WebhookPayload payload, MembershipEvent membershipEvent, MembershipAction action)
        {
        }

        private void ProcessMetaMessage(WebhookPayload payload, MetaEvent metaEvent)
        {
            switch (metaEvent.Action)
            {
                case MetaActionValue.Deleted:
                    this.ProcessMetaMessage(payload, metaEvent, MetaAction.Deleted);
                    break;
            }
        }

        protected virtual void ProcessMetaMessage(WebhookPayload payload, MetaEvent metaEvent, MetaAction action)
        {
        }

        private void ProcessMilestoneMessage(WebhookPayload payload, MilestoneEvent milestoneEvent)
        {
            switch (milestoneEvent.Action)
            {
                case MilestoneActionValue.Closed:
                    this.ProcessMilestoneMessage(payload, milestoneEvent, MilestoneAction.Closed);
                    break;
                case MilestoneActionValue.Created:
                    this.ProcessMilestoneMessage(payload, milestoneEvent, MilestoneAction.Created);
                    break;
                case MilestoneActionValue.Deleted:
                    this.ProcessMilestoneMessage(payload, milestoneEvent, MilestoneAction.Deleted);
                    break;
                case MilestoneActionValue.Edited:
                    this.ProcessMilestoneMessage(payload, milestoneEvent, MilestoneAction.Edited);
                    break;
                case MilestoneActionValue.Opened:
                    this.ProcessMilestoneMessage(payload, milestoneEvent, MilestoneAction.Opened);
                    break;
            }
        }

        protected virtual void ProcessMilestoneMessage(WebhookPayload payload, MilestoneEvent milestoneEvent, MilestoneAction action)
        {
        }

        private void ProcessOrgBlockMessage(WebhookPayload payload, OrgBlockEvent orgBlockEvent)
        {
            switch (orgBlockEvent.Action)
            {
                case OrgBlockActionValue.Blocked:
                    this.ProcessOrgBlockMessage(payload, orgBlockEvent, OrgBlockAction.Blocked);
                    break;
                case OrgBlockActionValue.Unblocked:
                    this.ProcessOrgBlockMessage(payload, orgBlockEvent, OrgBlockAction.Unblocked);
                    break;
            }
        }

        protected virtual void ProcessOrgBlockMessage(WebhookPayload payload, OrgBlockEvent orgBlockEvent, OrgBlockAction action)
        {
        }

        private void ProcessOrganizationMessage(WebhookPayload payload, OrganizationEvent organizationEvent)
        {
            switch (organizationEvent.Action)
            {
                case OrganizationActionValue.Deleted:
                    this.ProcessOrganizationMessage(payload, organizationEvent, OrganizationAction.Deleted);
                    break;
                case OrganizationActionValue.MemberAdded:
                    this.ProcessOrganizationMessage(payload, organizationEvent, OrganizationAction.MemberAdded);
                    break;
                case OrganizationActionValue.MemberInvited:
                    this.ProcessOrganizationMessage(payload, organizationEvent, OrganizationAction.MemberInvited);
                    break;
                case OrganizationActionValue.MemberRemoved:
                    this.ProcessOrganizationMessage(payload, organizationEvent, OrganizationAction.MemberRemoved);
                    break;
                case OrganizationActionValue.Renamed:
                    this.ProcessOrganizationMessage(payload, organizationEvent, OrganizationAction.Renamed);
                    break;
            }
        }

        protected virtual void ProcessOrganizationMessage(WebhookPayload payload, OrganizationEvent organizationEvent, OrganizationAction action)
        {
        }

        private void ProcessPackageMessage(WebhookPayload payload, PackageEvent packageEvent)
        {
            switch (packageEvent.Action)
            {
                case PackageActionValue.Published:
                    this.ProcessPackageMessage(payload, packageEvent, PackageAction.Published);
                    break;
                case PackageActionValue.Updated:
                    this.ProcessPackageMessage(payload, packageEvent, PackageAction.Updated);
                    break;
            }
        }

        protected virtual void ProcessPackageMessage(WebhookPayload payload, PackageEvent packageEvent, PackageAction action)
        {
        }

        protected virtual void ProcessPageBuildMessage(WebhookPayload payload, PageBuildEvent pageBuildEvent)
        {
        }

        protected virtual void ProcessPingMessage(WebhookPayload payload, PingEvent pingEvent)
        {
        }

        private void ProcessProjectMessage(WebhookPayload payload, ProjectEvent projectEvent)
        {
            switch (projectEvent.Action)
            {
                case ProjectActionValue.Closed:
                    this.ProcessProjectMessage(payload, projectEvent, ProjectAction.Closed);
                    break;
                case ProjectActionValue.Created:
                    this.ProcessProjectMessage(payload, projectEvent, ProjectAction.Created);
                    break;
                case ProjectActionValue.Deleted:
                    this.ProcessProjectMessage(payload, projectEvent, ProjectAction.Deleted);
                    break;
                case ProjectActionValue.Edited:
                    this.ProcessProjectMessage(payload, projectEvent, ProjectAction.Edited);
                    break;
                case ProjectActionValue.Reopened:
                    this.ProcessProjectMessage(payload, projectEvent, ProjectAction.Reopened);
                    break;
            }
        }

        protected virtual void ProcessProjectMessage(WebhookPayload payload, ProjectEvent projectEvent, ProjectAction action)
        {
        }

        private void ProcessProjectCardMessage(WebhookPayload payload, ProjectCardEvent projectCardEvent)
        {
            switch (projectCardEvent.Action)
            {
                case ProjectCardActionValue.Converted:
                    this.ProcessProjectCardMessage(payload, projectCardEvent, ProjectCardAction.Converted);
                    break;
                case ProjectCardActionValue.Created:
                    this.ProcessProjectCardMessage(payload, projectCardEvent, ProjectCardAction.Created);
                    break;
                case ProjectCardActionValue.Deleted:
                    this.ProcessProjectCardMessage(payload, projectCardEvent, ProjectCardAction.Deleted);
                    break;
                case ProjectCardActionValue.Edited:
                    this.ProcessProjectCardMessage(payload, projectCardEvent, ProjectCardAction.Edited);
                    break;
                case ProjectCardActionValue.Moved:
                    this.ProcessProjectCardMessage(payload, projectCardEvent, ProjectCardAction.Moved);
                    break;
            }
        }

        protected virtual void ProcessProjectCardMessage(WebhookPayload payload, ProjectCardEvent projectCardEvent, ProjectCardAction action)
        {
        }

        private void ProcessProjectColumnMessage(WebhookPayload payload, ProjectColumnEvent projectColumnEvent)
        {
            switch (projectColumnEvent.Action)
            {
                case ProjectColumnActionValue.Created:
                    this.ProcessProjectColumnMessage(payload, projectColumnEvent, ProjectColumnAction.Created);
                    break;
                case ProjectColumnActionValue.Deleted:
                    this.ProcessProjectColumnMessage(payload, projectColumnEvent, ProjectColumnAction.Deleted);
                    break;
                case ProjectColumnActionValue.Edited:
                    this.ProcessProjectColumnMessage(payload, projectColumnEvent, ProjectColumnAction.Edited);
                    break;
                case ProjectColumnActionValue.Moved:
                    this.ProcessProjectColumnMessage(payload, projectColumnEvent, ProjectColumnAction.Moved);
                    break;
            }
        }

        protected virtual void ProcessProjectColumnMessage(WebhookPayload payload, ProjectColumnEvent projectColumnEvent, ProjectColumnAction action)
        {
        }

        protected virtual void ProcessPublicMessage(WebhookPayload payload, PublicEvent publicEvent)
        {
        }

        private void ProcessPullRequestMessage(WebhookPayload payload, PullRequestEvent pullRequestEvent)
        {
            switch (pullRequestEvent.Action)
            {
                case PullRequestActionValue.Assigned:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.Assigned);
                    break;
                case PullRequestActionValue.AutoMergeDisabled:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.AutoMergeDisabled);
                    break;
                case PullRequestActionValue.AutoMergeEnabled:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.AutoMergeEnabled);
                    break;
                case PullRequestActionValue.Closed:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.Closed);
                    break;
                case PullRequestActionValue.ConvertedToDraft:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.ConvertedToDraft);
                    break;
                case PullRequestActionValue.Edited:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.Edited);
                    break;
                case PullRequestActionValue.Labeled:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.Labeled);
                    break;
                case PullRequestActionValue.Locked:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.Locked);
                    break;
                case PullRequestActionValue.Opened:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.Opened);
                    break;
                case PullRequestActionValue.ReadyForReview:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.ReadyForReview);
                    break;
                case PullRequestActionValue.Reopened:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.Reopened);
                    break;
                case PullRequestActionValue.ReviewRequestRemoved:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.ReviewRequestRemoved);
                    break;
                case PullRequestActionValue.ReviewRequested:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.ReviewRequested);
                    break;
                case PullRequestActionValue.Synchronize:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.Synchronize);
                    break;
                case PullRequestActionValue.Unassigned:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.Unassigned);
                    break;
                case PullRequestActionValue.Unlabeled:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.Unlabeled);
                    break;
                case PullRequestActionValue.Unlocked:
                    this.ProcessPullRequestMessage(payload, pullRequestEvent, PullRequestAction.Unlocked);
                    break;
            }
        }

        protected virtual void ProcessPullRequestMessage(WebhookPayload payload, PullRequestEvent pullRequestEvent, PullRequestAction action)
        {
        }

        private void ProcessPullRequestReviewMessage(WebhookPayload payload, PullRequestReviewEvent pullRequestReviewEvent)
        {
            switch (pullRequestReviewEvent.Action)
            {
                case PullRequestReviewActionValue.Dismissed:
                    this.ProcessPullRequestReviewMessage(payload, pullRequestReviewEvent, PullRequestReviewAction.Dismissed);
                    break;
                case PullRequestReviewActionValue.Edited:
                    this.ProcessPullRequestReviewMessage(payload, pullRequestReviewEvent, PullRequestReviewAction.Edited);
                    break;
                case PullRequestReviewActionValue.Submitted:
                    this.ProcessPullRequestReviewMessage(payload, pullRequestReviewEvent, PullRequestReviewAction.Submitted);
                    break;
            }
        }

        protected virtual void ProcessPullRequestReviewMessage(WebhookPayload payload, PullRequestReviewEvent pullRequestReviewEvent, PullRequestReviewAction action)
        {
        }

        private void ProcessPullRequestReviewCommentMessage(WebhookPayload payload, PullRequestReviewCommentEvent pullRequestReviewCommentEvent)
        {
            switch (pullRequestReviewCommentEvent.Action)
            {
                case PullRequestReviewCommentActionValue.Created:
                    this.ProcessPullRequestReviewCommentMessage(payload, pullRequestReviewCommentEvent, PullRequestReviewCommentAction.Created);
                    break;
                case PullRequestReviewCommentActionValue.Deleted:
                    this.ProcessPullRequestReviewCommentMessage(payload, pullRequestReviewCommentEvent, PullRequestReviewCommentAction.Deleted);
                    break;
                case PullRequestReviewCommentActionValue.Edited:
                    this.ProcessPullRequestReviewCommentMessage(payload, pullRequestReviewCommentEvent, PullRequestReviewCommentAction.Edited);
                    break;
            }
        }

        protected virtual void ProcessPullRequestReviewCommentMessage(WebhookPayload payload, PullRequestReviewCommentEvent pullRequestReviewCommentEvent, PullRequestReviewCommentAction action)
        {
        }

        protected virtual void ProcessPushMessage(WebhookPayload payload, PushEvent pushEvent)
        {
        }

        private void ProcessReleaseMessage(WebhookPayload payload, ReleaseEvent releaseEvent)
        {
            switch (releaseEvent.Action)
            {
                case ReleaseActionValue.Created:
                    this.ProcessReleaseMessage(payload, releaseEvent, ReleaseAction.Created);
                    break;
                case ReleaseActionValue.Deleted:
                    this.ProcessReleaseMessage(payload, releaseEvent, ReleaseAction.Deleted);
                    break;
                case ReleaseActionValue.Edited:
                    this.ProcessReleaseMessage(payload, releaseEvent, ReleaseAction.Edited);
                    break;
                case ReleaseActionValue.Prereleased:
                    this.ProcessReleaseMessage(payload, releaseEvent, ReleaseAction.Prereleased);
                    break;
                case ReleaseActionValue.Published:
                    this.ProcessReleaseMessage(payload, releaseEvent, ReleaseAction.Published);
                    break;
                case ReleaseActionValue.Released:
                    this.ProcessReleaseMessage(payload, releaseEvent, ReleaseAction.Released);
                    break;
                case ReleaseActionValue.Unpublished:
                    this.ProcessReleaseMessage(payload, releaseEvent, ReleaseAction.Unpublished);
                    break;
            }
        }

        protected virtual void ProcessReleaseMessage(WebhookPayload payload, ReleaseEvent releaseEvent, ReleaseAction action)
        {
        }

        private void ProcessRepositoryMessage(WebhookPayload payload, RepositoryEvent repositoryEvent)
        {
            switch (repositoryEvent.Action)
            {
                case RepositoryActionValue.Archived:
                    this.ProcessRepositoryMessage(payload, repositoryEvent, RepositoryAction.Archived);
                    break;
                case RepositoryActionValue.Created:
                    this.ProcessRepositoryMessage(payload, repositoryEvent, RepositoryAction.Created);
                    break;
                case RepositoryActionValue.Deleted:
                    this.ProcessRepositoryMessage(payload, repositoryEvent, RepositoryAction.Deleted);
                    break;
                case RepositoryActionValue.Edited:
                    this.ProcessRepositoryMessage(payload, repositoryEvent, RepositoryAction.Edited);
                    break;
                case RepositoryActionValue.Privatized:
                    this.ProcessRepositoryMessage(payload, repositoryEvent, RepositoryAction.Privatized);
                    break;
                case RepositoryActionValue.Publicized:
                    this.ProcessRepositoryMessage(payload, repositoryEvent, RepositoryAction.Publicized);
                    break;
                case RepositoryActionValue.Renamed:
                    this.ProcessRepositoryMessage(payload, repositoryEvent, RepositoryAction.Renamed);
                    break;
                case RepositoryActionValue.Transferred:
                    this.ProcessRepositoryMessage(payload, repositoryEvent, RepositoryAction.Transferred);
                    break;
                case RepositoryActionValue.Unarchived:
                    this.ProcessRepositoryMessage(payload, repositoryEvent, RepositoryAction.Unarchived);
                    break;
            }
        }

        protected virtual void ProcessRepositoryMessage(WebhookPayload payload, RepositoryEvent repositoryEvent, RepositoryAction action)
        {
        }

        private void ProcessRepositoryDispatchMessage(WebhookPayload payload, RepositoryDispatchEvent repositoryDispatchEvent)
        {
            switch (repositoryDispatchEvent.Action)
            {
                case RepositoryDispatchActionValue.OnDemandTest:
                    this.ProcessRepositoryDispatchMessage(payload, repositoryDispatchEvent, RepositoryDispatchAction.OnDemandTest);
                    break;
            }
        }

        protected virtual void ProcessRepositoryDispatchMessage(WebhookPayload payload, RepositoryDispatchEvent repositoryDispatchEvent, RepositoryDispatchAction action)
        {
        }

        protected virtual void ProcessRepositoryImportMessage(WebhookPayload payload, RepositoryImportEvent repositoryImportEvent)
        {
        }

        private void ProcessRepositoryVulnerabilityAlertMessage(WebhookPayload payload, RepositoryVulnerabilityAlertEvent repositoryVulnerabilityAlertEvent)
        {
            switch (repositoryVulnerabilityAlertEvent.Action)
            {
                case RepositoryVulnerabilityAlertActionValue.Create:
                    this.ProcessRepositoryVulnerabilityAlertMessage(payload, repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction.Create);
                    break;
                case RepositoryVulnerabilityAlertActionValue.Dismiss:
                    this.ProcessRepositoryVulnerabilityAlertMessage(payload, repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction.Dismiss);
                    break;
                case RepositoryVulnerabilityAlertActionValue.Resolve:
                    this.ProcessRepositoryVulnerabilityAlertMessage(payload, repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction.Resolve);
                    break;
            }
        }

        protected virtual void ProcessRepositoryVulnerabilityAlertMessage(WebhookPayload payload, RepositoryVulnerabilityAlertEvent repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction action)
        {
        }

        private void ProcessSecretScanningAlertMessage(WebhookPayload payload, SecretScanningAlertEvent secretScanningAlertEvent)
        {
            switch (secretScanningAlertEvent.Action)
            {
                case SecretScanningAlertActionValue.Created:
                    this.ProcessSecretScanningAlertMessage(payload, secretScanningAlertEvent, SecretScanningAlertAction.Created);
                    break;
                case SecretScanningAlertActionValue.Reopened:
                    this.ProcessSecretScanningAlertMessage(payload, secretScanningAlertEvent, SecretScanningAlertAction.Reopened);
                    break;
                case SecretScanningAlertActionValue.Resolved:
                    this.ProcessSecretScanningAlertMessage(payload, secretScanningAlertEvent, SecretScanningAlertAction.Resolved);
                    break;
            }
        }

        protected virtual void ProcessSecretScanningAlertMessage(WebhookPayload payload, SecretScanningAlertEvent secretScanningAlertEvent, SecretScanningAlertAction action)
        {
        }

        private void ProcessSecurityAdvisoryMessage(WebhookPayload payload, SecurityAdvisoryEvent securityAdvisoryEvent)
        {
            switch (securityAdvisoryEvent.Action)
            {
                case SecurityAdvisoryActionValue.Performed:
                    this.ProcessSecurityAdvisoryMessage(payload, securityAdvisoryEvent, SecurityAdvisoryAction.Performed);
                    break;
                case SecurityAdvisoryActionValue.Published:
                    this.ProcessSecurityAdvisoryMessage(payload, securityAdvisoryEvent, SecurityAdvisoryAction.Published);
                    break;
                case SecurityAdvisoryActionValue.Updated:
                    this.ProcessSecurityAdvisoryMessage(payload, securityAdvisoryEvent, SecurityAdvisoryAction.Updated);
                    break;
                case SecurityAdvisoryActionValue.Withdrawn:
                    this.ProcessSecurityAdvisoryMessage(payload, securityAdvisoryEvent, SecurityAdvisoryAction.Withdrawn);
                    break;
            }
        }

        protected virtual void ProcessSecurityAdvisoryMessage(WebhookPayload payload, SecurityAdvisoryEvent securityAdvisoryEvent, SecurityAdvisoryAction action)
        {
        }

        private void ProcessSponsorshipMessage(WebhookPayload payload, SponsorshipEvent sponsorshipEvent)
        {
            switch (sponsorshipEvent.Action)
            {
                case SponsorshipActionValue.Cancelled:
                    this.ProcessSponsorshipMessage(payload, sponsorshipEvent, SponsorshipAction.Cancelled);
                    break;
                case SponsorshipActionValue.Created:
                    this.ProcessSponsorshipMessage(payload, sponsorshipEvent, SponsorshipAction.Created);
                    break;
                case SponsorshipActionValue.Edited:
                    this.ProcessSponsorshipMessage(payload, sponsorshipEvent, SponsorshipAction.Edited);
                    break;
                case SponsorshipActionValue.PendingCancellation:
                    this.ProcessSponsorshipMessage(payload, sponsorshipEvent, SponsorshipAction.PendingCancellation);
                    break;
                case SponsorshipActionValue.PendingTierChange:
                    this.ProcessSponsorshipMessage(payload, sponsorshipEvent, SponsorshipAction.PendingTierChange);
                    break;
                case SponsorshipActionValue.TierChanged:
                    this.ProcessSponsorshipMessage(payload, sponsorshipEvent, SponsorshipAction.TierChanged);
                    break;
            }
        }

        protected virtual void ProcessSponsorshipMessage(WebhookPayload payload, SponsorshipEvent sponsorshipEvent, SponsorshipAction action)
        {
        }

        private void ProcessStarMessage(WebhookPayload payload, StarEvent starEvent)
        {
            switch (starEvent.Action)
            {
                case StarActionValue.Created:
                    this.ProcessStarMessage(payload, starEvent, StarAction.Created);
                    break;
                case StarActionValue.Deleted:
                    this.ProcessStarMessage(payload, starEvent, StarAction.Deleted);
                    break;
            }
        }

        protected virtual void ProcessStarMessage(WebhookPayload payload, StarEvent starEvent, StarAction action)
        {
        }

        protected virtual void ProcessStatusMessage(WebhookPayload payload, StatusEvent statusEvent)
        {
        }

        private void ProcessTeamMessage(WebhookPayload payload, TeamEvent teamEvent)
        {
            switch (teamEvent.Action)
            {
                case TeamActionValue.AddedToRepository:
                    this.ProcessTeamMessage(payload, teamEvent, TeamAction.AddedToRepository);
                    break;
                case TeamActionValue.Created:
                    this.ProcessTeamMessage(payload, teamEvent, TeamAction.Created);
                    break;
                case TeamActionValue.Deleted:
                    this.ProcessTeamMessage(payload, teamEvent, TeamAction.Deleted);
                    break;
                case TeamActionValue.Edited:
                    this.ProcessTeamMessage(payload, teamEvent, TeamAction.Edited);
                    break;
                case TeamActionValue.RemovedFromRepository:
                    this.ProcessTeamMessage(payload, teamEvent, TeamAction.RemovedFromRepository);
                    break;
            }
        }

        protected virtual void ProcessTeamMessage(WebhookPayload payload, TeamEvent teamEvent, TeamAction action)
        {
        }

        private void ProcessTeamAddMessage(WebhookPayload payload, TeamAddEvent teamAddEvent)
        {
            switch (teamAddEvent.Action)
            {
                case TeamAddActionValue.Event:
                    this.ProcessTeamAddMessage(payload, teamAddEvent, TeamAddAction.Event);
                    break;
            }
        }

        protected virtual void ProcessTeamAddMessage(WebhookPayload payload, TeamAddEvent teamAddEvent, TeamAddAction action)
        {
        }

        private void ProcessWatchMessage(WebhookPayload payload, WatchEvent watchEvent)
        {
            switch (watchEvent.Action)
            {
                case WatchActionValue.Started:
                    this.ProcessWatchMessage(payload, watchEvent, WatchAction.Started);
                    break;
            }
        }

        protected virtual void ProcessWatchMessage(WebhookPayload payload, WatchEvent watchEvent, WatchAction action)
        {
        }

        protected virtual void ProcessWorkflowDispatchMessage(WebhookPayload payload, WorkflowDispatchEvent workflowDispatchEvent)
        {
        }

        private void ProcessWorkflowJobMessage(WebhookPayload payload, WorkflowJobEvent workflowJobEvent)
        {
            switch (workflowJobEvent.Action)
            {
                case WorkflowJobActionValue.Completed:
                    this.ProcessWorkflowJobMessage(payload, workflowJobEvent, WorkflowJobAction.Completed);
                    break;
                case WorkflowJobActionValue.Started:
                    this.ProcessWorkflowJobMessage(payload, workflowJobEvent, WorkflowJobAction.Started);
                    break;
            }
        }

        protected virtual void ProcessWorkflowJobMessage(WebhookPayload payload, WorkflowJobEvent workflowJobEvent, WorkflowJobAction action)
        {
        }

        private void ProcessWorkflowRunMessage(WebhookPayload payload, WorkflowRunEvent workflowRunEvent)
        {
            switch (workflowRunEvent.Action)
            {
                case WorkflowRunActionValue.Completed:
                    this.ProcessWorkflowRunMessage(payload, workflowRunEvent, WorkflowRunAction.Completed);
                    break;
                case WorkflowRunActionValue.Requested:
                    this.ProcessWorkflowRunMessage(payload, workflowRunEvent, WorkflowRunAction.Requested);
                    break;
            }
        }

        protected virtual void ProcessWorkflowRunMessage(WebhookPayload payload, WorkflowRunEvent workflowRunEvent, WorkflowRunAction action)
        {
        }
    }
}
