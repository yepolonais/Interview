## Notes for the interviewer
- No minimal APIs or MediatR are used; the codebase follows explicit DI and clean layering.
- The in-memory repository (`Infrastructure/Repositories/InMemoryCandidateRepository.cs`) implements the async ports synchronously using `Task.FromResult` / `Task.CompletedTask`.
- Encourage candidates to write or update tests if they wish; the solution includes `WebApplicationFactory<Program>` test support.

If you want, I can also add a short checklist for grading or create additional buggy items.

**Interviewer Checklist**

- **Setup (5 min)**: Candidate clones, runs `dotnet restore` and `dotnet run` for the `Interview` project; opens Swagger.
- **Reproduction (2 min)**: Candidate reproduces the failing behavior on `GET /api/candidate/buggy` and runs `dotnet test`.
- **Fix (15 min)**: Candidate proposes and implements a minimal, correct fix; updates or adds tests if needed.
- **Verify (3 min)**: Run `dotnet test` to ensure all tests pass.
- **Discussion (5 min)**: Candidate explains the fix, trade-offs, and suggests improvements (logging, input validation, error handling, integration tests).

**Scoring guidance**
- **Junior**: Reproduces issue, applies a simple fix, runs tests (basic correctness).
- **Senior**: Explains root cause, writes/updates tests, ensures layering and DI remain correct.
- **Expert**: Suggests improvements to architecture, adds robust test cases, and discusses production concerns (observability, resilience).

Record the candidate's time spent on each phase and any follow-up items to assign as homework.