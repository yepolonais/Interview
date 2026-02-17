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

## Questions

### Intermediate

- Imagine that you would like the validate a DTO in your controller. What would you do ?
- What are middlewares, what are they used for ?
- What is dependency injection ?
- How is memory managed in .NET ?
- What would you do to track a memory leak ?
- What is AOT ? 
