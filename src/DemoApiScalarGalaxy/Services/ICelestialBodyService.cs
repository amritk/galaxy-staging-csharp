using System;
using System.Threading;
using System.Threading.Tasks;
using DemoApiScalarGalaxy.Core;
using DemoApiScalarGalaxy.Models.CelestialBodies;

namespace DemoApiScalarGalaxy.Services;

/// <summary>
/// Celestial bodies are the planets and satellites in the Scalar Galaxy.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICelestialBodyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICelestialBodyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICelestialBodyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a celestial body
    /// </summary>
    Task<CelestialBody> Create(
        CelestialBodyCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICelestialBodyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICelestialBodyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICelestialBodyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /celestial-bodies</c>, but is otherwise the
    /// same as <see cref="ICelestialBodyService.Create(CelestialBodyCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CelestialBody>> Create(
        CelestialBodyCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
