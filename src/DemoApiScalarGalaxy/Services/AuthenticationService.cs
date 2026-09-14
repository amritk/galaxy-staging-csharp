using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DemoApiScalarGalaxy.Core;
using DemoApiScalarGalaxy.Models.Authentication;

namespace DemoApiScalarGalaxy.Services;

/// <inheritdoc/>
public sealed class AuthenticationService : IAuthenticationService
{
    readonly Lazy<IAuthenticationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAuthenticationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDemoApiScalarGalaxyClient _client;

    /// <inheritdoc/>
    public IAuthenticationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AuthenticationService(this._client.WithOptions(modifier));
    }

    public AuthenticationService(IDemoApiScalarGalaxyClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AuthenticationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<Token> CreateToken(
        AuthenticationCreateTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateToken(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<User> CreateUser(
        AuthenticationCreateUserParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateUser(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<User> ListMe(
        AuthenticationListMeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListMe(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AuthenticationServiceWithRawResponse : IAuthenticationServiceWithRawResponse
{
    readonly IDemoApiScalarGalaxyClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAuthenticationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AuthenticationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AuthenticationServiceWithRawResponse(IDemoApiScalarGalaxyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Token>> CreateToken(
        AuthenticationCreateTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AuthenticationCreateTokenParams> request = new()
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
                    .Deserialize<Token>(token)
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
    public async Task<HttpResponse<User>> CreateUser(
        AuthenticationCreateUserParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AuthenticationCreateUserParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var user = await response.Deserialize<User>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    user.Validate();
                }
                return user;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<User>> ListMe(
        AuthenticationListMeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AuthenticationListMeParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var user = await response.Deserialize<User>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    user.Validate();
                }
                return user;
            }
        );
    }
}
