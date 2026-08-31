[![](https://img.shields.io/nuget/v/soenneker.nws.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.nws.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.nws.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.nws.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.nws.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.nws.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.nws.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.nws.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Nws.HttpClients

Provides a cached `HttpClient` with the User-Agent header required by the National Weather Service API.

## Installation

```bash
dotnet add package Soenneker.Nws.HttpClients
```

## Configuration

```json
{
  "Nws": {
    "UserAgent": "my-weather-app/1.0 (contact@example.com)"
  }
}
```

`Nws:ClientBaseUrl` can override the default `https://api.weather.gov` endpoint.

## Usage

```csharp
using Soenneker.Nws.HttpClients.Abstract;
using Soenneker.Nws.HttpClients.Registrars;

services.AddNwsOpenApiHttpClientAsSingleton();

INwsOpenApiHttpClient nws = serviceProvider
    .GetRequiredService<INwsOpenApiHttpClient>();

HttpClient client = await nws.Get(cancellationToken);
```

Do not dispose the returned `HttpClient`; the registered provider owns it and removes it from the cache when disposed.
