---
name: test-driven-development
description: Use when writing new functions, adding features, fixing bugs, or refactoring by applying TDD principles - write failing tests before implementation code, make them pass, then refactor.
allowed-tools:
  - Write
  - Read
  - Edit
  - Bash
  - Grep
---

# Test-Driven Development (TDD)

Red → Green → Refactor cycle for all code changes.

## The TDD Cycle

1. **RED**: Write failing test
2. **GREEN**: Write minimal code to pass
3. **REFACTOR**: Improve code quality

### Repeat for each requirement

## When to Apply TDD

✅ **Always use TDD for:**

- New functions/methods
- New features
- Bug fixes (reproduce first)
- Refactoring existing code
- API changes

❌ **Skip TDD for:**

- UI styling tweaks
- Configuration changes
- Documentation updates

## Process

### 1. Write Failing Test First

```csharp
// Start with test
[Fact]
public void CalculatesTotalWithTax()
{
    var prices = new List<double> { 100, 200 };
    
    var result = Calculator.CalculateTotal(prices);
    
    Assert.Equal(324.0, result);
}

// Run test - should FAIL
dotnet test
```

### 2. Implement Minimal Code

```csharp
// Just enough to pass
public static double CalculateTotal(List<double> prices)
{
    return prices.Sum() * 1.08;
}
```

### 3. Refactor

Extract constants, improve naming, etc.

## Test Patterns by Stack

### Backend (C#)

- File: `tests/CalculatorTests.cs`
- Pattern: `src/<ProjectName>/Tests/CalculatorTests.cs`

### Frontend (TypeScript)

- File: `ComponentName.test.tsx`
- Pattern: `mobile/libraries/atorasu/atoms/Button/Button.test.tsx`

## Critical Rules

- Tests MUST fail first (verify test works)
- One test per requirement
- Test behavior, not implementation
- Run FULL test suite before commit
- NEVER skip failing tests

## Common Pitfalls

- Writing implementation before test
- Tests that pass without implementation (false positive)
- Testing implementation details instead of behavior
- Not running test to verify it fails first

## Verification

```bash
 dotnet test src/<ProjectName>/Tests/CalculatorTests.cs
```