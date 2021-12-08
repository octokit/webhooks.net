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

            var webhookHeaders = WebhookHeaders.Parse(headers);
            var webhookEvent = this.DeserializeWebhookEvent(webhookHeaders, body);

            return this.ProcessWebhookAsync(webhookHeaders, webhookEvent);
        }

        [PublicAPI]
        public virtual Task ProcessWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            switch (headers.Event)
            {
                case WebhookEventType.BranchProtectionRule:
                    return this.ProcessBranchProtectionRuleWebhookAsync(headers, webhookEvent);
                case WebhookEventType.CheckRun:
                    return this.ProcessCheckRunWebhookAsync(headers, webhookEvent);
                case WebhookEventType.CheckSuite:
                    return this.ProcessCheckSuiteWebhookAsync(headers, webhookEvent);
                case WebhookEventType.CodeScanningAlert:
                    return this.ProcessCodeScanningAlertWebhookAsync(headers, webhookEvent);
                case WebhookEventType.CommitComment:
                    return this.ProcessCommitCommentWebhookAsync(headers, webhookEvent);
                case WebhookEventType.ContentReference:
                    return this.ProcessContentReferenceWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Create:
                    return this.ProcessCreateWebhookAsync(headers, (CreateEvent)webhookEvent);
                case WebhookEventType.Delete:
                    return this.ProcessDeleteWebhookAsync(headers, (DeleteEvent)webhookEvent);
                case WebhookEventType.DeployKey:
                    return this.ProcessDeployKeyWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Deployment:
                    return this.ProcessDeploymentWebhookAsync(headers, webhookEvent);
                case WebhookEventType.DeploymentStatus:
                    return this.ProcessDeploymentStatusWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Discussion:
                    return this.ProcessDiscussionWebhookAsync(headers, webhookEvent);
                case WebhookEventType.DiscussionComment:
                    return this.ProcessDiscussionCommentWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Fork:
                    return this.ProcessForkWebhookAsync(headers, (ForkEvent)webhookEvent);
                case WebhookEventType.GithubAppAuthorization:
                    return this.ProcessGithubAppAuthorizationWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Gollum:
                    return this.ProcessGollumWebhookAsync(headers, (GollumEvent)webhookEvent);
                case WebhookEventType.Installation:
                    return this.ProcessInstallationWebhookAsync(headers, webhookEvent);
                case WebhookEventType.InstallationRepositories:
                    return this.ProcessInstallationRepositoriesWebhookAsync(headers, webhookEvent);
                case WebhookEventType.IssueComment:
                    return this.ProcessIssueCommentWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Issues:
                    return this.ProcessIssuesWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Label:
                    return this.ProcessLabelWebhookAsync(headers, webhookEvent);
                case WebhookEventType.MarketplacePurchase:
                    return this.ProcessMarketplacePurchaseWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Member:
                    return this.ProcessMemberWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Membership:
                    return this.ProcessMembershipWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Meta:
                    return this.ProcessMetaWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Milestone:
                    return this.ProcessMilestoneWebhookAsync(headers, webhookEvent);
                case WebhookEventType.OrgBlock:
                    return this.ProcessOrgBlockWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Organization:
                    return this.ProcessOrganizationWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Package:
                    return this.ProcessPackageWebhookAsync(headers, webhookEvent);
                case WebhookEventType.PageBuild:
                    return this.ProcessPageBuildWebhookAsync(headers, (PageBuildEvent)webhookEvent);
                case WebhookEventType.Ping:
                    return this.ProcessPingWebhookAsync(headers, (PingEvent)webhookEvent);
                case WebhookEventType.Project:
                    return this.ProcessProjectWebhookAsync(headers, webhookEvent);
                case WebhookEventType.ProjectCard:
                    return this.ProcessProjectCardWebhookAsync(headers, webhookEvent);
                case WebhookEventType.ProjectColumn:
                    return this.ProcessProjectColumnWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Public:
                    return this.ProcessPublicWebhookAsync(headers, (PublicEvent)webhookEvent);
                case WebhookEventType.PullRequest:
                    return this.ProcessPullRequestWebhookAsync(headers, webhookEvent);
                case WebhookEventType.PullRequestReview:
                    return this.ProcessPullRequestReviewWebhookAsync(headers, webhookEvent);
                case WebhookEventType.PullRequestReviewComment:
                    return this.ProcessPullRequestReviewCommentWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Push:
                    return this.ProcessPushWebhookAsync(headers, (PushEvent)webhookEvent);
                case WebhookEventType.Release:
                    return this.ProcessReleaseWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Repository:
                    return this.ProcessRepositoryWebhookAsync(headers, webhookEvent);
                case WebhookEventType.RepositoryDispatch:
                    return this.ProcessRepositoryDispatchWebhookAsync(headers, webhookEvent);
                case WebhookEventType.RepositoryImport:
                    return this.ProcessRepositoryImportWebhookAsync(headers, (RepositoryImportEvent)webhookEvent);
                case WebhookEventType.RepositoryVulnerabilityAlert:
                    return this.ProcessRepositoryVulnerabilityAlertWebhookAsync(headers, webhookEvent);
                case WebhookEventType.SecretScanningAlert:
                    return this.ProcessSecretScanningAlertWebhookAsync(headers, webhookEvent);
                case WebhookEventType.SecurityAdvisory:
                    return this.ProcessSecurityAdvisoryWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Sponsorship:
                    return this.ProcessSponsorshipWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Star:
                    return this.ProcessStarWebhookAsync(headers, webhookEvent);
                case WebhookEventType.Status:
                    return this.ProcessStatusWebhookAsync(headers, (StatusEvent)webhookEvent);
                case WebhookEventType.Team:
                    return this.ProcessTeamWebhookAsync(headers, webhookEvent);
                case WebhookEventType.TeamAdd:
                    return this.ProcessTeamAddWebhookAsync(headers, (TeamAddEvent)webhookEvent);
                case WebhookEventType.Watch:
                    return this.ProcessWatchWebhookAsync(headers, webhookEvent);
                case WebhookEventType.WorkflowDispatch:
                    return this.ProcessWorkflowDispatchWebhookAsync(headers, (WorkflowDispatchEvent)webhookEvent);
                case WebhookEventType.WorkflowJob:
                    return this.ProcessWorkflowJobWebhookAsync(headers, webhookEvent);
                case WebhookEventType.WorkflowRun:
                    return this.ProcessWorkflowRunWebhookAsync(headers, webhookEvent);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        public virtual WebhookEvent DeserializeWebhookEvent(WebhookHeaders headers, string body)
        {
            switch (headers.Event)
            {
                case WebhookEventType.BranchProtectionRule:
                    return JsonSerializer.Deserialize<BranchProtectionRuleEvent>(body)!;
                case WebhookEventType.CheckRun:
                    return JsonSerializer.Deserialize<CheckRunEvent>(body)!;
                case WebhookEventType.CheckSuite:
                    return JsonSerializer.Deserialize<CheckSuiteEvent>(body)!;
                case WebhookEventType.CodeScanningAlert:
                    return JsonSerializer.Deserialize<CodeScanningAlertEvent>(body)!;
                case WebhookEventType.CommitComment:
                    return JsonSerializer.Deserialize<CommitCommentEvent>(body)!;
                case WebhookEventType.ContentReference:
                    return JsonSerializer.Deserialize<ContentReferenceEvent>(body)!;
                case WebhookEventType.Create:
                    return JsonSerializer.Deserialize<CreateEvent>(body)!;
                case WebhookEventType.Delete:
                    return JsonSerializer.Deserialize<DeleteEvent>(body)!;
                case WebhookEventType.DeployKey:
                    return JsonSerializer.Deserialize<DeployKeyEvent>(body)!;
                case WebhookEventType.Deployment:
                    return JsonSerializer.Deserialize<DeploymentEvent>(body)!;
                case WebhookEventType.DeploymentStatus:
                    return JsonSerializer.Deserialize<DeploymentStatusEvent>(body)!;
                case WebhookEventType.Discussion:
                    return JsonSerializer.Deserialize<DiscussionEvent>(body)!;
                case WebhookEventType.DiscussionComment:
                    return JsonSerializer.Deserialize<DiscussionCommentEvent>(body)!;
                case WebhookEventType.Fork:
                    return JsonSerializer.Deserialize<ForkEvent>(body)!;
                case WebhookEventType.GithubAppAuthorization:
                    return JsonSerializer.Deserialize<GithubAppAuthorizationEvent>(body)!;
                case WebhookEventType.Gollum:
                    return JsonSerializer.Deserialize<GollumEvent>(body)!;
                case WebhookEventType.Installation:
                    return JsonSerializer.Deserialize<InstallationEvent>(body)!;
                case WebhookEventType.InstallationRepositories:
                    return JsonSerializer.Deserialize<InstallationRepositoriesEvent>(body)!;
                case WebhookEventType.IssueComment:
                    return JsonSerializer.Deserialize<IssueCommentEvent>(body)!;
                case WebhookEventType.Issues:
                    return JsonSerializer.Deserialize<IssuesEvent>(body)!;
                case WebhookEventType.Label:
                    return JsonSerializer.Deserialize<LabelEvent>(body)!;
                case WebhookEventType.MarketplacePurchase:
                    return JsonSerializer.Deserialize<MarketplacePurchaseEvent>(body)!;
                case WebhookEventType.Member:
                    return JsonSerializer.Deserialize<MemberEvent>(body)!;
                case WebhookEventType.Membership:
                    return JsonSerializer.Deserialize<MembershipEvent>(body)!;
                case WebhookEventType.Meta:
                    return JsonSerializer.Deserialize<MetaEvent>(body)!;
                case WebhookEventType.Milestone:
                    return JsonSerializer.Deserialize<MilestoneEvent>(body)!;
                case WebhookEventType.OrgBlock:
                    return JsonSerializer.Deserialize<OrgBlockEvent>(body)!;
                case WebhookEventType.Organization:
                    return JsonSerializer.Deserialize<OrganizationEvent>(body)!;
                case WebhookEventType.Package:
                    return JsonSerializer.Deserialize<PackageEvent>(body)!;
                case WebhookEventType.PageBuild:
                    return JsonSerializer.Deserialize<PageBuildEvent>(body)!;
                case WebhookEventType.Ping:
                    return JsonSerializer.Deserialize<PingEvent>(body)!;
                case WebhookEventType.Project:
                    return JsonSerializer.Deserialize<ProjectEvent>(body)!;
                case WebhookEventType.ProjectCard:
                    return JsonSerializer.Deserialize<ProjectCardEvent>(body)!;
                case WebhookEventType.ProjectColumn:
                    return JsonSerializer.Deserialize<ProjectColumnEvent>(body)!;
                case WebhookEventType.Public:
                    return JsonSerializer.Deserialize<PublicEvent>(body)!;
                case WebhookEventType.PullRequest:
                    return JsonSerializer.Deserialize<PullRequestEvent>(body)!;
                case WebhookEventType.PullRequestReview:
                    return JsonSerializer.Deserialize<PullRequestReviewEvent>(body)!;
                case WebhookEventType.PullRequestReviewComment:
                    return JsonSerializer.Deserialize<PullRequestReviewCommentEvent>(body)!;
                case WebhookEventType.Push:
                    return JsonSerializer.Deserialize<PushEvent>(body)!;
                case WebhookEventType.Release:
                    return JsonSerializer.Deserialize<ReleaseEvent>(body)!;
                case WebhookEventType.Repository:
                    return JsonSerializer.Deserialize<RepositoryEvent>(body)!;
                case WebhookEventType.RepositoryDispatch:
                    return JsonSerializer.Deserialize<RepositoryDispatchEvent>(body)!;
                case WebhookEventType.RepositoryImport:
                    return JsonSerializer.Deserialize<RepositoryImportEvent>(body)!;
                case WebhookEventType.RepositoryVulnerabilityAlert:
                    return JsonSerializer.Deserialize<RepositoryVulnerabilityAlertEvent>(body)!;
                case WebhookEventType.SecretScanningAlert:
                    return JsonSerializer.Deserialize<SecretScanningAlertEvent>(body)!;
                case WebhookEventType.SecurityAdvisory:
                    return JsonSerializer.Deserialize<SecurityAdvisoryEvent>(body)!;
                case WebhookEventType.Sponsorship:
                    return JsonSerializer.Deserialize<SponsorshipEvent>(body)!;
                case WebhookEventType.Star:
                    return JsonSerializer.Deserialize<StarEvent>(body)!;
                case WebhookEventType.Status:
                    return JsonSerializer.Deserialize<StatusEvent>(body)!;
                case WebhookEventType.Team:
                    return JsonSerializer.Deserialize<TeamEvent>(body)!;
                case WebhookEventType.TeamAdd:
                    return JsonSerializer.Deserialize<TeamAddEvent>(body)!;
                case WebhookEventType.Watch:
                    return JsonSerializer.Deserialize<WatchEvent>(body)!;
                case WebhookEventType.WorkflowDispatch:
                    return JsonSerializer.Deserialize<WorkflowDispatchEvent>(body)!;
                case WebhookEventType.WorkflowJob:
                    return JsonSerializer.Deserialize<WorkflowJobEvent>(body)!;
                case WebhookEventType.WorkflowRun:
                    return JsonSerializer.Deserialize<WorkflowRunEvent>(body)!;
            }

            throw new Exception("Unable to deserialize event");
        }

        private Task ProcessBranchProtectionRuleWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var branchProtectionRuleEvent = (BranchProtectionRuleEvent)webhookEvent;
            switch (branchProtectionRuleEvent.Action)
            {
                case BranchProtectionRuleActionValue.Created:
                    return this.ProcessBranchProtectionRuleWebhookAsync(headers, branchProtectionRuleEvent, BranchProtectionRuleAction.Created);
                case BranchProtectionRuleActionValue.Deleted:
                    return this.ProcessBranchProtectionRuleWebhookAsync(headers, branchProtectionRuleEvent, BranchProtectionRuleAction.Deleted);
                case BranchProtectionRuleActionValue.Edited:
                    return this.ProcessBranchProtectionRuleWebhookAsync(headers, branchProtectionRuleEvent, BranchProtectionRuleAction.Edited);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessBranchProtectionRuleWebhookAsync(WebhookHeaders headers, BranchProtectionRuleEvent branchProtectionRuleEvent, BranchProtectionRuleAction action) => Task.CompletedTask;

        private Task ProcessCheckRunWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var checkRunEvent = (CheckRunEvent)webhookEvent;
            switch (checkRunEvent.Action)
            {
                case CheckRunActionValue.Completed:
                    return this.ProcessCheckRunWebhookAsync(headers, checkRunEvent, CheckRunAction.Completed);
                case CheckRunActionValue.Created:
                    return this.ProcessCheckRunWebhookAsync(headers, checkRunEvent, CheckRunAction.Created);
                case CheckRunActionValue.RequestedAction:
                    return this.ProcessCheckRunWebhookAsync(headers, checkRunEvent, CheckRunAction.RequestedAction);
                case CheckRunActionValue.Rerequested:
                    return this.ProcessCheckRunWebhookAsync(headers, checkRunEvent, CheckRunAction.Rerequested);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessCheckRunWebhookAsync(WebhookHeaders headers, CheckRunEvent checkRunEvent, CheckRunAction action) => Task.CompletedTask;

        private Task ProcessCheckSuiteWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var checkSuiteEvent = (CheckSuiteEvent)webhookEvent;
            switch (checkSuiteEvent.Action)
            {
                case CheckSuiteActionValue.Completed:
                    return this.ProcessCheckSuiteWebhookAsync(headers, checkSuiteEvent, CheckSuiteAction.Completed);
                case CheckSuiteActionValue.Requested:
                    return this.ProcessCheckSuiteWebhookAsync(headers, checkSuiteEvent, CheckSuiteAction.Requested);
                case CheckSuiteActionValue.Rerequested:
                    return this.ProcessCheckSuiteWebhookAsync(headers, checkSuiteEvent, CheckSuiteAction.Rerequested);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessCheckSuiteWebhookAsync(WebhookHeaders headers, CheckSuiteEvent checkSuiteEvent, CheckSuiteAction action) => Task.CompletedTask;

        private Task ProcessCodeScanningAlertWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var codeScanningAlertEvent = (CodeScanningAlertEvent)webhookEvent;
            switch (codeScanningAlertEvent.Action)
            {
                case CodeScanningAlertActionValue.AppearedInBranch:
                    return this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.AppearedInBranch);
                case CodeScanningAlertActionValue.ClosedByUser:
                    return this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.ClosedByUser);
                case CodeScanningAlertActionValue.Created:
                    return this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.Created);
                case CodeScanningAlertActionValue.Fixed:
                    return this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.Fixed);
                case CodeScanningAlertActionValue.Reopened:
                    return this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.Reopened);
                case CodeScanningAlertActionValue.ReopenedByUser:
                    return this.ProcessCodeScanningAlertWebhookAsync(headers, codeScanningAlertEvent, CodeScanningAlertAction.ReopenedByUser);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessCodeScanningAlertWebhookAsync(WebhookHeaders headers, CodeScanningAlertEvent codeScanningAlertEvent, CodeScanningAlertAction action) => Task.CompletedTask;

        private Task ProcessCommitCommentWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var commitCommentEvent = (CommitCommentEvent)webhookEvent;
            switch (commitCommentEvent.Action)
            {
                case CommitCommentActionValue.Created:
                    return this.ProcessCommitCommentWebhookAsync(headers, commitCommentEvent, CommitCommentAction.Created);

            }
            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessCommitCommentWebhookAsync(WebhookHeaders headers, CommitCommentEvent commitCommentEvent, CommitCommentAction action) => Task.CompletedTask;

        private Task ProcessContentReferenceWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var contentReferenceEvent = (ContentReferenceEvent)webhookEvent;
            switch (contentReferenceEvent.Action)
            {
                case ContentReferenceActionValue.Created:
                    return this.ProcessContentReferenceWebhookAsync(headers, contentReferenceEvent, ContentReferenceAction.Created);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessContentReferenceWebhookAsync(WebhookHeaders headers, ContentReferenceEvent contentReferenceEvent, ContentReferenceAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessCreateWebhookAsync(WebhookHeaders headers, CreateEvent createEvent) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessDeleteWebhookAsync(WebhookHeaders headers, DeleteEvent deleteEvent) => Task.CompletedTask;

        private Task ProcessDeployKeyWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var deployKeyEvent = (DeployKeyEvent)webhookEvent;
            switch (deployKeyEvent.Action)
            {
                case DeployKeyActionValue.Created:
                    return this.ProcessDeployKeyWebhookAsync(headers, deployKeyEvent, DeployKeyAction.Created);
                case DeployKeyActionValue.Deleted:
                    return this.ProcessDeployKeyWebhookAsync(headers, deployKeyEvent, DeployKeyAction.Deleted);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessDeployKeyWebhookAsync(WebhookHeaders headers, DeployKeyEvent deployKeyEvent, DeployKeyAction action) => Task.CompletedTask;

        private Task ProcessDeploymentWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var deploymentEvent = (DeploymentEvent)webhookEvent;
            switch (deploymentEvent.Action)
            {
                case DeploymentActionValue.Created:
                    return this.ProcessDeploymentWebhookAsync(headers, deploymentEvent, DeploymentAction.Created);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessDeploymentWebhookAsync(WebhookHeaders headers, DeploymentEvent deploymentEvent, DeploymentAction action) => Task.CompletedTask;

        private Task ProcessDeploymentStatusWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var deploymentStatusEvent = (DeploymentStatusEvent)webhookEvent;
            switch (deploymentStatusEvent.Action)
            {
                case DeploymentStatusActionValue.Created:
                    return this.ProcessDeploymentStatusWebhookAsync(headers, deploymentStatusEvent, DeploymentStatusAction.Created);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessDeploymentStatusWebhookAsync(WebhookHeaders headers, DeploymentStatusEvent deploymentStatusEvent, DeploymentStatusAction action) => Task.CompletedTask;

        private Task ProcessDiscussionWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var discussionEvent = (DiscussionEvent)webhookEvent;
            switch (discussionEvent.Action)
            {
                case DiscussionActionValue.Answered:
                    return this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Answered);
                case DiscussionActionValue.CategoryChanged:
                    return this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.CategoryChanged);
                case DiscussionActionValue.Created:
                    return this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Created);
                case DiscussionActionValue.Deleted:
                    return this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Deleted);
                case DiscussionActionValue.Edited:
                    return this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Edited);
                case DiscussionActionValue.Labeled:
                    return this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Labeled);
                case DiscussionActionValue.Locked:
                    return this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Locked);
                case DiscussionActionValue.Pinned:
                    return this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Pinned);
                case DiscussionActionValue.Transferred:
                    return this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Transferred);
                case DiscussionActionValue.Unanswered:
                    return this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Unanswered);
                case DiscussionActionValue.Unlabeled:
                    return this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Unlabeled);
                case DiscussionActionValue.Unlocked:
                    return this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Unlocked);
                case DiscussionActionValue.Unpinned:
                    return this.ProcessDiscussionWebhookAsync(headers, discussionEvent, DiscussionAction.Unpinned);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessDiscussionWebhookAsync(WebhookHeaders headers, DiscussionEvent discussionEvent, DiscussionAction action) => Task.CompletedTask;

        private Task ProcessDiscussionCommentWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var discussionCommentEvent = (DiscussionCommentEvent)webhookEvent;
            switch (discussionCommentEvent.Action)
            {
                case DiscussionCommentActionValue.Created:
                    return this.ProcessDiscussionCommentWebhookAsync(headers, discussionCommentEvent, DiscussionCommentAction.Created);
                case DiscussionCommentActionValue.Deleted:
                    return this.ProcessDiscussionCommentWebhookAsync(headers, discussionCommentEvent, DiscussionCommentAction.Deleted);
                case DiscussionCommentActionValue.Edited:
                    return this.ProcessDiscussionCommentWebhookAsync(headers, discussionCommentEvent, DiscussionCommentAction.Edited);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessDiscussionCommentWebhookAsync(WebhookHeaders headers, DiscussionCommentEvent discussionCommentEvent, DiscussionCommentAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessForkWebhookAsync(WebhookHeaders headers, ForkEvent forkEvent) => Task.CompletedTask;

        private Task ProcessGithubAppAuthorizationWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var githubAppAuthorizationEvent = (GithubAppAuthorizationEvent)webhookEvent;
            switch (githubAppAuthorizationEvent.Action)
            {
                case GithubAppAuthorizationActionValue.Revoked:
                    return this.ProcessGithubAppAuthorizationWebhookAsync(headers, githubAppAuthorizationEvent, GithubAppAuthorizationAction.Revoked);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessGithubAppAuthorizationWebhookAsync(WebhookHeaders headers, GithubAppAuthorizationEvent githubAppAuthorizationEvent, GithubAppAuthorizationAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessGollumWebhookAsync(WebhookHeaders headers, GollumEvent gollumEvent) => Task.CompletedTask;

        private Task ProcessInstallationWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var installationEvent = (InstallationEvent)webhookEvent;
            switch (installationEvent.Action)
            {
                case InstallationActionValue.Created:
                    return this.ProcessInstallationWebhookAsync(headers, installationEvent, InstallationAction.Created);
                case InstallationActionValue.Deleted:
                    return this.ProcessInstallationWebhookAsync(headers, installationEvent, InstallationAction.Deleted);
                case InstallationActionValue.NewPermissionsAccepted:
                    return this.ProcessInstallationWebhookAsync(headers, installationEvent, InstallationAction.NewPermissionsAccepted);
                case InstallationActionValue.Suspend:
                    return this.ProcessInstallationWebhookAsync(headers, installationEvent, InstallationAction.Suspend);
                case InstallationActionValue.Unsuspend:
                    return this.ProcessInstallationWebhookAsync(headers, installationEvent, InstallationAction.Unsuspend);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessInstallationWebhookAsync(WebhookHeaders headers, InstallationEvent installationEvent, InstallationAction action) => Task.CompletedTask;

        private Task ProcessInstallationRepositoriesWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var installationRepositoriesEvent = (InstallationRepositoriesEvent)webhookEvent;
            switch (installationRepositoriesEvent.Action)
            {
                case InstallationRepositoriesActionValue.Added:
                    return this.ProcessInstallationRepositoriesWebhookAsync(headers, installationRepositoriesEvent, InstallationRepositoriesAction.Added);
                case InstallationRepositoriesActionValue.Removed:
                    return this.ProcessInstallationRepositoriesWebhookAsync(headers, installationRepositoriesEvent, InstallationRepositoriesAction.Removed);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessInstallationRepositoriesWebhookAsync(WebhookHeaders headers, InstallationRepositoriesEvent installationRepositoriesEvent, InstallationRepositoriesAction action) => Task.CompletedTask;

        private Task ProcessIssueCommentWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var issueCommentEvent = (IssueCommentEvent)webhookEvent;
            switch (issueCommentEvent.Action)
            {
                case IssueCommentActionValue.Created:
                    return this.ProcessIssueCommentWebhookAsync(headers, issueCommentEvent, IssueCommentAction.Created);
                case IssueCommentActionValue.Deleted:
                    return this.ProcessIssueCommentWebhookAsync(headers, issueCommentEvent, IssueCommentAction.Deleted);
                case IssueCommentActionValue.Edited:
                    return this.ProcessIssueCommentWebhookAsync(headers, issueCommentEvent, IssueCommentAction.Edited);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessIssueCommentWebhookAsync(WebhookHeaders headers, IssueCommentEvent issueCommentEvent, IssueCommentAction action) => Task.CompletedTask;

        private Task ProcessIssuesWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var issuesEvent = (IssuesEvent)webhookEvent;
            switch (issuesEvent.Action)
            {
                case IssuesActionValue.Assigned:
                    return this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Assigned);
                case IssuesActionValue.Closed:
                    return this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Closed);
                case IssuesActionValue.Deleted:
                    return this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Deleted);
                case IssuesActionValue.Demilestoned:
                    return this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Demilestoned);
                case IssuesActionValue.Edited:
                    return this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Edited);
                case IssuesActionValue.Labeled:
                    return this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Labeled);
                case IssuesActionValue.Locked:
                    return this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Locked);
                case IssuesActionValue.Milestoned:
                    return this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Milestoned);
                case IssuesActionValue.Opened:
                    return this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Opened);
                case IssuesActionValue.Pinned:
                    return this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Pinned);
                case IssuesActionValue.Reopened:
                    return this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Reopened);
                case IssuesActionValue.Transferred:
                    return this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Transferred);
                case IssuesActionValue.Unassigned:
                    return this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Unassigned);
                case IssuesActionValue.Unlabeled:
                    return this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Unlabeled);
                case IssuesActionValue.Unlocked:
                    return this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Unlocked);
                case IssuesActionValue.Unpinned:
                    return this.ProcessIssuesWebhookAsync(headers, issuesEvent, IssuesAction.Unpinned);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessIssuesWebhookAsync(WebhookHeaders headers, IssuesEvent issuesEvent, IssuesAction action) => Task.CompletedTask;

        private Task ProcessLabelWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var labelEvent = (LabelEvent)webhookEvent;
            switch (labelEvent.Action)
            {
                case LabelActionValue.Created:
                    return this.ProcessLabelWebhookAsync(headers, labelEvent, LabelAction.Created);
                case LabelActionValue.Deleted:
                    return this.ProcessLabelWebhookAsync(headers, labelEvent, LabelAction.Deleted);
                case LabelActionValue.Edited:
                    return this.ProcessLabelWebhookAsync(headers, labelEvent, LabelAction.Edited);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessLabelWebhookAsync(WebhookHeaders headers, LabelEvent labelEvent, LabelAction action) => Task.CompletedTask;

        private Task ProcessMarketplacePurchaseWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var marketplacePurchaseEvent = (MarketplacePurchaseEvent)webhookEvent;
            switch (marketplacePurchaseEvent.Action)
            {
                case MarketplacePurchaseActionValue.Cancelled:
                    return this.ProcessMarketplacePurchaseWebhookAsync(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.Cancelled);
                case MarketplacePurchaseActionValue.Changed:
                    return this.ProcessMarketplacePurchaseWebhookAsync(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.Changed);
                case MarketplacePurchaseActionValue.PendingChange:
                    return this.ProcessMarketplacePurchaseWebhookAsync(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.PendingChange);
                case MarketplacePurchaseActionValue.PendingChangeCancelled:
                    return this.ProcessMarketplacePurchaseWebhookAsync(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.PendingChangeCancelled);
                case MarketplacePurchaseActionValue.Purchased:
                    return this.ProcessMarketplacePurchaseWebhookAsync(headers, marketplacePurchaseEvent, MarketplacePurchaseAction.Purchased);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessMarketplacePurchaseWebhookAsync(WebhookHeaders headers, MarketplacePurchaseEvent marketplacePurchaseEvent, MarketplacePurchaseAction action) => Task.CompletedTask;

        private Task ProcessMemberWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var memberEvent = (MemberEvent)webhookEvent;
            switch (memberEvent.Action)
            {
                case MemberActionValue.Added:
                    return this.ProcessMemberWebhookAsync(headers, memberEvent, MemberAction.Added);
                case MemberActionValue.Edited:
                    return this.ProcessMemberWebhookAsync(headers, memberEvent, MemberAction.Edited);
                case MemberActionValue.Removed:
                    return this.ProcessMemberWebhookAsync(headers, memberEvent, MemberAction.Removed);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessMemberWebhookAsync(WebhookHeaders headers, MemberEvent memberEvent, MemberAction action) => Task.CompletedTask;

        private Task ProcessMembershipWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var membershipEvent = (MembershipEvent)webhookEvent;
            switch (membershipEvent.Action)
            {
                case MembershipActionValue.Added:
                    return this.ProcessMembershipWebhookAsync(headers, membershipEvent, MembershipAction.Added);
                case MembershipActionValue.Removed:
                    return this.ProcessMembershipWebhookAsync(headers, membershipEvent, MembershipAction.Removed);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessMembershipWebhookAsync(WebhookHeaders headers, MembershipEvent membershipEvent, MembershipAction action) => Task.CompletedTask;

        private Task ProcessMetaWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var metaEvent = (MetaEvent)webhookEvent;
            switch (metaEvent.Action)
            {
                case MetaActionValue.Deleted:
                    return this.ProcessMetaWebhookAsync(headers, metaEvent, MetaAction.Deleted);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessMetaWebhookAsync(WebhookHeaders headers, MetaEvent metaEvent, MetaAction action) => Task.CompletedTask;

        private Task ProcessMilestoneWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var milestoneEvent = (MilestoneEvent)webhookEvent;
            switch (milestoneEvent.Action)
            {
                case MilestoneActionValue.Closed:
                    return this.ProcessMilestoneWebhookAsync(headers, milestoneEvent, MilestoneAction.Closed);
                case MilestoneActionValue.Created:
                    return this.ProcessMilestoneWebhookAsync(headers, milestoneEvent, MilestoneAction.Created);
                case MilestoneActionValue.Deleted:
                    return this.ProcessMilestoneWebhookAsync(headers, milestoneEvent, MilestoneAction.Deleted);
                case MilestoneActionValue.Edited:
                    return this.ProcessMilestoneWebhookAsync(headers, milestoneEvent, MilestoneAction.Edited);
                case MilestoneActionValue.Opened:
                    return this.ProcessMilestoneWebhookAsync(headers, milestoneEvent, MilestoneAction.Opened);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessMilestoneWebhookAsync(WebhookHeaders headers, MilestoneEvent milestoneEvent, MilestoneAction action) => Task.CompletedTask;

        private Task ProcessOrgBlockWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var orgBlockEvent = (OrgBlockEvent)webhookEvent;
            switch (orgBlockEvent.Action)
            {
                case OrgBlockActionValue.Blocked:
                    return this.ProcessOrgBlockWebhookAsync(headers, orgBlockEvent, OrgBlockAction.Blocked);
                case OrgBlockActionValue.Unblocked:
                    return this.ProcessOrgBlockWebhookAsync(headers, orgBlockEvent, OrgBlockAction.Unblocked);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessOrgBlockWebhookAsync(WebhookHeaders headers, OrgBlockEvent orgBlockEvent, OrgBlockAction action) => Task.CompletedTask;

        private Task ProcessOrganizationWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var organizationEvent = (OrganizationEvent)webhookEvent;
            switch (organizationEvent.Action)
            {
                case OrganizationActionValue.Deleted:
                    return this.ProcessOrganizationWebhookAsync(headers, organizationEvent, OrganizationAction.Deleted);
                case OrganizationActionValue.MemberAdded:
                    return this.ProcessOrganizationWebhookAsync(headers, organizationEvent, OrganizationAction.MemberAdded);
                case OrganizationActionValue.MemberInvited:
                    return this.ProcessOrganizationWebhookAsync(headers, organizationEvent, OrganizationAction.MemberInvited);
                case OrganizationActionValue.MemberRemoved:
                    return this.ProcessOrganizationWebhookAsync(headers, organizationEvent, OrganizationAction.MemberRemoved);
                case OrganizationActionValue.Renamed:
                    return this.ProcessOrganizationWebhookAsync(headers, organizationEvent, OrganizationAction.Renamed);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessOrganizationWebhookAsync(WebhookHeaders headers, OrganizationEvent organizationEvent, OrganizationAction action) => Task.CompletedTask;

        private Task ProcessPackageWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var packageEvent = (PackageEvent)webhookEvent;
            switch (packageEvent.Action)
            {
                case PackageActionValue.Published:
                    return this.ProcessPackageWebhookAsync(headers, packageEvent, PackageAction.Published);
                case PackageActionValue.Updated:
                    return this.ProcessPackageWebhookAsync(headers, packageEvent, PackageAction.Updated);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessPackageWebhookAsync(WebhookHeaders headers, PackageEvent packageEvent, PackageAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessPageBuildWebhookAsync(WebhookHeaders headers, PageBuildEvent pageBuildEvent) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessPingWebhookAsync(WebhookHeaders headers, PingEvent pingEvent) => Task.CompletedTask;

        private Task ProcessProjectWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var projectEvent = (ProjectEvent)webhookEvent;
            switch (projectEvent.Action)
            {
                case ProjectActionValue.Closed:
                    return this.ProcessProjectWebhookAsync(headers, projectEvent, ProjectAction.Closed);
                case ProjectActionValue.Created:
                    return this.ProcessProjectWebhookAsync(headers, projectEvent, ProjectAction.Created);
                case ProjectActionValue.Deleted:
                    return this.ProcessProjectWebhookAsync(headers, projectEvent, ProjectAction.Deleted);
                case ProjectActionValue.Edited:
                    return this.ProcessProjectWebhookAsync(headers, projectEvent, ProjectAction.Edited);
                case ProjectActionValue.Reopened:
                    return this.ProcessProjectWebhookAsync(headers, projectEvent, ProjectAction.Reopened);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessProjectWebhookAsync(WebhookHeaders headers, ProjectEvent projectEvent, ProjectAction action) => Task.CompletedTask;

        private Task ProcessProjectCardWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var projectCardEvent = (ProjectCardEvent)webhookEvent;
            switch (projectCardEvent.Action)
            {
                case ProjectCardActionValue.Converted:
                    return this.ProcessProjectCardWebhookAsync(headers, projectCardEvent, ProjectCardAction.Converted);
                case ProjectCardActionValue.Created:
                    return this.ProcessProjectCardWebhookAsync(headers, projectCardEvent, ProjectCardAction.Created);
                case ProjectCardActionValue.Deleted:
                    return this.ProcessProjectCardWebhookAsync(headers, projectCardEvent, ProjectCardAction.Deleted);
                case ProjectCardActionValue.Edited:
                    return this.ProcessProjectCardWebhookAsync(headers, projectCardEvent, ProjectCardAction.Edited);
                case ProjectCardActionValue.Moved:
                    return this.ProcessProjectCardWebhookAsync(headers, projectCardEvent, ProjectCardAction.Moved);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessProjectCardWebhookAsync(WebhookHeaders headers, ProjectCardEvent projectCardEvent, ProjectCardAction action) => Task.CompletedTask;

        private Task ProcessProjectColumnWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var projectColumnEvent = (ProjectColumnEvent)webhookEvent;
            switch (projectColumnEvent.Action)
            {
                case ProjectColumnActionValue.Created:
                    return this.ProcessProjectColumnWebhookAsync(headers, projectColumnEvent, ProjectColumnAction.Created);
                case ProjectColumnActionValue.Deleted:
                    return this.ProcessProjectColumnWebhookAsync(headers, projectColumnEvent, ProjectColumnAction.Deleted);
                case ProjectColumnActionValue.Edited:
                    return this.ProcessProjectColumnWebhookAsync(headers, projectColumnEvent, ProjectColumnAction.Edited);
                case ProjectColumnActionValue.Moved:
                    return this.ProcessProjectColumnWebhookAsync(headers, projectColumnEvent, ProjectColumnAction.Moved);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessProjectColumnWebhookAsync(WebhookHeaders headers, ProjectColumnEvent projectColumnEvent, ProjectColumnAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessPublicWebhookAsync(WebhookHeaders headers, PublicEvent publicEvent) => Task.CompletedTask;

        private Task ProcessPullRequestWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var pullRequestEvent = (PullRequestEvent)webhookEvent;
            switch (pullRequestEvent.Action)
            {
                case PullRequestActionValue.Assigned:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Assigned);
                case PullRequestActionValue.AutoMergeDisabled:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.AutoMergeDisabled);
                case PullRequestActionValue.AutoMergeEnabled:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.AutoMergeEnabled);
                case PullRequestActionValue.Closed:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Closed);
                case PullRequestActionValue.ConvertedToDraft:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.ConvertedToDraft);
                case PullRequestActionValue.Edited:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Edited);
                case PullRequestActionValue.Labeled:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Labeled);
                case PullRequestActionValue.Locked:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Locked);
                case PullRequestActionValue.Opened:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Opened);
                case PullRequestActionValue.ReadyForReview:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.ReadyForReview);
                case PullRequestActionValue.Reopened:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Reopened);
                case PullRequestActionValue.ReviewRequestRemoved:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.ReviewRequestRemoved);
                case PullRequestActionValue.ReviewRequested:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.ReviewRequested);
                case PullRequestActionValue.Synchronize:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Synchronize);
                case PullRequestActionValue.Unassigned:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Unassigned);
                case PullRequestActionValue.Unlabeled:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Unlabeled);
                case PullRequestActionValue.Unlocked:
                    return this.ProcessPullRequestWebhookAsync(headers, pullRequestEvent, PullRequestAction.Unlocked);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessPullRequestWebhookAsync(WebhookHeaders headers, PullRequestEvent pullRequestEvent, PullRequestAction action) => Task.CompletedTask;

        private Task ProcessPullRequestReviewWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var pullRequestReviewEvent = (PullRequestReviewEvent)webhookEvent;
            switch (pullRequestReviewEvent.Action)
            {
                case PullRequestReviewActionValue.Dismissed:
                    return this.ProcessPullRequestReviewWebhookAsync(headers, pullRequestReviewEvent, PullRequestReviewAction.Dismissed);
                case PullRequestReviewActionValue.Edited:
                    return this.ProcessPullRequestReviewWebhookAsync(headers, pullRequestReviewEvent, PullRequestReviewAction.Edited);
                case PullRequestReviewActionValue.Submitted:
                    return this.ProcessPullRequestReviewWebhookAsync(headers, pullRequestReviewEvent, PullRequestReviewAction.Submitted);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessPullRequestReviewWebhookAsync(WebhookHeaders headers, PullRequestReviewEvent pullRequestReviewEvent, PullRequestReviewAction action) => Task.CompletedTask;

        private Task ProcessPullRequestReviewCommentWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var pullRequestReviewCommentEvent = (PullRequestReviewCommentEvent)webhookEvent;
            switch (pullRequestReviewCommentEvent.Action)
            {
                case PullRequestReviewCommentActionValue.Created:
                    return this.ProcessPullRequestReviewCommentWebhookAsync(headers, pullRequestReviewCommentEvent, PullRequestReviewCommentAction.Created);
                case PullRequestReviewCommentActionValue.Deleted:
                    return this.ProcessPullRequestReviewCommentWebhookAsync(headers, pullRequestReviewCommentEvent, PullRequestReviewCommentAction.Deleted);
                case PullRequestReviewCommentActionValue.Edited:
                    return this.ProcessPullRequestReviewCommentWebhookAsync(headers, pullRequestReviewCommentEvent, PullRequestReviewCommentAction.Edited);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessPullRequestReviewCommentWebhookAsync(WebhookHeaders headers, PullRequestReviewCommentEvent pullRequestReviewCommentEvent, PullRequestReviewCommentAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessPushWebhookAsync(WebhookHeaders headers, PushEvent pushEvent) => Task.CompletedTask;

        private Task ProcessReleaseWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var releaseEvent = (ReleaseEvent)webhookEvent;
            switch (releaseEvent.Action)
            {
                case ReleaseActionValue.Created:
                    return this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Created);
                case ReleaseActionValue.Deleted:
                    return this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Deleted);
                case ReleaseActionValue.Edited:
                    return this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Edited);
                case ReleaseActionValue.Prereleased:
                    return this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Prereleased);
                case ReleaseActionValue.Published:
                    return this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Published);
                case ReleaseActionValue.Released:
                    return this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Released);
                case ReleaseActionValue.Unpublished:
                    return this.ProcessReleaseWebhookAsync(headers, releaseEvent, ReleaseAction.Unpublished);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessReleaseWebhookAsync(WebhookHeaders headers, ReleaseEvent releaseEvent, ReleaseAction action) => Task.CompletedTask;

        private Task ProcessRepositoryWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var repositoryEvent = (RepositoryEvent)webhookEvent;
            switch (repositoryEvent.Action)
            {
                case RepositoryActionValue.Archived:
                    return this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Archived);
                case RepositoryActionValue.Created:
                    return this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Created);
                case RepositoryActionValue.Deleted:
                    return this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Deleted);
                case RepositoryActionValue.Edited:
                    return this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Edited);
                case RepositoryActionValue.Privatized:
                    return this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Privatized);
                case RepositoryActionValue.Publicized:
                    return this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Publicized);
                case RepositoryActionValue.Renamed:
                    return this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Renamed);
                case RepositoryActionValue.Transferred:
                    return this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Transferred);
                case RepositoryActionValue.Unarchived:
                    return this.ProcessRepositoryWebhookAsync(headers, repositoryEvent, RepositoryAction.Unarchived);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessRepositoryWebhookAsync(WebhookHeaders headers, RepositoryEvent repositoryEvent, RepositoryAction action) => Task.CompletedTask;

        private Task ProcessRepositoryDispatchWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var repositoryDispatchEvent = (RepositoryDispatchEvent)webhookEvent;
            switch (repositoryDispatchEvent.Action)
            {
                case RepositoryDispatchActionValue.OnDemandTest:
                    return this.ProcessRepositoryDispatchWebhookAsync(headers, repositoryDispatchEvent, RepositoryDispatchAction.OnDemandTest);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessRepositoryDispatchWebhookAsync(WebhookHeaders headers, RepositoryDispatchEvent repositoryDispatchEvent, RepositoryDispatchAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessRepositoryImportWebhookAsync(WebhookHeaders headers, RepositoryImportEvent repositoryImportEvent) => Task.CompletedTask;

        private Task ProcessRepositoryVulnerabilityAlertWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var repositoryVulnerabilityAlertEvent = (RepositoryVulnerabilityAlertEvent)webhookEvent;
            switch (repositoryVulnerabilityAlertEvent.Action)
            {
                case RepositoryVulnerabilityAlertActionValue.Create:
                    return this.ProcessRepositoryVulnerabilityAlertWebhookAsync(headers, repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction.Create);
                case RepositoryVulnerabilityAlertActionValue.Dismiss:
                    return this.ProcessRepositoryVulnerabilityAlertWebhookAsync(headers, repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction.Dismiss);
                case RepositoryVulnerabilityAlertActionValue.Resolve:
                    return this.ProcessRepositoryVulnerabilityAlertWebhookAsync(headers, repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction.Resolve);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessRepositoryVulnerabilityAlertWebhookAsync(WebhookHeaders headers, RepositoryVulnerabilityAlertEvent repositoryVulnerabilityAlertEvent, RepositoryVulnerabilityAlertAction action) => Task.CompletedTask;

        private Task ProcessSecretScanningAlertWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var secretScanningAlertEvent = (SecretScanningAlertEvent)webhookEvent;
            switch (secretScanningAlertEvent.Action)
            {
                case SecretScanningAlertActionValue.Created:
                    return this.ProcessSecretScanningAlertWebhookAsync(headers, secretScanningAlertEvent, SecretScanningAlertAction.Created);
                case SecretScanningAlertActionValue.Reopened:
                    return this.ProcessSecretScanningAlertWebhookAsync(headers, secretScanningAlertEvent, SecretScanningAlertAction.Reopened);
                case SecretScanningAlertActionValue.Resolved:
                    return this.ProcessSecretScanningAlertWebhookAsync(headers, secretScanningAlertEvent, SecretScanningAlertAction.Resolved);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessSecretScanningAlertWebhookAsync(WebhookHeaders headers, SecretScanningAlertEvent secretScanningAlertEvent, SecretScanningAlertAction action) => Task.CompletedTask;

        private Task ProcessSecurityAdvisoryWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var securityAdvisoryEvent = (SecurityAdvisoryEvent)webhookEvent;
            switch (securityAdvisoryEvent.Action)
            {
                case SecurityAdvisoryActionValue.Performed:
                    return this.ProcessSecurityAdvisoryWebhookAsync(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Performed);
                case SecurityAdvisoryActionValue.Published:
                    return this.ProcessSecurityAdvisoryWebhookAsync(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Published);
                case SecurityAdvisoryActionValue.Updated:
                    return this.ProcessSecurityAdvisoryWebhookAsync(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Updated);
                case SecurityAdvisoryActionValue.Withdrawn:
                    return this.ProcessSecurityAdvisoryWebhookAsync(headers, securityAdvisoryEvent, SecurityAdvisoryAction.Withdrawn);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessSecurityAdvisoryWebhookAsync(WebhookHeaders headers, SecurityAdvisoryEvent securityAdvisoryEvent, SecurityAdvisoryAction action) => Task.CompletedTask;

        private Task ProcessSponsorshipWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var sponsorshipEvent = (SponsorshipEvent)webhookEvent;
            switch (sponsorshipEvent.Action)
            {
                case SponsorshipActionValue.Cancelled:
                    return this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.Cancelled);
                case SponsorshipActionValue.Created:
                    return this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.Created);
                case SponsorshipActionValue.Edited:
                    return this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.Edited);
                case SponsorshipActionValue.PendingCancellation:
                    return this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.PendingCancellation);
                case SponsorshipActionValue.PendingTierChange:
                    return this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.PendingTierChange);
                case SponsorshipActionValue.TierChanged:
                    return this.ProcessSponsorshipWebhookAsync(headers, sponsorshipEvent, SponsorshipAction.TierChanged);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessSponsorshipWebhookAsync(WebhookHeaders headers, SponsorshipEvent sponsorshipEvent, SponsorshipAction action) => Task.CompletedTask;

        private Task ProcessStarWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var starEvent = (StarEvent)webhookEvent;
            switch (starEvent.Action)
            {
                case StarActionValue.Created:
                    return this.ProcessStarWebhookAsync(headers, starEvent, StarAction.Created);
                case StarActionValue.Deleted:
                    return this.ProcessStarWebhookAsync(headers, starEvent, StarAction.Deleted);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessStarWebhookAsync(WebhookHeaders headers, StarEvent starEvent, StarAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessStatusWebhookAsync(WebhookHeaders headers, StatusEvent statusEvent) => Task.CompletedTask;

        private Task ProcessTeamWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var teamEvent = (TeamEvent)webhookEvent;
            switch (teamEvent.Action)
            {
                case TeamActionValue.AddedToRepository:
                    return this.ProcessTeamWebhookAsync(headers, teamEvent, TeamAction.AddedToRepository);
                case TeamActionValue.Created:
                    return this.ProcessTeamWebhookAsync(headers, teamEvent, TeamAction.Created);
                case TeamActionValue.Deleted:
                    return this.ProcessTeamWebhookAsync(headers, teamEvent, TeamAction.Deleted);
                case TeamActionValue.Edited:
                    return this.ProcessTeamWebhookAsync(headers, teamEvent, TeamAction.Edited);
                case TeamActionValue.RemovedFromRepository:
                    return this.ProcessTeamWebhookAsync(headers, teamEvent, TeamAction.RemovedFromRepository);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessTeamWebhookAsync(WebhookHeaders headers, TeamEvent teamEvent, TeamAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessTeamAddWebhookAsync(WebhookHeaders headers, TeamAddEvent teamAddEvent) => Task.CompletedTask;

        private Task ProcessWatchWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var watchEvent = (WatchEvent)webhookEvent;
            switch (watchEvent.Action)
            {
                case WatchActionValue.Started:
                    return this.ProcessWatchWebhookAsync(headers, watchEvent, WatchAction.Started);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessWatchWebhookAsync(WebhookHeaders headers, WatchEvent watchEvent, WatchAction action) => Task.CompletedTask;

        [PublicAPI]
        protected virtual Task ProcessWorkflowDispatchWebhookAsync(WebhookHeaders headers, WorkflowDispatchEvent workflowDispatchEvent) => Task.CompletedTask;

        private Task ProcessWorkflowJobWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var workflowJobEvent = (WorkflowJobEvent)webhookEvent;
            switch (workflowJobEvent.Action)
            {
                case WorkflowJobActionValue.Completed:
                    return this.ProcessWorkflowJobWebhookAsync(headers, workflowJobEvent, WorkflowJobAction.Completed);
                case WorkflowJobActionValue.Started:
                    return this.ProcessWorkflowJobWebhookAsync(headers, workflowJobEvent, WorkflowJobAction.Started);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessWorkflowJobWebhookAsync(WebhookHeaders headers, WorkflowJobEvent workflowJobEvent, WorkflowJobAction action) => Task.CompletedTask;

        private Task ProcessWorkflowRunWebhookAsync(WebhookHeaders headers, WebhookEvent webhookEvent)
        {
            var workflowRunEvent = (WorkflowRunEvent)webhookEvent;
            switch (workflowRunEvent.Action)
            {
                case WorkflowRunActionValue.Completed:
                    return this.ProcessWorkflowRunWebhookAsync(headers, workflowRunEvent, WorkflowRunAction.Completed);
                case WorkflowRunActionValue.Requested:
                    return this.ProcessWorkflowRunWebhookAsync(headers, workflowRunEvent, WorkflowRunAction.Requested);
            }

            return Task.CompletedTask;
        }

        [PublicAPI]
        protected virtual Task ProcessWorkflowRunWebhookAsync(WebhookHeaders headers, WorkflowRunEvent workflowRunEvent, WorkflowRunAction action) => Task.CompletedTask;
    }
}
