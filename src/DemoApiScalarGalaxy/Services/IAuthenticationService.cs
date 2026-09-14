using System;
using System.Threading;
using System.Threading.Tasks;
using DemoApiScalarGalaxy.Core;
using DemoApiScalarGalaxy.Models.Authentication;

namespace DemoApiScalarGalaxy.Services;

/// <summary>
/// Some endpoints are public, but some require authentication. We provide all the
/// required endpoints to create an account and authorize yourself.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAuthenticationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAuthenticationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAuthenticationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Yeah, this is the boring security stuff. Just get your super secret token and move on.
    /// </summary>
    Task<Token> CreateToken(
        AuthenticationCreateTokenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Time to create a user account, eh?
    /// </summary>
    Task<User> CreateUser(
        AuthenticationCreateUserParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Find yourself they say. That's what you can do here.
    /// </summary>
    Task<User> ListMe(
        AuthenticationListMeParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAuthenticationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAuthenticationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAuthenticationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /auth/token</c>, but is otherwise the
    /// same as <see cref="IAuthenticationService.CreateToken(AuthenticationCreateTokenParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Token>> CreateToken(
        AuthenticationCreateTokenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /user/signup</c>, but is otherwise the
    /// same as <see cref="IAuthenticationService.CreateUser(AuthenticationCreateUserParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<User>> CreateUser(
        AuthenticationCreateUserParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /me</c>, but is otherwise the
    /// same as <see cref="IAuthenticationService.ListMe(AuthenticationListMeParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<User>> ListMe(
        AuthenticationListMeParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
