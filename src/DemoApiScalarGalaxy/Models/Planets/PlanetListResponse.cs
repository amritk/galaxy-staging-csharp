using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DemoApiScalarGalaxy.Core;

namespace DemoApiScalarGalaxy.Models.Planets;

[JsonConverter(typeof(JsonModelConverter<PlanetListResponse, PlanetListResponseFromRaw>))]
public sealed record class PlanetListResponse : JsonModel
{
    public Meta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Meta>("meta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    public IReadOnlyList<Planet>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Planet>>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Planet>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public static implicit operator PaginatedResource(PlanetListResponse planetListResponse) =>
        new() { Meta = planetListResponse.Meta };

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Meta?.Validate();
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public PlanetListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanetListResponse(PlanetListResponse planetListResponse)
        : base(planetListResponse) { }
#pragma warning restore CS8618

    public PlanetListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanetListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanetListResponseFromRaw.FromRawUnchecked"/>
    public static PlanetListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanetListResponseFromRaw : IFromRawJson<PlanetListResponse>
{
    /// <inheritdoc/>
    public PlanetListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlanetListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
    public IReadOnlyList<Planet>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Planet>>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Planet>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1(IntersectionMember1 intersectionMember1)
        : base(intersectionMember1) { }
#pragma warning restore CS8618

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntersectionMember1FromRaw : IFromRawJson<IntersectionMember1>
{
    /// <inheritdoc/>
    public IntersectionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IntersectionMember1.FromRawUnchecked(rawData);
}
