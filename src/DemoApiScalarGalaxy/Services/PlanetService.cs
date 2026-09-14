using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DemoApiScalarGalaxy.Core;
using DemoApiScalarGalaxy.Exceptions;
using DemoApiScalarGalaxy.Models.Planets;

namespace DemoApiScalarGalaxy.Services;

/// <inheritdoc/>
public sealed class PlanetService : IPlanetService
{
    readonly Lazy<IPlanetServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPlanetServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDemoApiScalarGalaxyClient _client;

    /// <inheritdoc/>
    public IPlanetService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlanetService(this._client.WithOptions(modifier));
    }

    public PlanetService(IDemoApiScalarGalaxyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PlanetServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Planet> Create(
        PlanetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Planet> Retrieve(
        PlanetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Planet> Retrieve(
        long planetID,
        PlanetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PlanetID = planetID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Planet> Update(
        PlanetUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Planet> Update(
        long planetID,
        PlanetUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { PlanetID = planetID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PlanetListResponse> List(
        PlanetListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(PlanetDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        long planetID,
        PlanetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { PlanetID = planetID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PlanetUploadImageResponse> UploadImage(
        PlanetUploadImageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UploadImage(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PlanetUploadImageResponse> UploadImage(
        long planetID,
        PlanetUploadImageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UploadImage(parameters with { PlanetID = planetID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PlanetServiceWithRawResponse : IPlanetServiceWithRawResponse
{
    readonly IDemoApiScalarGalaxyClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPlanetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlanetServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PlanetServiceWithRawResponse(IDemoApiScalarGalaxyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Planet>> Create(
        PlanetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlanetCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var planet = await response.Deserialize<Planet>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    planet.Validate();
                }
                return planet;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Planet>> Retrieve(
        PlanetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlanetID == null)
        {
            throw new DemoApiScalarGalaxyInvalidDataException(
                "'parameters.PlanetID' cannot be null"
            );
        }

        HttpRequest<PlanetRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var planet = await response.Deserialize<Planet>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    planet.Validate();
                }
                return planet;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Planet>> Retrieve(
        long planetID,
        PlanetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PlanetID = planetID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Planet>> Update(
        PlanetUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlanetID == null)
        {
            throw new DemoApiScalarGalaxyInvalidDataException(
                "'parameters.PlanetID' cannot be null"
            );
        }

        HttpRequest<PlanetUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var planet = await response.Deserialize<Planet>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    planet.Validate();
                }
                return planet;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Planet>> Update(
        long planetID,
        PlanetUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { PlanetID = planetID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanetListResponse>> List(
        PlanetListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PlanetListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<PlanetListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        PlanetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlanetID == null)
        {
            throw new DemoApiScalarGalaxyInvalidDataException(
                "'parameters.PlanetID' cannot be null"
            );
        }

        HttpRequest<PlanetDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        long planetID,
        PlanetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { PlanetID = planetID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanetUploadImageResponse>> UploadImage(
        PlanetUploadImageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlanetID == null)
        {
            throw new DemoApiScalarGalaxyInvalidDataException(
                "'parameters.PlanetID' cannot be null"
            );
        }

        HttpRequest<PlanetUploadImageParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<PlanetUploadImageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PlanetUploadImageResponse>> UploadImage(
        long planetID,
        PlanetUploadImageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UploadImage(parameters with { PlanetID = planetID }, cancellationToken);
    }
}
