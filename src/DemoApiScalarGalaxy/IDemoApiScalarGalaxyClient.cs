using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DemoApiScalarGalaxy.Core;
using DemoApiScalarGalaxy.Services;

namespace DemoApiScalarGalaxy;

/// <summary>
/// A client for interacting with the Demo Api Scalar Galaxy REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDemoApiScalarGalaxyClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// JWT Bearer token authentication
    /// </summary>
    string? BearerAuth { get; init; }

    string? BasicAuthUsername { get; init; }

    string? BasicAuthPassword { get; init; }

    /// <summary>
    /// API key request header
    /// </summary>
    string? ApiKeyHeader { get; init; }

    /// <summary>
    /// API key query parameter
    /// </summary>
    string? ApiKeyQuery { get; init; }

    /// <summary>
    /// API key browser cookie
    /// </summary>
    string? ApiKeyCookie { get; init; }

    /// <summary>
    /// OAuth 2.0 authentication
    /// </summary>
    string? OAuth2 { get; init; }

    /// <summary>
    /// OpenID Connect Authentication
    /// </summary>
    string? OpenIDConnect { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDemoApiScalarGalaxyClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDemoApiScalarGalaxyClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IPlanetService Planets { get; }

    ICelestialBodyService CelestialBodies { get; }

    IAuthenticationService Authentication { get; }

    IWebhookService Webhooks { get; }
}

/// <summary>
/// A view of <see cref="IDemoApiScalarGalaxyClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IDemoApiScalarGalaxyClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// JWT Bearer token authentication
    /// </summary>
    string? BearerAuth { get; init; }

    string? BasicAuthUsername { get; init; }

    string? BasicAuthPassword { get; init; }

    /// <summary>
    /// API key request header
    /// </summary>
    string? ApiKeyHeader { get; init; }

    /// <summary>
    /// API key query parameter
    /// </summary>
    string? ApiKeyQuery { get; init; }

    /// <summary>
    /// API key browser cookie
    /// </summary>
    string? ApiKeyCookie { get; init; }

    /// <summary>
    /// OAuth 2.0 authentication
    /// </summary>
    string? OAuth2 { get; init; }

    /// <summary>
    /// OpenID Connect Authentication
    /// </summary>
    string? OpenIDConnect { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDemoApiScalarGalaxyClientWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    IPlanetServiceWithRawResponse Planets { get; }

    ICelestialBodyServiceWithRawResponse CelestialBodies { get; }

    IAuthenticationServiceWithRawResponse Authentication { get; }

    IWebhookServiceWithRawResponse Webhooks { get; }

    /// <summary>
    /// Sends a request to the Demo Api Scalar Galaxy REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
