namespace Octokit.Webhooks.Events.ProjectsV2Project;

[PublicAPI]
public sealed record ProjectsV2ProjectAction : WebhookEventAction
{
    public static readonly ProjectsV2ProjectAction Closed = new(ProjectsV2ProjectActionValue.Closed);

    public static readonly ProjectsV2ProjectAction Created = new(ProjectsV2ProjectActionValue.Created);

    public static readonly ProjectsV2ProjectAction Deleted = new(ProjectsV2ProjectActionValue.Deleted);

    public static readonly ProjectsV2ProjectAction Edited = new(ProjectsV2ProjectActionValue.Edited);

    public static readonly ProjectsV2ProjectAction Reopened = new(ProjectsV2ProjectActionValue.Reopened);

    private ProjectsV2ProjectAction(string value)
        : base(value)
    {
    }
}
