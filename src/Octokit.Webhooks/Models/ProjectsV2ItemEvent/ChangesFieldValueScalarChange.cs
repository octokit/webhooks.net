namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[PublicAPI]
public sealed record ChangesFieldValueScalarChange : ChangesFieldValueChangeBase
{
    public string? StringValue { get; init; }

    public decimal? NumericValue { get; init; }
}
