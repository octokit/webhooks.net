namespace Octokit.Webhooks.Test
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using CaseExtensions;
    using Octokit.Webhooks.TestUtils;

    public class WebhookEventProcessorTestsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var resourcesDirectory = ResourceUtils.GetResources();
            var files = Directory.GetFiles(resourcesDirectory, "*.json", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var relativeResource = file.Replace($"{resourcesDirectory}{Path.DirectorySeparatorChar}", string.Empty);
                var parts = relativeResource.Split(Path.DirectorySeparatorChar);
                var headers = new WebhookHeaders
                {
                    Event = parts[0],
                };
                var expectedType = ClassUtils.GetEventTypeByName(parts[0].ToPascalCase());
                var content = ResourceUtils.ReadResource(relativeResource);
                yield return new object[]
                {
                    headers,
                    content,
                    expectedType,
                };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
