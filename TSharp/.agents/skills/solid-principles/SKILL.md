---
name: solid-principles
user-invocable: false
description: Use during implementation when designing modules, functions, and components requiring SOLID principles for maintainable, flexible architecture.
allowed-tools:
  - Read
  - Edit
  - Grep
  - Glob
---

# SOLID Principles

Apply SOLID design principles for maintainable, flexible code architecture.

## The Five Principles

### 1. Single Responsibility Principle (SRP)

### A module should have one, and only one, reason to change

### Elixir Pattern

```elixir
# BAD - Multiple responsibilities
defmodule UserManager do
  def create_user(attrs) do
    # Creates user
    # Sends welcome email
    # Logs to analytics
    # Updates cache
  end
end

# GOOD - Single responsibility
defmodule User do
  def create(attrs), do: Repo.insert(changeset(attrs))
end

defmodule UserNotifier do
  def send_welcome_email(user), do: # email logic
end

defmodule UserAnalytics do
  def track_signup(user), do: # analytics logic
end
```

### TypeScript Pattern

```typescript
// BAD - Multiple responsibilities
class UserComponent {
  render() { /* UI */ }
  fetchData() { /* API */ }
  formatDate() { /* Formatting */ }
  validateInput() { /* Validation */ }
}

// GOOD - Single responsibility
function UserProfile({ user }: Props) {
  return <View>{/* UI only */}</View>;
}

function useUserData(id: string) {
  // Data fetching only
}

function formatUserDate(date: Date): string {
  // Formatting only
}
```

**Ask yourself:** "What is the ONE thing this module does?"

### 2. Open/Closed Principle (OCP)

**Software entities should be open for extension, closed for modification.**

### C# Pattern (Behaviours)

```csharp
public interface IPaymentProvider {
    Transaction ProcessPayment(decimal amount, string token);
}

public class StripeProvider : IPaymentProvider {
    public Transaction ProcessPayment(decimal amount, string token) {
        // Stripe logic
        return new Transaction();
    }
}

public class PayPalProvider : IPaymentProvider {
    public Transaction ProcessPayment(decimal amount, string token) {
        // PayPal logic
        return new Transaction();
    }
}

// Usage
public Transaction Charge(IPaymentProvider provider, decimal amount, string token) {
    return provider.ProcessPayment(amount, token);
}
```

### C# Pattern (Composition)

```csharp
// BAD - Requires modification for new types
public string RenderItem(Item item) {
    if (item.Type == "gig") {
        return "TaskCard";
    } else if (item.Type == "shift") {
        return "WorkPeriodCard";
    }
    // Have to modify this function for new types
    return "DefaultCard";
}

// GOOD - Extension through delegates
public delegate string CardRenderer(Item item);

public static Dictionary<string, CardRenderer> renderers = new()
{
    { "gig", item => "TaskCard" },
    { "shift", item => "WorkPeriodCard" } /* Add new types without modifying RenderItem */
};

public string RenderItemFlexible(Item item) {
    if (renderers.TryGetValue(item.Type, out var renderer)) {
        return renderer(item);
    }
    return "DefaultCard";
}
```

**Ask yourself:** "Can I add new functionality without changing existing code?"

### 3. Liskov Substitution Principle (LSP)

### Subtypes must be substitutable for their base types

### C# Pattern (LSP)

```csharp
// BAD - Violates LSP
public class PaymentCalculator {
    public double CalculateTotal(List<double> items) {
        if (items.Count == 0) {
            throw new Exception("Empty list not allowed");
        }
        return items.Sum();
    }
}

// GOOD - Honors contract
public class PaymentCalculator {
    public double CalculateTotal(List<double> items) {
        return items.Sum(); // Returns 0 for empty list
    }
}
```

### C# Pattern (LSP)

```csharp
// BAD - Violates LSP
public class Bird {
    public virtual void Fly() { /* flies */ }
}

public class Penguin : Bird {
    public override void Fly() {
        throw new Exception("Penguins cannot fly"); // Breaks contract
    }
}

// GOOD - Correct abstraction
public interface IBird {
    void Move();
}

public class FlyingBird : IBird {
    public void Move() {
        Fly();
    }
    private void Fly() { /* flies */ }
}

public class SwimmingBird : IBird {
    public void Move() {
        Swim();
    }
    private void Swim() { /* swims */ }
}
```

**Ask yourself:** "Can I replace this with its parent/interface without
breaking behavior?"

### 4. Interface Segregation Principle (ISP)

**Clients should not be forced to depend on interfaces they don't use.**

### C# Pattern (ISP)

