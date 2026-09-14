using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DemoApiScalarGalaxy.Core;
using DemoApiScalarGalaxy.Models.CelestialBodies;

namespace DemoApiScalarGalaxy.Services;

/// <inheritdoc/>
public sealed class CelestialBodyService : ICelestialBodyService
{
    readonly Lazy<ICelestialBodyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICelestialBodyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDemoApiScalarGalaxyClient _client;

    /// <inheritdoc/>
    public ICelestialBodyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CelestialBodyService(this._client.WithOptions(modifier));
    }

    public CelestialBodyService(IDemoApiScalarGalaxyClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CelestialBodyServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CelestialBody> Create(
        CelestialBodyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CelestialBodyServiceWithRawResponse : ICelestialBodyServiceWithRawResponse
{
    readonly IDemoApiScalarGalaxyClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICelestialBodyServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CelestialBodyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CelestialBodyServiceWithRawResponse(IDemoApiScalarGalaxyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CelestialBody>> Create(
        CelestialBodyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CelestialBodyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var celestialBody = await response
                    .Deserialize<CelestialBody>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    celestialBody.Validate();
                }
                return celestialBody;
            }
        );
    }
}
