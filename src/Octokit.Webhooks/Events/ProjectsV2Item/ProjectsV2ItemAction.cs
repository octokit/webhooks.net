namespace Octokit.Webhooks.Events.ProjectsV2Item;

[PublicAPI]
public sealed record ProjectsV2ItemAction : WebhookEventAction
{
    public static readonly ProjectsV2ItemAction Archived = new(ProjectsV2ItemActionValue.Archived);

    public static readonly ProjectsV2ItemAction Converted = new(ProjectsV2ItemActionValue.Converted);

    public static readonly ProjectsV2ItemAction Created = new(ProjectsV2ItemActionValue.Created);

    public static readonly ProjectsV2ItemAction Deleted = new(ProjectsV2ItemActionValue.Deleted);

    public static readonly ProjectsV2ItemAction Edited = new(ProjectsV2ItemActionValue.Edited);

    public static readonly ProjectsV2ItemAction Reordered = new(ProjectsV2ItemActionValue.Reordered);

    public static readonly ProjectsV2ItemAction Restored = new(ProjectsV2ItemActionValue.Restored);

    private ProjectsV2ItemAction(string value)
        : base(value)
    {
    }
}
