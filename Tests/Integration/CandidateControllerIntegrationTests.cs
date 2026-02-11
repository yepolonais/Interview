using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Interview.Tests.Integration;

public sealed class CandidateControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public CandidateControllerIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task BuggyEndpoint_ReturnsOk()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/candidate/buggy");

        // This assertion is intentionally incorrect: the endpoint currently throws and returns 500.
        // Candidates should fix the endpoint so this test passes.
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
