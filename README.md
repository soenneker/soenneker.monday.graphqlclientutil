[![](https://img.shields.io/nuget/v/soenneker.monday.graphqlclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.monday.graphqlclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.monday.graphqlclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.monday.graphqlclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.monday.graphqlclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.monday.graphqlclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.monday.graphqlclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.monday.graphqlclientutil/actions/workflows/codeql.yml)

# Soenneker.Monday.GraphQlClientUtil

Creates and caches authenticated Monday GraphQL clients, including clients for multiple tokens or endpoints.

## Install

```bash
dotnet add package Soenneker.Monday.GraphQlClientUtil
```

## Configuration

```json
{
  "Monday": {
    "ApiKey": "your-api-key"
  }
}
```

## Usage

```csharp
using Soenneker.Monday.GraphQlClient;
using Soenneker.Monday.GraphQlClientUtil.Abstract;
using Soenneker.Monday.GraphQlClientUtil.Registrars;

services.AddMondayGraphQlClientUtilAsSingleton();

IMondayGraphQlClientUtil monday = serviceProvider
    .GetRequiredService<IMondayGraphQlClientUtil>();

MondayGraphQlClient client = await monday.Get(cancellationToken);
var boards = await client.GetBoards.GetValue(
    new GetBoardsVariables { Limit = 25 },
    cancellationToken);
```

Use `Get(apiKey)` for another token or `Get(apiKey, baseUrl)` for another Monday connection. Equivalent connection settings reuse the same generated client within the utility's lifetime.

Scoped registration creates a generated-client cache per application scope while retaining the shared HTTP provider. Disposing the scoped utility does not remove that shared provider or its clients.
