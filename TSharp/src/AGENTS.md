# AGENTS.md — Core Project Guidelines

Welcome to the TSharp core project!

This guide summarizes agentic coding standards, architectural conventions, and error handling patterns to follow when contributing to `src/TSharp`.

## Essential Coding Guidelines
- Follow the Boy Scout Rule: always improve files you touch (clean up unused code/imports, fix warnings, clarify naming).
- Use explicit types; enable nullable reference types (check `<Nullable>enable</Nullable>` in csproj).
- Prefer functional error handling: use LanguageExt's `Either<Error, T>` instead of plain exceptions.
- Group imports: system first, then LanguageExt/Microsoft, then project-local.
- Indent with 4 spaces, braces on their own lines.
- One statement per line; lines should be ≤ 120 chars.
- Classes/methods use PascalCase; private fields _camelCase.

## Architecture
- Modular, testable design, using Dependency Injection (`Microsoft.Extensions.DependencyInjection`).
- Apply SOLID principles for maintainability.
- Remove dead code and simplify logic.

## Error Handling
- Avoid exceptions for control flow. Always prefer functional returns (`Either`).
- Console logging for meaningful errors; do not leak internals.

## References & Conventions
- See the main [AGENTS.md](../../AGENTS.md) for full rules, skills, and checklist.
- Skills: [Boy Scout Rule](../../.agents/skills/boy-scout-rule/SKILL.md), [SOLID Principles](../../.agents/skills/solid-principles/SKILL.md), [Test Driven Development](../../.agents/skills/test-driven-development/SKILL.md)

---
For tests and test-specific skills, see `../test/TSharp.Test/AGENTS.md` or the main project guide.

Happy coding!
