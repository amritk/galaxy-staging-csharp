using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DemoApiScalarGalaxy.Core;
using DemoApiScalarGalaxy.Exceptions;
using System = System;

namespace DemoApiScalarGalaxy.Models.Planets;

/// <summary>
/// Every satellite in the Scalar Galaxy
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Satellite, SatelliteFromRaw>))]
public sealed record class Satellite : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required ApiEnum<string, SatelliteType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SatelliteType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public long? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Diameter in kilometers
    /// </summary>
    public double? Diameter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("diameter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("diameter", value);
        }
    }

    public Orbit? Orbit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Orbit>("orbit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("orbit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        this.Type.Validate();
        _ = this.ID;
        _ = this.Description;
        _ = this.Diameter;
        this.Orbit?.Validate();
    }

    public Satellite() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Satellite(Satellite satellite)
        : base(satellite) { }
#pragma warning restore CS8618

    public Satellite(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Satellite(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SatelliteFromRaw.FromRawUnchecked"/>
    public static Satellite FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SatelliteFromRaw : IFromRawJson<Satellite>
{
    /// <inheritdoc/>
    public Satellite FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Satellite.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SatelliteTypeConverter))]
public enum SatelliteType
{
    Satellite,
    Moon,
    Asteroid,
    Comet,
}

sealed class SatelliteTypeConverter : JsonConverter<SatelliteType>
{
    public override SatelliteType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "satellite" => SatelliteType.Satellite,
            "moon" => SatelliteType.Moon,
            "asteroid" => SatelliteType.Asteroid,
            "comet" => SatelliteType.Comet,
            _ => (SatelliteType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SatelliteType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SatelliteType.Satellite => "satellite",
                SatelliteType.Moon => "moon",
                SatelliteType.Asteroid => "asteroid",
                SatelliteType.Comet => "comet",
                _ => throw new DemoApiScalarGalaxyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Orbit, OrbitFromRaw>))]
public sealed record class Orbit : JsonModel
{
    /// <summary>
    /// Average distance from the planet in kilometers
    /// </summary>
    public double? Distance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("distance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("distance", value);
        }
    }

    /// <summary>
    /// Orbital period in Earth days
    /// </summary>
    public double? OrbitalPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("orbitalPeriod");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("orbitalPeriod", value);
        }
    }

    /// <summary>
    /// The ID of the planet this satellite orbits
    /// </summary>
    public long? PlanetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("planetId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("planetId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Distance;
        _ = this.OrbitalPeriod;
        _ = this.PlanetID;
    }

    public Orbit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Orbit(Orbit orbit)
        : base(orbit) { }
#pragma warning restore CS8618

    public Orbit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Orbit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrbitFromRaw.FromRawUnchecked"/>
    public static Orbit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrbitFromRaw : IFromRawJson<Orbit>
{
    /// <inheritdoc/>
    public Orbit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Orbit.FromRawUnchecked(rawData);
}
