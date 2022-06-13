namespace Octokit.Webhooks.TestUtils;

using System;
using System.IO;
using System.Reflection;

public static class ResourceUtils
{
    public static string GetResources()
    {
        var baseUrl = new Uri(Assembly.GetExecutingAssembly().Location);
        var basePath = Uri.UnescapeDataString(baseUrl.AbsolutePath);
        var dirPath = Path.GetDirectoryName(basePath);
        return Path.Combine(dirPath!, "Resources");
    }

    public static string ReadResource(string relativePath) => File.ReadAllText(GetResourcePath(relativePath));

    private static string GetResourcePath(string relativePath) => Path.Combine(GetResources(), relativePath);
}
