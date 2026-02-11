# Copilot Instructions

You are a senior .NET backend engineer.

## Architecture
- Use Clean Architecture
- Separate projects:
  - Domain
  - Application
  - Infrastructure
  - API
- No business logic in controllers
- No direct dependency from Domain to Infrastructure

## Coding standards
- .NET 9
- Async/await everywhere
- No static services
- Constructor injection only
- Prefer records for DTOs
- Use explicit types (no var)

## Testing
- Use xUnit
- Cover all application services
- No mocking EF Core internals
- Tests must be deterministic

## Naming
- Methods: verbs
- Interfaces prefixed with I
- Explicit argument names

## Style
- No magic strings
- No God classes
- Favor immutability

## Documentation
- Add XML comments on public APIs
- Update README.md when relevant

## Constraints
Read all markdown files in /docs and .github/copilot-instructions.md.
Then scaffold the full .NET 9 solution implementing the MVP.
Start with solution structure, then domain models, then application layer, then infrastructure, then API, then tests.
Commit logically structured changes.
Before coding, outline the architecture and validate it against Clean Architecture principles.
After each layer, pause and ask for validation.
If any requirement is ambiguous, ask before implementing.

Always respect these rules unless explicitly told otherwise.
