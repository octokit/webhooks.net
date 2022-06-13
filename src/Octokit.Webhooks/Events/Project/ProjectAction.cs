namespace Octokit.Webhooks.Events.Project;

using JetBrains.Annotations;

[PublicAPI]
public sealed record ProjectAction : WebhookEventAction
{
    public static readonly ProjectAction Closed = new(ProjectActionValue.Closed);

    public static readonly ProjectAction Created = new(ProjectActionValue.Created);

    public static readonly ProjectAction Deleted = new(ProjectActionValue.Deleted);

    public static readonly ProjectAction Edited = new(ProjectActionValue.Edited);

    public static readonly ProjectAction Reopened = new(ProjectActionValue.Reopened);

    private ProjectAction(string value)
        : base(value)
    {
    }
}
