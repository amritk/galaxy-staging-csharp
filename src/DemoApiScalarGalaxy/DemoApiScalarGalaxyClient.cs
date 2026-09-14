using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DemoApiScalarGalaxy.Core;
using DemoApiScalarGalaxy.Exceptions;
using DemoApiScalarGalaxy.Services;

namespace DemoApiScalarGalaxy;

/// <inheritdoc/>
public sealed class DemoApiScalarGalaxyClient : IDemoApiScalarGalaxyClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string? BearerAuth
    {
        get { return this._options.BearerAuth; }
        init { this._options.BearerAuth = value; }
    }

    /// <inheritdoc/>
    public string? BasicAuthUsername
    {
        get { return this._options.BasicAuthUsername; }
        init { this._options.BasicAuthUsername = value; }
    }

    /// <inheritdoc/>
    public string? BasicAuthPassword
    {
        get { return this._options.BasicAuthPassword; }
        init { this._options.BasicAuthPassword = value; }
    }

    /// <inheritdoc/>
    public string? ApiKeyHeader
    {
        get { return this._options.ApiKeyHeader; }
        init { this._options.ApiKeyHeader = value; }
    }

    /// <inheritdoc/>
    public string? ApiKeyQuery
    {
        get { return this._options.ApiKeyQuery; }
        init { this._options.ApiKeyQuery = value; }
    }

    /// <inheritdoc/>
    public string? ApiKeyCookie
    {
        get { return this._options.ApiKeyCookie; }
        init { this._options.ApiKeyCookie = value; }
    }

    /// <inheritdoc/>
    public string? OAuth2
    {
        get { return this._options.OAuth2; }
        init { this._options.OAuth2 = value; }
    }

    /// <inheritdoc/>
    public string? OpenIDConnect
    {
        get { return this._options.OpenIDConnect; }
        init { this._options.OpenIDConnect = value; }
    }

    readonly Lazy<IDemoApiScalarGalaxyClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDemoApiScalarGalaxyClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public IDemoApiScalarGalaxyClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DemoApiScalarGalaxyClient(modifier(this._options));
    }

    readonly Lazy<IPlanetService> _planets;
    public IPlanetService Planets
    {
        get { return _planets.Value; }
    }

    readonly Lazy<ICelestialBodyService> _celestialBodies;
    public ICelestialBodyService CelestialBodies
    {
        get { return _celestialBodies.Value; }
    }

    readonly Lazy<IAuthenticationService> _authentication;
    public IAuthenticationService Authentication
    {
        get { return _authentication.Value; }
    }

    readonly Lazy<IWebhookService> _webhooks;
    public IWebhookService Webhooks
    {
        get { return _webhooks.Value; }
    }

    public void Dispose() => this.HttpClient.Dispose();

    public DemoApiScalarGalaxyClient()
    {
        _options = new();

        _withRawResponse = new(() => new DemoApiScalarGalaxyClientWithRawResponse(this._options));
        _planets = new(() => new PlanetService(this));
        _celestialBodies = new(() => new CelestialBodyService(this));
        _authentication = new(() => new AuthenticationService(this));
        _webhooks = new(() => new WebhookService(this));
    }

    public DemoApiScalarGalaxyClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class DemoApiScalarGalaxyClientWithRawResponse
    : IDemoApiScalarGalaxyClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    internal static HttpMethod PatchMethod = new("PATCH");

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string? BearerAuth
    {
        get { return this._options.BearerAuth; }
        init { this._options.BearerAuth = value; }
    }

    /// <inheritdoc/>
    public string? BasicAuthUsername
    {
        get { return this._options.BasicAuthUsername; }
        init { this._options.BasicAuthUsername = value; }
    }

    /// <inheritdoc/>
    public string? BasicAuthPassword
    {
        get { return this._options.BasicAuthPassword; }
        init { this._options.BasicAuthPassword = value; }
    }

    /// <inheritdoc/>
    public string? ApiKeyHeader
    {
        get { return this._options.ApiKeyHeader; }
        init { this._options.ApiKeyHeader = value; }
    }

    /// <inheritdoc/>
    public string? ApiKeyQuery
    {
        get { return this._options.ApiKeyQuery; }
        init { this._options.ApiKeyQuery = value; }
    }

    /// <inheritdoc/>
    public string? ApiKeyCookie
    {
        get { return this._options.ApiKeyCookie; }
        init { this._options.ApiKeyCookie = value; }
    }

    /// <inheritdoc/>
    public string? OAuth2
    {
        get { return this._options.OAuth2; }
        init { this._options.OAuth2 = value; }
    }

    /// <inheritdoc/>
    public string? OpenIDConnect
    {
        get { return this._options.OpenIDConnect; }
        init { this._options.OpenIDConnect = value; }
    }

    /// <inheritdoc/>
    public IDemoApiScalarGalaxyClientWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DemoApiScalarGalaxyClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<IPlanetServiceWithRawResponse> _planets;
    public IPlanetServiceWithRawResponse Planets
    {
        get { return _planets.Value; }
    }

    readonly Lazy<ICelestialBodyServiceWithRawResponse> _celestialBodies;
    public ICelestialBodyServiceWithRawResponse CelestialBodies
    {
        get { return _celestialBodies.Value; }
    }

    readonly Lazy<IAuthenticationServiceWithRawResponse> _authentication;
    public IAuthenticationServiceWithRawResponse Authentication
    {
        get { return _authentication.Value; }
    }

    readonly Lazy<IWebhookServiceWithRawResponse> _webhooks;
    public IWebhookServiceWithRawResponse Webhooks
    {
        get { return _webhooks.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw DemoApiScalarGalaxyExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new DemoApiScalarGalaxyIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await global::System
                .Threading.Tasks.Task.Delay(backoff, cancellationToken)
                .ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-scalar-retry-count"))
        {
            requestMessage.Headers.Add("x-scalar-retry-count", retryCount.ToString());
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = global::System.Threading.CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    global::System.Net.Http.HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new DemoApiScalarGalaxyIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (
            apiBackoff != null
            && apiBackoff > global::System.TimeSpan.Zero
            && apiBackoff < global::System.TimeSpan.FromMinutes(1)
        )
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = global::System.Math.Min(
            0.5 * global::System.Math.Pow(2.0, retries - 1),
            8.0
        );
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return global::System.TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue =
            headerValues == null
                ? null
                : global::System.Linq.Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return global::System.TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue =
            headerValues == null
                ? null
                : global::System.Linq.Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return global::System.TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (global::System.DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - global::System.DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(
                global::System.Linq.Enumerable.FirstOrDefault(headerValues),
                out var shouldRetry
            )
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is DemoApiScalarGalaxyIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public DemoApiScalarGalaxyClientWithRawResponse()
    {
        _options = new();

        _planets = new(() => new PlanetServiceWithRawResponse(this));
        _celestialBodies = new(() => new CelestialBodyServiceWithRawResponse(this));
        _authentication = new(() => new AuthenticationServiceWithRawResponse(this));
        _webhooks = new(() => new WebhookServiceWithRawResponse(this));
    }

    public DemoApiScalarGalaxyClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
