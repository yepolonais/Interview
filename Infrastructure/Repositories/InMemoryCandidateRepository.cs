using Interview.Application.Interfaces;
using Interview.Domain.Entities;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Infrastructure.Repositories;

public sealed class InMemoryCandidateRepository : ICandidateRepository
{
    private readonly ConcurrentDictionary<System.Guid, Candidate> _store = new();

    public Task AddAsync(Candidate candidate)
    {
        _store[candidate.Id] = candidate;
        return Task.CompletedTask;
    }

    public Task<Candidate?> GetByIdAsync(System.Guid id)
    {
        _store.TryGetValue(id, out Candidate? candidate);
        return Task.FromResult(candidate);
    }

    public Task<IReadOnlyCollection<Candidate>> ListAllAsync()
    {
        IReadOnlyCollection<Candidate> list = _store.Values.ToArray();
        return Task.FromResult(list);
    }
}
