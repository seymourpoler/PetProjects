# TSharp

TSharp is a compiler project implemented in C# using .NET 10.0. Its goal is to provide a lexer, parser, and compiler frontend for a toy or research-oriented language.

## Features

- **Lexical Analysis**: Tokenization of source files
- **Modular and Testable**: Uses dependency injection with Microsoft.Extensions.DependencyInjection
- **Error Handling**: Functional style with LanguageExt
- **Unit Tested & Mocking**: xUnit-based tests and mocking support with FakeItEasy

## Getting Started

### Prerequisites
- [.NET 10.0 SDK](https://dotnet.microsoft.com/)

### Build
```sh
dotnet build TSharp.sln
```

### Run
```sh
dotnet run --project src/TSharp/TSharp.csproj -- [PathToYourFile]
```

### Test
```sh
dotnet test TSharp.sln
```

## Usage Example
Suppose you have a source file called `example.ts`. To analyze or compile it:

```sh
dotnet run --project src/TSharp/TSharp.csproj -- example.ts
```

The output will display errors in the file or proceed with compilation features as they are implemented.

## Project Structure

- `src/TSharp` - Core source files (compiler, lexer, arguments parser)
- `test/TSharp.Test` - xUnit test suite

## Dependencies
- LanguageExt.Core
- Microsoft.Extensions.DependencyInjection
- xUnit, Shouldly, FakeItEasy (test only)

## Contributing
Contributions are welcome! To contribute:
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/your-feature`)
3. Commit your changes (`git commit -am 'Add new feature'`)
4. Push the branch (`git push origin feature/your-feature`)
5. Open a Pull Request

Please ensure existing tests pass, and add new tests as appropriate for your code.

## Roadmap / Goals
- [x] Lexical analysis (tokenizer)
- [ ] Parsing
- [ ] Code generation & compilation
- [ ] Improved CLI and error messages
- [ ] Documentation & usage guides

## License
[MIT](LICENSE) _(To be added)_

## Contact / Author
Project by [Your Name or GitHub Username Here]. For issues, use the [issue tracker](https://github.com/yourusername/TSharp/issues).

---

> **Note:** This project is currently under development. Major features like parsing and full compilation are in progress.
