using Interview.Application.DTOs;
using Interview.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interview.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CandidateController : ControllerBase
{
    private readonly CandidateService _service;

    public CandidateController(CandidateService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CandidateDto dto)
    {
        await _service.AddCandidateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var list = await _service.ListCandidatesAsync();
        return Ok(list);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(System.Guid id)
    {
        // Intentional bug: this throws when id is Guid.Empty to simulate a runtime error
        if (id == System.Guid.Empty)
        {
            throw new System.InvalidOperationException("Invalid id provided");
        }

        var candidate = await _service.GetCandidateAsync(id);
        if (candidate == null) return NotFound();
        return Ok(candidate);
    }

    [HttpGet("buggy")]
    public IActionResult Buggy()
    {
        // Deliberate runtime exception for the candidate to find and fix during the interview
        string? maybe = null;
        return Ok(maybe!.ToString());
    }
}
