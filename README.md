[projectUri]: https://github.com/sketch7/MessagePack.MediaTypeFormatter
[projectGit]: https://github.com/sketch7/MessagePack.MediaTypeFormatter.git
[changeLog]: ./CHANGELOG.md

# MessagePack MediaTypeFormatter
[![CircleCI](https://circleci.com/gh/sketch7/MessagePack.MediaTypeFormatter.svg?style=shield)](https://circleci.com/gh/sketch7/MessagePack.MediaTypeFormatter)
[![NuGet version](https://badge.fury.io/nu/Sketch7.MessagePack.MediaTypeFormatter.svg)](https://badge.fury.io/nu/Sketch7.MessagePack.MediaTypeFormatter)

Media type formatter for MessagePack.

**Quick links**

[Change logs][changeLog] | [Project Repository][projectUri]

## Installation
Available for [.NET Standard 2.0+](https://docs.microsoft.com/en-gb/dotnet/standard/net-standard)

### NuGet
```
PM> Install-Package Sketch7.MessagePack.MediaTypeFormatter
```

### csproj

```xml
<PackageReference Include="Sketch7.MessagePack.MediaTypeFormatter" Version="*" />
```

## Usage

```cs
var messagePackMediaTypeFormatter = new MessagePackMediaTypeFormatter(ContractlessStandardResolver.Instance);
```

## Contributing

### Setup Machine for Development
Install/setup the following:

- NodeJS v8+
- Visual Studio Code or similar code editor
- Git + SourceTree, SmartGit or similar (optional)

 ### Commands

```bash
# run tests
npm test

# bump version
npm version minor --no-git-tag # major | minor | patch | prerelease

# nuget pack (only)
npm run pack

# nuget publish dev (pack + publish + clean)
npm run publish:dev
```