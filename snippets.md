# Demo Api Scalar Galaxy C# Snippets

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
