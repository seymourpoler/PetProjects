# AGENTS.md

---
**TSharp Agentic Coding Standards & Developer Guide**
---

Welcome, agentic contributors! This document provides everything you need to build, lint, test, and contribute high-quality code to TSharp. It encodes key project commands, style rules, conventions, and integrates foundational skills like the Boy Scout Rule, SOLID principles, and Test-Driven Development.

## Project Overview

TSharp is a compiler project implemented in C# using .NET 10.0. Features include:
- Lexical Analysis (tokenization)
- Modular and testable architecture with Dependency Injection
- Functional Error Handling via LanguageExt
- Unit testing with xUnit, Shouldly, and FakeItEasy

### Project Structure
- `src/TSharp` : Core project code
- `test/TSharp.Test` : Test suite (xUnit)

---

## Folder-Specific Guidelines

### src/TSharp: Core Compiler Coding Standards
- Apply the Boy Scout Rule: improve every file you touch
- Use explicit types; enable nullable references
- Prefer functional error handling: use LanguageExt `Either<Error, T>`
- Organize imports system/3rd-party/project, and always remove unused
- Indent with 4 spaces; braces on new lines; <120 chars/line
- Private fields use _camelCase; public classes/methods PascalCase
- Modular, testable design with Dependency Injection
- Avoid exceptions for control flow, use `Either` instead
- See [src/TSharp/AGENTS.md](src/TSharp/AGENTS.md) for details

### test/TSharp.Test: Test Suite Conventions
- Write one [Fact] per invariant, [Theory] for parameterized tests
- Use Shouldly for fluent assertions and FakeItEasy for mocks/fakes
- Practice TDD: write failing tests before implementation, then refactor
- Run all tests and coverage before commit; files named by feature/class
- Clean up unused code/imports in test files as well
- See [test/TSharp.Test/AGENTS.md](test/TSharp.Test/AGENTS.md) for details

## Commands: Build, Run, Test, Lint

### Build (Solution-wide)
```sh
dotnet build TSharp.sln
```

### Run (Core Project)
```sh
dotnet run --project src/TSharp/TSharp.csproj -- [PathToYourFile]
```

### Test (All tests)
```sh
dotnet test TSharp.sln
```

### Test (Single Class or Method)
- To run a single test method:
```sh
dotnet test test/TSharp.Test/TSharp.Test.csproj --filter "FullyQualifiedName~Namespace.ClassName.MethodName"
```
- Example (run one Fact in TokenizerShould):
```sh
dotnet test test/TSharp.Test/TSharp.Test.csproj --filter "FullyQualifiedName~TSharp.Test.Lexer.TokenizerShould.ReturnEmptyListForEmptyInput"
```
- To run all tests in a specific class:
```sh
dotnet test test/TSharp.Test/TSharp.Test.csproj --filter "FullyQualifiedName~TSharp.Test.Lexer.TokenizerShould"
```

**Notes:**
- Use `--filter` with `FullyQualifiedName` for precise test targeting.
- For Theory tests: filter by method name only.

### Code Coverage
- Built-in: Coverlet is included. Standard run is:
```sh
dotnet test --collect "Code Coverage"
```

### Linting
- No explicit linter configured; agents should ensure files have no build warnings and conform to recommended style guides below. If integrating a linter, prefer [dotnet format](https://github.com/dotnet/format):
```sh
dotnet format
```

---
## Code Style Guidelines & Conventions

### Imports
- Use `using Namespace;` at the top of each file.
- Group system imports, then third-party (e.g. LanguageExt, Microsoft), and project-local last.
- Remove unused imports per Boy Scout Rule.

### Formatting
- Indent with 4 spaces (standard for C#).
- Braces on new lines:
  ```csharp
  public class Foo
  {
      ...
  }
  ```
- Keep lines ≤ 120 characters.
- One statement per line.

### Types
- Always use explicit types (`var` only when type is obvious from the right-hand side).
- Enable nullable reference types (`<Nullable>enable</Nullable>` in csproj).
- Use functional patterns for error handling (LanguageExt's `Either<Error, T>`, etc).

### Naming Conventions
- **Classes:** `PascalCase` (e.g. `TokenizerShould`, `TokenType`)
- **Methods:** `PascalCase` for public, `camelCase` for private
- **Fields:** `_camelCase` for private fields
- **Constants:** `PascalCase` or `ALL_CAPS` if necessary
- **Interfaces:** Prefix with `I` (e.g. `IFileReader`)

### Error Handling
- Do **not** use plain exceptions for control flow; prefer functional style with `Either<Error, T>`
- Log errors via `Console.WriteLine` in CLI, but surface meaningful messages only.
- Always return a valid result (e.g. empty list, not nulls) unless clear error.

### Unit Testing Patterns
- Tests in `test/TSharp.Test/` using xUnit
- Use `[Fact]` for invariants, `[Theory]` for parameterized cases
- Use Shouldly for fluent assertions

---
## Architecture & Quality Skills

### Boy Scout Rule
- Leave each file you touch better than you found it
- Remove dead code & unused imports
- Fix lint/build warnings
- Improve naming, add types, update comments
- See checklist below

### SOLID Principles
1. **Single Responsibility**: Each class/function should have one reason to change
2. **Open/Closed**: Extend via interfaces/abstractions, don't modify existing code
3. **Liskov Substitution**: Subtypes must respect base type contracts
4. **Interface Segregation**: Keep interfaces lean and focused
5. **Dependency Inversion**: Depend on abstractions, not concrete types

See `/mnt/c/Users/luisr/Documents/code/GitHub/PetProjects/TSharp/.agents/skills/solid-principles/SKILL.md` for full rules and examples.

---
### Test-Driven Development (TDD)
- Always write failing tests before implementation
- Make tests pass with minimal code, then refactor
- Run full test suite before every commit
- Tests must follow: one test per requirement, cover behavior, not implementation details

---
### Contribution Checklist

- [ ] Remove dead code in touched files
- [ ] Fix lint/build warnings
- [ ] Improve unclear naming
- [ ] Add type annotations
- [ ] Update comments
- [ ] Remove unused imports
- [ ] Simplify logic
- [ ] Add/verify error handling
- [ ] All tests must pass
- [ ] Document Boy Scout improvements in commit messages

---
### Key References
- [Boy Scout Rule Skill](.agents/skills/boy-scout-rule/SKILL.md)
- [SOLID Principles Skill](.agents/skills/solid-principles/SKILL.md)
- [Test Driven Development Skill](.agents/skills/test-driven-development/SKILL.md)

---
## Practical Tips for Agents
- Always update/clean touched files
- Prefer composition and abstraction to inheritance
- Use LanguageExt for functional error handling
- Prefer explicitness in types and error contracts
- Ensure new features are testable and covered by unit tests
- Document why and how you change files (Boy Scout Rule)
- Consult SOLID/TDD rules for major features or refactors

---
## FAQ

**How can I run only one test quickly?**
- Use `dotnet test ... --filter "FullyQualifiedName~Namespace.Class.Method"`

**How do I add a new test file?**
- Place in `test/TSharp.Test/`, use xUnit, name by feature or class

**How should I handle errors?**
- Use LanguageExt `Either<Error, T>`, avoid exceptions for flow. Log clearly.

---
**End of AGENTS.md**
