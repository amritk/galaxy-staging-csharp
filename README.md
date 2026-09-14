# Demo API (Scalar Galaxy)

This library provides convenient access to the Demo API (Scalar Galaxy) from .NET applications written in C#.

The full API of this library can be found in [api.md](./api.md).

<br />

## Contents

- [Installation](#installation)
- [Usage](#usage)
- [API Reference](./api.md)
- [Requests and responses](#requests-and-responses)
- [Raw responses](#raw-responses)
- [Authentication](#authentication)
- [Errors](#errors)
- [Client Options](#client-options)
- [Retries and Timeouts](#retries-and-timeouts)
- [Requirements](#requirements)
- [Proxies and environments](#proxies-and-environments)
- [Undocumented API functionality](#undocumented-api-functionality)
- [Reference](#reference)
- [Semantic versioning](#semantic-versioning)

<br />

## Installation

```sh
dotnet add package DemoApiScalarGalaxy
```

<br />

## Usage

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

The examples in the following sections assume a `client` configured as shown above.

See the [API reference](./api.md) for every available operation.

<br />

## Requests and responses

Each operation takes a `…Params` record and returns a model whose properties are read lazily from the raw JSON response, so an undocumented member costs nothing until it is asked for.

For example, `client.Planets.List` is called with `PlanetListParams` and returns `Task<PlanetListResponse>`.

Generated XML documentation carries the OpenAPI descriptions where the document supplies them.

<br />

## Raw responses

The methods above deserialize the response and hand back the decoded value. To reach the status code, the headers, or the unparsed body, prefix the call with `WithRawResponse`:

```csharp
using DemoApiScalarGalaxy.Models.Planets;

var response = await client.WithRawResponse.Planets.List(new PlanetListParams());
var statusCode = response.StatusCode;
var headers = response.Headers;

var result = await response.Deserialize();

// The underlying HttpResponseMessage is available as `response.RawMessage`.
```

<br />

## Authentication

Pass credentials to the generated client constructor. Environment variables are read automatically when supported by the target runtime.

| Option | Type | Default | Description |
| --- | --- | --- | --- |
| `BearerAuth` | `string?` | - | JWT Bearer token authentication Defaults to BEARER_AUTH. |
| `BasicAuthUsername` | `string?` | - | Credential sent with every request. Defaults to BASIC_AUTH_USERNAME. |
| `BasicAuthPassword` | `string?` | - | Credential sent with every request. Defaults to BASIC_AUTH_PASSWORD. |
| `ApiKeyHeader` | `string?` | - | API key request header Defaults to API_KEY_HEADER. |
| `ApiKeyQuery` | `string?` | - | API key query parameter Defaults to API_KEY_QUERY. |
| `ApiKeyCookie` | `string?` | - | API key browser cookie Defaults to API_KEY_COOKIE. |
| `OAuth2` | `string?` | - | OAuth 2.0 authentication Defaults to O_AUTH2. |
| `OpenIDConnect` | `string?` | - | OpenID Connect Authentication Defaults to OPEN_ID_CONNECT. |

Declared schemes:

- `bearerAuth` bearer token
- `basicAuth` basic authentication
- `apiKeyHeader` API key in header `X-API-Key`
- `apiKeyQuery` API key in query `api_key`
- `apiKeyCookie` API key in cookie `api_key`
- `oAuth2` OAuth2/OpenID Connect
- `openIdConnect` OAuth2/OpenID Connect

<br />

## Errors

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

Documented error statuses: `400`, `401`, `403`, `404`, `409`, `422`.

<br />

## Client Options

Configure the generated client by setting any of these options when you create it.

```csharp
using System;
using DemoApiScalarGalaxy;

// Options are init-only properties on the client.
var client = new DemoApiScalarGalaxyClient { MaxRetries = 3, Timeout = TimeSpan.FromSeconds(42) };

// `WithOptions` derives a client or service that differs only in its settings, reusing the
// same connection pool. The original is left untouched.
var patient = client.WithOptions(options => options with { Timeout = TimeSpan.FromMinutes(5) });
```

| Option | Type | Default | Description |
| --- | --- | --- | --- |
| `BearerAuth` | `string?` | `Environment.GetEnvironmentVariable("BEARER_AUTH")` | JWT Bearer token authentication |
| `BasicAuthUsername` | `string?` | `Environment.GetEnvironmentVariable("BASIC_AUTH_USERNAME")` | Credential sent with every request. |
| `BasicAuthPassword` | `string?` | `Environment.GetEnvironmentVariable("BASIC_AUTH_PASSWORD")` | Credential sent with every request. |
| `ApiKeyHeader` | `string?` | `Environment.GetEnvironmentVariable("API_KEY_HEADER")` | API key request header |
| `ApiKeyQuery` | `string?` | `Environment.GetEnvironmentVariable("API_KEY_QUERY")` | API key query parameter |
| `ApiKeyCookie` | `string?` | `Environment.GetEnvironmentVariable("API_KEY_COOKIE")` | API key browser cookie |
| `OAuth2` | `string?` | `Environment.GetEnvironmentVariable("O_AUTH2")` | OAuth 2.0 authentication |
| `OpenIDConnect` | `string?` | `Environment.GetEnvironmentVariable("OPEN_ID_CONNECT")` | OpenID Connect Authentication |
| `BaseUrl` | `string` | `https://galaxy.scalar.com` | Base URL every request is sent to. Read from OFFICIAL-GALAXY-TESTING_BASE_URL when unset. |
| `MaxRetries` | `int?` | `2` | How many times a retriable failure is retried before the call gives up. |
| `Timeout` | `TimeSpan?` | `TimeSpan.FromMinutes(1)` | How long each request attempt may take. |
| `HttpClient` | `HttpClient` | - | Transport every request goes through; supply your own to add a proxy or handler. |
| `ResponseValidation` | `bool` | `false` | Whether response bodies are validated up front instead of when a property is read. |

<br />

## Retries and Timeouts

Generated clients support request timeouts and retry temporary failures such as network errors, 408, 409, 429, and 5xx responses. Retry delays honor `Retry-After` headers when present. Tune the retry and timeout client options shown above, or override them per request.

<br />

## Requirements

- .NET 8.0 or newer, or any runtime supporting .NET Standard 2.0

<br />

## Proxies and environments

### Proxies

Route requests through a proxy by supplying your own `HttpClient`:

```csharp
using System.Net;
using System.Net.Http;
using DemoApiScalarGalaxy;

var httpClient = new HttpClient(
    new HttpClientHandler { Proxy = new WebProxy("https://proxy.example.com:8080") }
);

var client = new DemoApiScalarGalaxyClient { HttpClient = httpClient };
```

### Environments

Requests go to the `production` environment (`https://galaxy.scalar.com`) by default. `EnvironmentUrl` declares each one: `Production`, `RespondsWithYourRequestData`:

```csharp
using DemoApiScalarGalaxy;
using DemoApiScalarGalaxy.Core;

var client = new DemoApiScalarGalaxyClient { BaseUrl = EnvironmentUrl.Production };
```

<br />

## Undocumented API functionality

The SDK is typed for the documented API, and still lets you reach past it.

### Parameters

Every `…Params` record has a constructor taking raw header and query dictionaries — plus a body dictionary for operations that send one — alongside the documented properties:

```csharp
using System.Collections.Generic;
using System.Text.Json;
using DemoApiScalarGalaxy.Models.Planets;

var parameters = new PlanetListParams(
    rawHeaderData: new Dictionary<string, JsonElement>
    {
        { "Custom-Header", JsonSerializer.SerializeToElement(42) },
    },
    rawQueryData: new Dictionary<string, JsonElement>
    {
        { "custom_query_param", JsonSerializer.SerializeToElement(42) },
    }
);
```

The same values are readable back through the `RawHeaderData`, `RawQueryData`, and (where present) `RawBodyData` properties.

A `required` property cannot be omitted from an object initializer, so setting one to an undocumented value goes through `FromRawUnchecked`, which takes the same dictionaries and skips the initializer entirely. Nested parameter records carry both forms too.

### Response properties

A model decoded from a JSON object exposes `RawData`, an `IReadOnlyDictionary<string, JsonElement>` holding everything the server sent — including members the document never described:

```csharp
using System.Text.Json;

// `model` is any object-shaped value decoded from a response.
if (model.RawData.TryGetValue("my_custom_key", out JsonElement value))
{
    // Do something with `value`.
}
```

### Response validation

By default a response that does not match the expected type only throws `DemoApiScalarGalaxyInvalidDataException` when the mismatched property is read. Call `Validate()` on a decoded model to check the whole body up front, or set `ResponseValidation = true` on the client to validate every response.

<br />

## Reference

See `reference.md` for every generated operation signature, and `snippets.md` for a copyable version of the example above.

<br />

## Semantic versioning

This package follows [SemVer](https://semver.org/spec/v2.0.0.html), with two classes of change released as minor versions rather than major ones:

1. Changes to library internals that are technically public but neither intended nor documented for external use.
2. Changes not expected to affect the vast majority of users in practice.

Powered by Scalar.
