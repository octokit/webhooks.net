namespace JamieMagee.Octokit.Webhooks.Test
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;
    using JamieMagee.Octokit.Webhooks.Test.Data;
    using Xunit;

    public class CheckRunTests
    {
        [Theory]
        [ClassData(typeof(CheckRunData))]
        public async Task CheckRunEvent(FileStream stream, Type type)
        {
            var @event = await JsonSerializer.DeserializeAsync(stream, type);

            Assert.IsType(type, @event);
            Assert.NotNull(@event);
        }
    }
}
