using System;
using DemoApiScalarGalaxy.Core;

namespace DemoApiScalarGalaxy.Services;

/// <inheritdoc/>
public sealed class WebhookService : IWebhookService
{
    readonly Lazy<IWebhookServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWebhookServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDemoApiScalarGalaxyClient _client;

    /// <inheritdoc/>
    public IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookService(this._client.WithOptions(modifier));
    }

    public WebhookService(IDemoApiScalarGalaxyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WebhookServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class WebhookServiceWithRawResponse : IWebhookServiceWithRawResponse
{
    readonly IDemoApiScalarGalaxyClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWebhookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WebhookServiceWithRawResponse(IDemoApiScalarGalaxyClientWithRawResponse client)
    {
        _client = client;
    }
}
