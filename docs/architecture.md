# Architecture Rules

- Domain contains:
  - Entities
  - ValueObjects
  - Domain exceptions

- Application contains:
  - Use cases
  - Interfaces (ports)
  - DTOs

- Infrastructure contains:
  - MongoDB repositories
  - External services adapters

- API contains:
  - Controllers
  - Middleware
  - Dependency injection wiring

No layer may bypass Application.
