namespace Octokit.Webhooks.Test
{
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Events.PullRequest;
    using Xunit;

    public class PullRequestTests
    {
        [Fact]
        public async Task PullRequestEvent_Created()
        {
            var assigned = File.OpenRead("Resources/pull_request/assigned.payload.json");
            var @event = await JsonSerializer.DeserializeAsync<PullRequestAssignedEvent>(assigned);
            Assert.NotNull(@event);
        }
    }
}
