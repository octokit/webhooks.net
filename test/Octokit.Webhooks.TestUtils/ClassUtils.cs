namespace Octokit.Webhooks.TestUtils;

using System;
using System.Linq;
using System.Reflection;

public static class ClassUtils
{
    public static Type GetEventTypeByName(string name) => Assembly.Load("Octokit.Webhooks")
        .GetTypes()
        .Single(t =>
            t.FullName!.StartsWith("Octokit.Webhooks.Events.", StringComparison.OrdinalIgnoreCase) &&
            t.Name == $"{name}Event");
}
