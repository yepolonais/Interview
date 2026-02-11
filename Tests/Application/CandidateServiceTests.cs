using Interview.Application.DTOs;
using Interview.Application.Services;
using Interview.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Interview.Tests.Application;

public sealed class CandidateServiceTests
{
    [Fact]
    public async Task AddAndGetCandidate_ReturnsCandidate()
    {
        var repository = new InMemoryCandidateRepository();
        var service = new CandidateService(repository);

        var id = Guid.NewGuid();
        var dto = new CandidateDto(id, "Alice");

        await service.AddCandidateAsync(dto);

        var fetched = await service.GetCandidateAsync(id);

        Assert.NotNull(fetched);
        Assert.Equal("Alice", fetched!.Name);
    }
}
