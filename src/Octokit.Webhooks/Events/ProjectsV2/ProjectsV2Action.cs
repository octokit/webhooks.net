namespace Octokit.Webhooks.Events.ProjectsV2;

[PublicAPI]
public sealed record ProjectsV2Action : WebhookEventAction
{
    public static readonly ProjectsV2Action Closed = new(ProjectsV2ActionValue.Closed);

    public static readonly ProjectsV2Action Created = new(ProjectsV2ActionValue.Created);

    public static readonly ProjectsV2Action Deleted = new(ProjectsV2ActionValue.Deleted);

    public static readonly ProjectsV2Action Edited = new(ProjectsV2ActionValue.Edited);

    public static readonly ProjectsV2Action Reopened = new(ProjectsV2ActionValue.Reopened);

    private ProjectsV2Action(string value)
        : base(value)
    {
    }
}
