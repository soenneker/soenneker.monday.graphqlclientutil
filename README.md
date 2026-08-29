[![](https://img.shields.io/nuget/v/soenneker.monday.graphqlclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.monday.graphqlclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.monday.graphqlclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.monday.graphqlclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.monday.graphqlclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.monday.graphqlclientutil/)

# Soenneker.Monday.GraphQlClientUtil

A .NET thread-safe singleton GraphQL client.

## Install

```bash
dotnet add package Soenneker.Monday.GraphQlClientUtil
```

## Quick start

```csharp
using Soenneker.Monday.GraphQlClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddMondayGraphQlClientUtilAsSingleton();
```

Adds `MondayGraphQlClientUtil` as a singleton service.

## What you get

- `IMondayGraphQlClientUtil` — A .NET thread-safe singleton GraphQL client.
- `MondayGraphQlClientUtilRegistrar` — A .NET thread-safe singleton GraphQL client.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IMondayGraphQlClientUtil.Get(apiKey, cancellationToken)` | Gets a cached client for a specific Monday API key using the configured base URL. | A task whose result is the requested monday Graph Ql Client. |
| `IMondayGraphQlClientUtil.Get(apiKey, baseUrl, cancellationToken)` | Gets a cached client for a specific Monday connection. | A task whose result is the requested monday Graph Ql Client. |
| `MondayGraphQlClientUtilRegistrar.AddMondayGraphQlClientUtilAsSingleton(services)` | Adds `MondayGraphQlClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `MondayGraphQlClientUtilRegistrar.AddMondayGraphQlClientUtilAsScoped(services)` | Adds `MondayGraphQlClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
