using System;
using System.Threading;
using System.Threading.Tasks;
using DemoApiScalarGalaxy.Core;
using DemoApiScalarGalaxy.Models.Planets;

namespace DemoApiScalarGalaxy.Services;

/// <summary>
/// Everything about planets
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPlanetService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPlanetServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlanetService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Time to play god and create a new planet. What do you think? Ah, don't think too
    /// much. What could go wrong anyway?
    /// </summary>
    Task<Planet> Create(
        PlanetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// You'll better learn a little bit more about the planets. It might come in handy
    /// once space travel is available for everyone.
    /// </summary>
    Task<Planet> Retrieve(
        PlanetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PlanetRetrieveParams, CancellationToken)"/>
    Task<Planet> Retrieve(
        long planetID,
        PlanetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sometimes you make mistakes, that's fine. No worries, you can update all planets.
    /// </summary>
    Task<Planet> Update(
        PlanetUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PlanetUpdateParams, CancellationToken)"/>
    Task<Planet> Update(
        long planetID,
        PlanetUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// It's easy to say you know them all, but do you really? Retrieve all the planets
    /// and check whether you missed one.
    /// </summary>
    Task<PlanetListResponse> List(
        PlanetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint was used to delete planets. Unfortunately, that caused a lot of
    /// trouble for planets with life. So, this endpoint is now deprecated and should not
    /// be used anymore.
    /// </summary>
    Task Delete(PlanetDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(PlanetDeleteParams, CancellationToken)"/>
    Task Delete(
        long planetID,
        PlanetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Got a crazy good photo of a planet? Share it with the world!
    /// </summary>
    Task<PlanetUploadImageResponse> UploadImage(
        PlanetUploadImageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UploadImage(PlanetUploadImageParams, CancellationToken)"/>
    Task<PlanetUploadImageResponse> UploadImage(
        long planetID,
        PlanetUploadImageParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPlanetService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPlanetServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlanetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /planets</c>, but is otherwise the
    /// same as <see cref="IPlanetService.Create(PlanetCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Planet>> Create(
        PlanetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /planets/{planetId}</c>, but is otherwise the
    /// same as <see cref="IPlanetService.Retrieve(PlanetRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Planet>> Retrieve(
        PlanetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PlanetRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Planet>> Retrieve(
        long planetID,
        PlanetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /planets/{planetId}</c>, but is otherwise the
    /// same as <see cref="IPlanetService.Update(PlanetUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Planet>> Update(
        PlanetUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PlanetUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Planet>> Update(
        long planetID,
        PlanetUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /planets</c>, but is otherwise the
    /// same as <see cref="IPlanetService.List(PlanetListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlanetListResponse>> List(
        PlanetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /planets/{planetId}</c>, but is otherwise the
    /// same as <see cref="IPlanetService.Delete(PlanetDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        PlanetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(PlanetDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        long planetID,
        PlanetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /planets/{planetId}/image</c>, but is otherwise the
    /// same as <see cref="IPlanetService.UploadImage(PlanetUploadImageParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlanetUploadImageResponse>> UploadImage(
        PlanetUploadImageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UploadImage(PlanetUploadImageParams, CancellationToken)"/>
    Task<HttpResponse<PlanetUploadImageResponse>> UploadImage(
        long planetID,
        PlanetUploadImageParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
