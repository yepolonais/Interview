# Interview assessment scaffold

This repository is a minimal .NET 9 Clean Architecture scaffold intended for a 30-minute coding exercise.

**Contents**
- `Domain` — entities, value objects, domain exceptions
- `Application` — use cases, DTOs, ports (interfaces)
- `Infrastructure` — repository implementations (in-memory), adapters
- `Interview` — API project (controllers, DI, OpenAPI)
- `Tests` — xUnit unit + integration tests

**Intentional exercise elements**
- A deliberately buggy endpoint: `GET /api/candidate/buggy` in `Interview/Controllers/CandidateController.cs`.
- A failing integration test targeting that endpoint: `Tests/Integration/CandidateControllerIntegrationTests.cs`.

These are provided so a candidate can spend ~15 minutes debugging and fixing the behavior, then run tests.

## Prerequisites
- .NET 9 SDK installed

## Build
From repository root:

```bash
dotnet restore
dotnet build -c Debug
```

## Run API
Run the API project:

```bash
cd Interview
dotnet run
```

By default the app exposes controllers and OpenAPI (Swagger) in Development.

## Tests
Run the full test suite (unit + integration):

```bash
dotnet test -c Debug
```

The integration test `BuggyEndpoint_ReturnsOk` is expected to fail until the candidate fixes the buggy endpoint.

## Interview tasks (30 minutes)
1. Setup (5 min): clone, restore, run the API and open Swagger.
2. Debug (15 min): reproduce and fix the buggy endpoint (`GET /api/candidate/buggy`) so the integration test passes.
3. Discussion (10 min): explain the choice of fix, discuss architecture and next improvements.

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
