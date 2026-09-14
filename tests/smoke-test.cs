using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable 0618 // A smoke run exercises deprecated operations deliberately.

// Smoke test: calls every generated operation once to confirm the SDK can
// reach each endpoint. The generator runs this against a mock server and
// reads the JSON report written to SCALAR_SMOKE_REPORT.
internal static class SmokeProgram
{
    // `Label` says which of an operation's two calls this is — "required params" or "all
    // params". It is empty when the operation contributed a single case.
    private sealed record SmokeCase(
        string Operation,
        string Method,
        string Path,
        string Label,
        Func<global::DemoApiScalarGalaxy.DemoApiScalarGalaxyClient, CancellationToken, Task> Run
    );

    private static readonly IReadOnlyList<SmokeCase> Cases = new SmokeCase[]
    {
        new SmokeCase(
            "create",
            "POST",
            "/planets",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Planets.Create(
                        new global::DemoApiScalarGalaxy.Models.Planets.PlanetCreateParams
                        {
                            Name = "Mars",
                            Type = global::DemoApiScalarGalaxy.Models.Planets.Type.Terrestrial,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/planets",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Planets.Create(
                        new global::DemoApiScalarGalaxy.Models.Planets.PlanetCreateParams
                        {
                            Name = "Mars",
                            Type = global::DemoApiScalarGalaxy.Models.Planets.Type.Terrestrial,
                            Atmosphere =
                                new System.Collections.Generic.List<global::DemoApiScalarGalaxy.Models.Planets.Atmosphere>
                                {
                                    new global::DemoApiScalarGalaxy.Models.Planets.Atmosphere(),
                                },
                            Creator = new global::DemoApiScalarGalaxy.Models.Authentication.User(),
                            Description = "The red planet",
                            DiscoveredAt = System.DateTimeOffset.Parse("1610-01-07T00:00:00Z"),
                            FailureCallbackUrl = "https://example.com/webhook",
                            HabitabilityIndex = 0.68,
                            Image = "https://cdn.scalar.com/photos/mars.jpg",
                            PhysicalProperties =
                                new global::DemoApiScalarGalaxy.Models.Planets.PhysicalProperties(),
                            Satellites =
                                new System.Collections.Generic.List<global::DemoApiScalarGalaxy.Models.Planets.Satellite>
                                {
                                    new global::DemoApiScalarGalaxy.Models.Planets.Satellite
                                    {
                                        Name = "Phobos",
                                        Type = global::DemoApiScalarGalaxy
                                            .Models
                                            .Planets
                                            .SatelliteType
                                            .Moon,
                                    },
                                },
                            SuccessCallbackUrl = "https://example.com/webhook",
                            Tags = new System.Collections.Generic.List<string> { "smoke" },
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "retrieve",
            "GET",
            "/planets/{planetId}",
            "",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Planets.Retrieve(
                        new global::DemoApiScalarGalaxy.Models.Planets.PlanetRetrieveParams
                        {
                            PlanetID = 1,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "update",
            "PUT",
            "/planets/{planetId}",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Planets.Update(
                        new global::DemoApiScalarGalaxy.Models.Planets.PlanetUpdateParams
                        {
                            Name = "Mars",
                            PlanetID = 1,
                            Type = global::DemoApiScalarGalaxy
                                .Models
                                .Planets
                                .PlanetUpdateParamsType
                                .Terrestrial,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "update",
            "PUT",
            "/planets/{planetId}",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Planets.Update(
                        new global::DemoApiScalarGalaxy.Models.Planets.PlanetUpdateParams
                        {
                            Name = "Mars",
                            PlanetID = 1,
                            Type = global::DemoApiScalarGalaxy
                                .Models
                                .Planets
                                .PlanetUpdateParamsType
                                .Terrestrial,
                            Atmosphere =
                                new System.Collections.Generic.List<global::DemoApiScalarGalaxy.Models.Planets.PlanetUpdateParamsAtmosphere>
                                {
                                    new global::DemoApiScalarGalaxy.Models.Planets.PlanetUpdateParamsAtmosphere(),
                                },
                            Creator = new global::DemoApiScalarGalaxy.Models.Authentication.User(),
                            Description = "The red planet",
                            DiscoveredAt = System.DateTimeOffset.Parse("1610-01-07T00:00:00Z"),
                            FailureCallbackUrl = "https://example.com/webhook",
                            HabitabilityIndex = 0.68,
                            Image = "https://cdn.scalar.com/photos/mars.jpg",
                            PhysicalProperties =
                                new global::DemoApiScalarGalaxy.Models.Planets.PlanetUpdateParamsPhysicalProperties(),
                            Satellites =
                                new System.Collections.Generic.List<global::DemoApiScalarGalaxy.Models.Planets.Satellite>
                                {
                                    new global::DemoApiScalarGalaxy.Models.Planets.Satellite
                                    {
                                        Name = "Phobos",
                                        Type = global::DemoApiScalarGalaxy
                                            .Models
                                            .Planets
                                            .SatelliteType
                                            .Moon,
                                    },
                                },
                            SuccessCallbackUrl = "https://example.com/webhook",
                            Tags = new System.Collections.Generic.List<string> { "smoke" },
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/planets",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Planets.List(
                        new global::DemoApiScalarGalaxy.Models.Planets.PlanetListParams(),
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "list",
            "GET",
            "/planets",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Planets.List(
                        new global::DemoApiScalarGalaxy.Models.Planets.PlanetListParams
                        {
                            Limit = 1,
                            Offset = 1,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "delete",
            "DELETE",
            "/planets/{planetId}",
            "",
            static async (client, cancellationToken) =>
            {
                await client
                    .Planets.Delete(
                        new global::DemoApiScalarGalaxy.Models.Planets.PlanetDeleteParams
                        {
                            PlanetID = 1,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "uploadImage",
            "POST",
            "/planets/{planetId}/image",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Planets.UploadImage(
                        new global::DemoApiScalarGalaxy.Models.Planets.PlanetUploadImageParams
                        {
                            PlanetID = 1,
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "uploadImage",
            "POST",
            "/planets/{planetId}/image",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Planets.UploadImage(
                        new global::DemoApiScalarGalaxy.Models.Planets.PlanetUploadImageParams
                        {
                            PlanetID = 1,
                            Image = new System.IO.MemoryStream(
                                System.Text.Encoding.UTF8.GetBytes("@mars.jpg")
                            ),
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "create",
            "POST",
            "/celestial-bodies",
            "",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .CelestialBodies.Create(
                        new global::DemoApiScalarGalaxy.Models.CelestialBodies.CelestialBodyCreateParams
                        {
                            CelestialBody =
                                new global::DemoApiScalarGalaxy.Models.CelestialBodies.CelestialBody(
                                    new global::DemoApiScalarGalaxy.Models.Planets.Planet
                                    {
                                        ID = 1,
                                        Name = "Mars",
                                        Type = global::DemoApiScalarGalaxy
                                            .Models
                                            .Planets
                                            .PlanetType
                                            .Terrestrial,
                                    }
                                ),
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "createToken",
            "POST",
            "/auth/token",
            "",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Authentication.CreateToken(
                        new global::DemoApiScalarGalaxy.Models.Authentication.AuthenticationCreateTokenParams
                        {
                            Email = "marc@scalar.com",
                            Password = "i-love-scalar",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "createUser",
            "POST",
            "/user/signup",
            "required params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Authentication.CreateUser(
                        new global::DemoApiScalarGalaxy.Models.Authentication.AuthenticationCreateUserParams
                        {
                            Email = "marc@scalar.com",
                            Password = "i-love-scalar",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "createUser",
            "POST",
            "/user/signup",
            "all params",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Authentication.CreateUser(
                        new global::DemoApiScalarGalaxy.Models.Authentication.AuthenticationCreateUserParams
                        {
                            Email = "marc@scalar.com",
                            Password = "i-love-scalar",
                            Name = "Marc",
                        },
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
        new SmokeCase(
            "listMe",
            "GET",
            "/me",
            "",
            static async (client, cancellationToken) =>
            {
                _ = await client
                    .Authentication.ListMe(
                        new global::DemoApiScalarGalaxy.Models.Authentication.AuthenticationListMeParams(),
                        cancellationToken: cancellationToken
                    )
                    .ConfigureAwait(false);
            }
        ),
    };

    public static async Task<int> Main()
    {
        var client = new global::DemoApiScalarGalaxy.DemoApiScalarGalaxyClient { MaxRetries = 0 };
        var selected = SelectCases(Environment.GetEnvironmentVariable("SCALAR_SMOKE_FILTER"));
        var results = new List<Dictionary<string, object?>>();

        foreach (var smokeCase in selected)
        {
            var stopwatch = Stopwatch.StartNew();
            var status = "passed";
            string? error = null;
            using var caseCts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            try
            {
                await smokeCase.Run(client, caseCts.Token).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                status = "failed";
                error = exception.Message;
            }
            stopwatch.Stop();
            var entry = new Dictionary<string, object?>
            {
                ["operation"] = smokeCase.Operation,
                ["method"] = smokeCase.Method,
                ["path"] = smokeCase.Path,
                ["status"] = status,
                ["durationMs"] = stopwatch.ElapsedMilliseconds,
            };
            // Reported only when the operation contributed both of its calls, so a single-case
            // operation reports exactly as it did before there were two.
            if (smokeCase.Label.Length > 0)
                entry["label"] = smokeCase.Label;
            if (error is not null)
                entry["error"] = error;
            results.Add(entry);
        }

        var failed = results.Count(result => (string?)result["status"] == "failed");
        var report = new Dictionary<string, object?>
        {
            ["total"] = results.Count,
            ["failed"] = failed,
            ["results"] = results,
        };

        var reportPath = Environment.GetEnvironmentVariable("SCALAR_SMOKE_REPORT");
        if (!string.IsNullOrEmpty(reportPath))
        {
            File.WriteAllText(reportPath, JsonSerializer.Serialize(report));
        }
        else
        {
            foreach (var result in results)
            {
                var suffix = result.TryGetValue("label", out var label) ? $" [{label}]" : "";
                if ((string?)result["status"] == "passed")
                {
                    Console.WriteLine(
                        $"PASS {result["operation"]}{suffix} ({result["method"]} {result["path"]}) {result["durationMs"]}ms"
                    );
                }
                else
                {
                    Console.Error.WriteLine(
                        $"FAIL {result["operation"]}{suffix} ({result["method"]} {result["path"]})\n{result["error"]}"
                    );
                }
            }
            if (results.Count == 0)
            {
                Console.Error.WriteLine(
                    "No code samples ran (empty SDK or a SCALAR_SMOKE_FILTER that matched nothing)."
                );
            }
            else
            {
                Console.WriteLine($"\n{results.Count - failed}/{results.Count} samples passed");
            }
        }

        return failed > 0 || results.Count == 0 ? 1 : 0;
    }

    private static IReadOnlyList<SmokeCase> SelectCases(string? filter)
    {
        if (string.IsNullOrWhiteSpace(filter))
            return Cases;
        var needles = filter
            .Split(',')
            .Select(needle => needle.Trim())
            .Where(needle => needle.Length > 0)
            .ToArray();
        if (needles.Length == 0)
            return Cases;
        return Cases
            .Where(smokeCase =>
                needles.Any(needle =>
                    smokeCase.Operation.Contains(needle) || smokeCase.Path.Contains(needle)
                )
            )
            .ToList();
    }
}
