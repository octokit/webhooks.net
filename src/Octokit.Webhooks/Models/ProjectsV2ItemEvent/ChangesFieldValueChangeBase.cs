namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[JsonConverter(typeof(ChangesFieldValueChangeConverter))]
[PublicAPI]
public abstract record ChangesFieldValueChangeBase
{
}
