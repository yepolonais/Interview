using Interview.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interview.Application.Interfaces;

public interface ICandidateRepository
{
    Task AddAsync(Candidate candidate);
    Task<Candidate?> GetByIdAsync(System.Guid id);
    Task<IReadOnlyCollection<Candidate>> ListAllAsync();
}
