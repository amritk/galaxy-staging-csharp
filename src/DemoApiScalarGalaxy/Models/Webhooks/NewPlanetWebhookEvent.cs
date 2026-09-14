using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DemoApiScalarGalaxy.Core;

namespace DemoApiScalarGalaxy.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<NewPlanetWebhookEvent, NewPlanetWebhookEventFromRaw>))]
public sealed record class NewPlanetWebhookEvent : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public NewPlanetWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NewPlanetWebhookEvent(NewPlanetWebhookEvent newPlanetWebhookEvent)
        : base(newPlanetWebhookEvent) { }
#pragma warning restore CS8618

    public NewPlanetWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPlanetWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewPlanetWebhookEventFromRaw.FromRawUnchecked"/>
    public static NewPlanetWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewPlanetWebhookEventFromRaw : IFromRawJson<NewPlanetWebhookEvent>
{
    /// <inheritdoc/>
    public NewPlanetWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewPlanetWebhookEvent.FromRawUnchecked(rawData);
}
