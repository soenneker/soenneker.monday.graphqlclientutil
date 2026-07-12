[![](https://img.shields.io/nuget/v/soenneker.monday.graphqlclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.monday.graphqlclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.monday.graphqlclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.monday.graphqlclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.monday.graphqlclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.monday.graphqlclientutil/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Monday.GraphQlClientUtil
### A thread-safe utility for obtaining cached Monday GraphQL clients.

## Installation

```
dotnet add package Soenneker.Monday.GraphQlClientUtil
```

The parameterless `Get()` uses `Monday:ApiKey` and `Monday:ClientBaseUrl`. For a multi-tenant application such as Leadping, pass each tenant's connection explicitly:

```csharp
MondayGraphQlClient tenantClient = await mondayGraphQlClientUtil.Get(tenantApiKey, tenantBaseUrl);
```

Clients are cached independently by API key and normalized base URL. Concurrent requests for the same connection share one client; different tenant credentials never share a client.
