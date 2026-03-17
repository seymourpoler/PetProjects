# AGENTS.md — Test Project Standards

Welcome to the TSharp test suite!

This guide is for contributing tests to `test/TSharp.Test` using xUnit, Shouldly, and FakeItEasy. It ensures agentic, high-quality testing.

## Key Test Conventions
- Write one `[Fact]` per invariant; use `[Theory]` for parameterized cases.
- Assert with Shouldly for readable, fluent checks (e.g. `result.ShouldBe(expected)`).
- Use FakeItEasy for mocking collaborators, isolation, and fake objects.
- Follow Test-Driven Development: write failing tests first, then make them pass with minimal code, refactor afterward.
- Run all tests and ensure code coverage with Coverlet (`dotnet test --collect "Code Coverage"`).
- Identify tests by feature or class; use filters for focused runs:
  ```sh
  dotnet test --filter "FullyQualifiedName~Namespace.Class.Method"
  ```
- Test files should use PascalCase by feature or target class.

## Checklist for Contributors
- [ ] Every test covers one requirement or case
- [ ] Use Shouldly fluent assertions
- [ ] Mock dependencies with FakeItEasy where needed
- [ ] Clean up unused code and imports
- [ ] All tests must pass before commit
- [ ] Run all tests + coverage before contribution

## References & Skills
- See the main [AGENTS.md](../../AGENTS.md) for full project standards.
- Skills: [TDD](../../.agents/skills/test-driven-development/SKILL.md), [Shouldly](https://shouldly.github.io/), [FakeItEasy](https://fakeiteasy.github.io/), [xUnit](https://xunit.net/)

---
For core coding patterns, see `../../src/TSharp/AGENTS.md` or the main project guide.

Happy testing!
