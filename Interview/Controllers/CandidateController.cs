using Interview.Application.DTOs;
using Interview.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interview.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CandidateController(CandidateService service) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Create(CandidateDto dto)
    {
        await service.AddCandidateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var list = await service.ListCandidatesAsync();
        return Ok(list);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(System.Guid id)
    {
        if (id == System.Guid.Empty)
        {
            throw new System.InvalidOperationException("Invalid id provided");
        }

        var candidate = await service.GetCandidateAsync(id);
        if (candidate == null) return NotFound();
        return Ok(candidate);
    }

    [HttpGet("buggy")]
    public IActionResult Buggy()
    {
        string? maybe = null;
        return Ok(maybe!.ToString());
    }
}
