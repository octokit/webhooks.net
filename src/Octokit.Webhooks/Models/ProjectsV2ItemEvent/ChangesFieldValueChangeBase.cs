namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[JsonConverter(typeof(ChangesFieldValueChangeConverter))]
public abstract record ChangesFieldValueChangeBase
{
}
