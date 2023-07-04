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

    public static string GetExtensibilityResources()
    {
        var baseUrl = new Uri(Assembly.GetExecutingAssembly().Location);
        var basePath = Uri.UnescapeDataString(baseUrl.AbsolutePath);
        var dirPath = Path.GetDirectoryName(basePath);
        return Path.Combine(dirPath!, "Extensibility", "Resources");
    }

    public static string ReadResource(string relativePath) => File.ReadAllText(GetResourcePath(relativePath));

    public static string ReadExtensibilityResource(string relativePath) => File.ReadAllText(GetExtensibilityResourcePath(relativePath));

    private static string GetResourcePath(string relativePath) => Path.Combine(GetResources(), relativePath);

    private static string GetExtensibilityResourcePath(string relativePath) => Path.Combine(GetExtensibilityResources(), relativePath);
}
