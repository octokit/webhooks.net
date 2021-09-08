namespace JamieMagee.Octokit.Webhooks.Test
{
    using System;
    using System.IO;
    using CaseExtensions;
    using Xunit;

    public abstract class BaseData : TheoryData<FileStream, Type>
    {
        protected BaseData()
        {
            var type = this.GetType().Name;
            var directory = type[..^4].ToSnakeCase();
            foreach (var samplePath in Directory.EnumerateFiles($"Resources{Path.DirectorySeparatorChar}{directory}"))
            {
                var eventTypeSuffix = samplePath.Split(Path.DirectorySeparatorChar)[^1].Split('.')[0];
                var eventType = typeof(WebhookEvent).Assembly.GetType(
                        $"{typeof(WebhookEvent).Assembly.GetName().Name}.Events.{directory.ToPascalCase()}.{directory.ToPascalCase()}{eventTypeSuffix.ToPascalCase()}Event")
                    !;
                var stream = File.OpenRead(samplePath);
                this.Add(stream, eventType);
            }
        }
    }
}
