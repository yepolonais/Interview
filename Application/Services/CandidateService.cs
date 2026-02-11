using Interview.Application.DTOs;
using Interview.Application.Interfaces;
using Interview.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Application.Services;

public sealed class CandidateService
{
    private readonly ICandidateRepository _repository;

    public CandidateService(ICandidateRepository repository)
    {
        _repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
    }

    public async Task AddCandidateAsync(CandidateDto dto)
    {
        Candidate candidate = new Candidate(dto.Id, dto.Name);
        await _repository.AddAsync(candidate);
    }

    public async Task<CandidateDto?> GetCandidateAsync(System.Guid id)
    {
        Candidate? candidate = await _repository.GetByIdAsync(id);
        if (candidate == null) return null;
        return new CandidateDto(candidate.Id, candidate.Name);
    }

    public async Task<IReadOnlyCollection<CandidateDto>> ListCandidatesAsync()
    {
        IReadOnlyCollection<Candidate> list = await _repository.ListAllAsync();
        return list.Select(c => new CandidateDto(c.Id, c.Name)).ToArray();
    }
}
