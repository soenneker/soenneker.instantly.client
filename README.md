[![](https://img.shields.io/nuget/v/soenneker.instantly.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.instantly.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.instantly.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.instantly.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.instantly.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.instantly.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.instantly.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.instantly.client/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Instantly.Client

Reuse an authenticated HTTP client for Instantly's v2 API.

## Install

```bash
dotnet add package Soenneker.Instantly.Client
```

## Configure

```json
{
  "Instantly": {
    "ApiKey": "<API key>"
  }
}
```

`Instantly:ApiKey` is required when the provider is created.

## Register

```csharp
using Soenneker.Instantly.Client.Registrars;

services.AddInstantlyClientAsSingleton();
```

Use `AddInstantlyClientAsScoped()` only when each scope should own its transport. Provider instances use isolated cache keys, so disposing one scope removes only its own client.

## Usage

```csharp
using Soenneker.Instantly.Client.Abstract;

HttpClient client = await instantlyClient.Get(cancellationToken);

HttpResponseMessage response = await client.GetAsync(
    "accounts?limit=10",
    cancellationToken);
response.EnsureSuccessStatusCode();
```

The returned client targets `https://api.instantly.ai/api/v2/` and sends the configured key as `Authorization: Bearer <API key>`.

Repeated `Get()` calls on the same provider reuse its client. The provider owns that client; let the service container dispose the provider rather than disposing the returned instance directly.
