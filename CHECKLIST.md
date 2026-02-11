# Interviewer Checklist

Use this printable checklist during the 30-minute candidate exercise.

- [ ] Setup (5 min)
  - Candidate clones repository and runs:

    ```bash
    dotnet restore
    dotnet run --project Interview
    ```
  - Candidate opens Swagger / confirms API is running.

- [ ] Reproduction (2 min)
  - Candidate reproduces the failing behavior for `GET /api/candidate/buggy`.
  - Candidate runs tests: `dotnet test -c Debug` and inspects failures.

- [ ] Fix (15 min)
  - Candidate proposes a minimal, correct fix.
  - Candidate implements the fix and runs unit/integration tests.
  - Candidate updates or adds tests if appropriate.

- [ ] Verify (3 min)
  - Run `dotnet test -c Debug` and confirm all tests pass.
  - Confirm `GET /api/candidate/buggy` no longer causes an unhandled exception.

- [ ] Discussion (5 min)
  - Ask candidate to explain the root cause and chosen fix.
  - Discuss trade-offs, error handling, logging, and test coverage.

## Scoring guidance
- Junior: Reproduces issue and applies a working fix; tests pass.
- Senior: Explains root cause, improves tests, and maintains clean layering.
- Expert: Proposes architectural improvements (observability, validation, resilience) and adds robust tests.

## Notes
- Repository layout: `Domain`, `Application`, `Infrastructure`, `Interview` (API), `Tests`.
- Intentional exercise items: `GET /api/candidate/buggy` and failing integration test `Tests/Integration/CandidateControllerIntegrationTests.cs`.
