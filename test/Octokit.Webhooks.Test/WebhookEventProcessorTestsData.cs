namespace Octokit.Webhooks.Test;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using CaseExtensions;
using Octokit.Webhooks.TestUtils;
using Xunit;

public class WebhookEventProcessorTestsData : IEnumerable<TheoryDataRow<string, string, Type>>
{
    public IEnumerator<TheoryDataRow<string, string, Type>> GetEnumerator()
    {
        var resourcesDirectory = ResourceUtils.GetResources();
        var files = Directory.GetFiles(resourcesDirectory, "*.json", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            var relativeResource = file.Replace($"{resourcesDirectory}{Path.DirectorySeparatorChar}", string.Empty);
            var parts = relativeResource.Split(Path.DirectorySeparatorChar);
            var expectedType = ClassUtils.GetEventTypeByName(parts[0].ToPascalCase());
            var content = ResourceUtils.ReadResource(relativeResource);
            yield return new TheoryDataRow<string, string, Type>(parts[0], content, expectedType);
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
