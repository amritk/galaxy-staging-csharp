---
name: demo-api-scalar-galaxy-csharp-sdk
description: "C# SDK for Demo API (Scalar Galaxy). Use when writing C# code that calls Demo API (Scalar Galaxy) with the DemoApiScalarGalaxy package: installing it, constructing and authenticating the client, and calling API operations."
---

# Demo API (Scalar Galaxy) C# SDK

Generated C# client for Demo API (Scalar Galaxy), published as `DemoApiScalarGalaxy`. Use the generated client instead of hand-writing HTTP requests.

## Install

```sh
dotnet add package DemoApiScalarGalaxy
```

## Client setup and authentication

```csharp
using System;
using DemoApiScalarGalaxy;

var client = new DemoApiScalarGalaxyClient
{
    BearerAuth = Environment.GetEnvironmentVariable("BEARER_AUTH"),
};
```

Provide credentials using the options below. Environment variables are read automatically when the target runtime supports them:

- `BearerAuth` (env: `BEARER_AUTH`) — JWT Bearer token authentication
- `BasicAuthUsername` (env: `BASIC_AUTH_USERNAME`) — Credential sent with every request.
- `BasicAuthPassword` (env: `BASIC_AUTH_PASSWORD`) — Credential sent with every request.
- `ApiKeyHeader` (env: `API_KEY_HEADER`) — API key request header
- `ApiKeyQuery` (env: `API_KEY_QUERY`) — API key query parameter
- `ApiKeyCookie` (env: `API_KEY_COOKIE`) — API key browser cookie
- `OAuth2` (env: `O_AUTH2`) — OAuth 2.0 authentication
- `OpenIDConnect` (env: `OPEN_ID_CONNECT`) — OpenID Connect Authentication

## Calling operations

```csharp
using System;
using DemoApiScalarGalaxy;
using DemoApiScalarGalaxy.Models.Planets;

var client = new DemoApiScalarGalaxyClient
{
    BearerAuth = Environment.GetEnvironmentVariable("BEARER_AUTH"),
};

var result = await client.Planets.List(new PlanetListParams());
```

Method names, parameter shapes, and response types are generated from the API description — do not guess them. Look up the exact call signature in [api.md](./api.md) before writing a call.

## Error handling

A non-success response throws a subclass of `DemoApiScalarGalaxyApiException`, chosen by the status:

| Status | Exception |
| --- | --- |
| 400 | `DemoApiScalarGalaxyBadRequestException` |
| 401 | `DemoApiScalarGalaxyUnauthorizedException` |
| 403 | `DemoApiScalarGalaxyForbiddenException` |
| 404 | `DemoApiScalarGalaxyNotFoundException` |
| 422 | `DemoApiScalarGalaxyUnprocessableEntityException` |
| 429 | `DemoApiScalarGalaxyRateLimitException` |
| 5xx | `DemoApiScalarGalaxy5xxException` |
| others | `DemoApiScalarGalaxyUnexpectedStatusCodeException` |

Every 4xx subclass additionally inherits from `DemoApiScalarGalaxy4xxException`. Outside that hierarchy:

- `DemoApiScalarGalaxyIOException` — transport failures, so a connection error is never mistaken for an API error.
- `DemoApiScalarGalaxyInvalidDataException` — a successfully parsed response that does not match the expected type, thrown when the mismatched property is read.
- `DemoApiScalarGalaxyException` — base class for every exception above.

```csharp
using System;
using DemoApiScalarGalaxy.Exceptions;
using DemoApiScalarGalaxy.Models.Planets;

try
{
    var result = await client.Planets.List(new PlanetListParams());
}
catch (DemoApiScalarGalaxyApiException exception)
{
    Console.WriteLine(exception.StatusCode);
    Console.WriteLine(exception.ResponseBody);
}
```

## Requirements

- .NET 8.0 or newer, or any runtime supporting .NET Standard 2.0

## Reference files

- [README.md](./README.md) — full feature tour: client options, retries and timeouts.
- [api.md](./api.md) — complete catalogue of every operation with request and response types.
