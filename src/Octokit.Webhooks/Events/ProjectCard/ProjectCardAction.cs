namespace Octokit.Webhooks.Events.ProjectCard;

[PublicAPI]
public sealed record ProjectCardAction : WebhookEventAction
{
    public static readonly ProjectCardAction Converted = new(ProjectCardActionValue.Converted);

    public static readonly ProjectCardAction Created = new(ProjectCardActionValue.Created);

    public static readonly ProjectCardAction Deleted = new(ProjectCardActionValue.Deleted);

    public static readonly ProjectCardAction Edited = new(ProjectCardActionValue.Edited);

    public static readonly ProjectCardAction Moved = new(ProjectCardActionValue.Moved);

    private ProjectCardAction(string value)
        : base(value)
    {
    }
}