```csharp
// BAD - Fat interface
public interface IUser {
    void Work();
    void TakeBreak();
    void EatLunch();
    void ClockIn();
    void ClockOut();
    // Not all users need all these
}

// GOOD - Segregated interfaces
public interface IWorkable { void Work(); }
public interface IBreakable { void TakeBreak(); }
public interface ITimeTrackable {
    void ClockIn();
    void ClockOut();
}

// Implement only what you need
public class ContractUser : IWorkable {
    public void Work() { /*...*/ }
    // No time tracking needed
}
```

### C# Pattern (ISP)

```csharp
// BAD - Fat interface
public interface IUser {
    void Work();
    void TakeBreak();
    void ClockIn();
    void ClockOut();
    void ReceiveBenefits();
    // Not all users need all methods
}

// GOOD - Segregated interfaces
public interface IWorkable { void Work(); }
public interface ITimeTrackable {
    void ClockIn();
    void ClockOut();
}
public interface IBenefitsEligible {
    void ReceiveBenefits();
}

// Compose only what you need
public class FullTimeUser : IWorkable, ITimeTrackable, IBenefitsEligible {
    public void Work() { }
    public void ClockIn() { }
    public void ClockOut() { }
    public void ReceiveBenefits() { }
}
public class ContractUser : IWorkable, ITimeTrackable {
    public void Work() { }
    public void ClockIn() { }
    public void ClockOut() { }
}
public class TaskUser : IWorkable {
    public void Work() { }
}
```

**Ask yourself:** "Does this interface force implementations to define unused methods?"

### 5. Dependency Inversion Principle (DIP)

### Depend on abstractions, not concretions

### C# Pattern (DIP)

```csharp
// BAD - Direct dependency
public class UserService {
    public User CreateUser(User user) {
        var repo = new PostgresRepo(); // Tightly coupled
        repo.Insert(user);
        return user;
    }
}

// GOOD - Depend on abstraction
public interface IRepository {
    void Insert(User user);
}

public class UserService {
    private readonly IRepository _repo;
    public UserService(IRepository repo) {
        _repo = repo;
    }
    public User CreateUser(User user) {
        _repo.Insert(user);
        return user;
    }
}
```

### C# Pattern (DIP)

```csharp
// BAD - Direct dependency
public class UserManager {
    private StripeAPI api = new StripeAPI(); // Tightly coupled
    public Transaction ProcessPayment(decimal amount) {
        return api.Charge(amount);
    }
}

// GOOD - Depend on abstraction
public interface IPaymentAPI {
    Transaction Charge(decimal amount);
}

public class UserManager {
    private readonly IPaymentAPI _paymentAPI;
    public UserManager(IPaymentAPI paymentAPI) {
        _paymentAPI = paymentAPI;
    }
    public Transaction ProcessPayment(decimal amount) {
        return _paymentAPI.Charge(amount);
    }
}

// Usage
IPaymentAPI stripeAPI = new StripeAPI();
var manager = new UserManager(stripeAPI);
```

**Ask yourself:** "Can I swap implementations without changing dependent code?"

## Application Checklist

### Before writing new code

- [ ] Identify the single responsibility
- [ ] Design for extension points (behaviours, interfaces)
- [ ] Define abstractions before implementations
- [ ] Keep interfaces minimal and focused

### During implementation

- [ ] Each module has ONE reason to change (SRP)
- [ ] New features extend, don't modify (OCP)
- [ ] Implementations honor contracts (LSP)
- [ ] Interfaces are minimal (ISP)
- [ ] Dependencies are injected/configurable (DIP)

### During code review

- [ ] Are responsibilities clearly separated?
- [ ] Can we add features without modifying existing code?
- [ ] Do all implementations fulfill their contracts?
- [ ] Are interfaces focused and minimal?
- [ ] Are dependencies abstracted?

## Common Violations in Codebase

### SRP Violation

- GraphQL resolvers that also contain business logic (use command handlers)
- Components that fetch data AND render (use hooks + presentation components)

### OCP Violation

- Long if/else or case statements for types (use behaviours/polymorphism)
- Hardcoded provider logic (use dependency injection)

### LSP Violation

- Raising exceptions in implementations when base would return nil/error tuple
- Changing return types between implementations

### ISP Violation

- Fat GraphQL types requiring all fields (use fragments)
- Monolithic component props (split into focused interfaces)

### DIP Violation

- Direct calls to external services (wrap in behaviours)
- Hardcoded Repo calls (inject repository)

## Integration with Existing Skills

### Works with

- `boy-scout-rule`: Apply SOLID when improving code
- `test-driven-development`: Write tests for each responsibility
- `elixir-code-quality-enforcer`: Credo enforces some SOLID principles
- `typescript-code-quality-enforcer`: TypeScript interfaces support ISP/DIP

## Remember

**SOLID is about managing dependencies and responsibilities, not about
creating more code.**

Good design emerges from applying these principles pragmatically, not
dogmatically.