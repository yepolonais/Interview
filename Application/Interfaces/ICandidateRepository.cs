using Interview.Domain.Entities;

namespace Interview.Application.Interfaces;

public interface ICandidateRepository
{
    Task AddAsync(Candidate candidate);
    Task<Candidate?> GetByIdAsync(System.Guid id);
    Task<IReadOnlyCollection<Candidate>> ListAllAsync();
}
