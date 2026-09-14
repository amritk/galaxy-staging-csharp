using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DemoApiScalarGalaxy.Core;
using DemoApiScalarGalaxy.Exceptions;
using DemoApiScalarGalaxy.Models.Authentication;
using System = System;

namespace DemoApiScalarGalaxy.Models.Planets;

/// <summary>
/// A planet in the Scalar Galaxy
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Planet, PlanetFromRaw>))]
public sealed record class Planet : JsonModel
{
    public required long ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required ApiEnum<string, PlanetType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PlanetType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Atmospheric composition
    /// </summary>
    public IReadOnlyList<PlanetAtmosphere>? Atmosphere
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PlanetAtmosphere>>("atmosphere");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<PlanetAtmosphere>?>(
                "atmosphere",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A user
    /// </summary>
    public User? Creator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<User>("creator");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("creator", value);
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

    public System::DateTimeOffset? DiscoveredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("discoveredAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("discoveredAt", value);
        }
    }

    /// <summary>
    /// URL which gets invoked upon a failed operation
    /// </summary>
    public string? FailureCallbackUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("failureCallbackUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("failureCallbackUrl", value);
        }
    }

    /// <summary>
    /// A score from 0 to 1 indicating potential habitability
    /// </summary>
    public double? HabitabilityIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("habitabilityIndex");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("habitabilityIndex", value);
        }
    }

    public string? Image
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("image");
        }
        init { this._rawData.Set("image", value); }
    }

    public System::DateTimeOffset? LastUpdated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("lastUpdated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastUpdated", value);
        }
    }

    public PlanetPhysicalProperties? PhysicalProperties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlanetPhysicalProperties>("physicalProperties");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("physicalProperties", value);
        }
    }

    public IReadOnlyList<Satellite>? Satellites
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Satellite>>("satellites");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Satellite>?>(
                "satellites",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// URL which gets invoked upon a successful operation
    /// </summary>
    public string? SuccessCallbackUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("successCallbackUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("successCallbackUrl", value);
        }
    }

    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        this.Type.Validate();
        foreach (var item in this.Atmosphere ?? [])
        {
            item.Validate();
        }
        this.Creator?.Validate();
        _ = this.Description;
        _ = this.DiscoveredAt;
        _ = this.FailureCallbackUrl;
        _ = this.HabitabilityIndex;
        _ = this.Image;
        _ = this.LastUpdated;
        this.PhysicalProperties?.Validate();
        foreach (var item in this.Satellites ?? [])
        {
            item.Validate();
        }
        _ = this.SuccessCallbackUrl;
        _ = this.Tags;
    }

    public Planet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Planet(Planet planet)
        : base(planet) { }
#pragma warning restore CS8618

    public Planet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Planet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanetFromRaw.FromRawUnchecked"/>
    public static Planet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanetFromRaw : IFromRawJson<Planet>
{
    /// <inheritdoc/>
    public Planet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Planet.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlanetTypeConverter))]
public enum PlanetType
{
    Planet,
    Terrestrial,
    GasGiant,
    IceGiant,
    Dwarf,
    SuperEarth,
}

sealed class PlanetTypeConverter : JsonConverter<PlanetType>
{
    public override PlanetType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "planet" => PlanetType.Planet,
            "terrestrial" => PlanetType.Terrestrial,
            "gas_giant" => PlanetType.GasGiant,
            "ice_giant" => PlanetType.IceGiant,
            "dwarf" => PlanetType.Dwarf,
            "super_earth" => PlanetType.SuperEarth,
            _ => (PlanetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanetType.Planet => "planet",
                PlanetType.Terrestrial => "terrestrial",
                PlanetType.GasGiant => "gas_giant",
                PlanetType.IceGiant => "ice_giant",
                PlanetType.Dwarf => "dwarf",
                PlanetType.SuperEarth => "super_earth",
                _ => throw new DemoApiScalarGalaxyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<PlanetAtmosphere, PlanetAtmosphereFromRaw>))]
public sealed record class PlanetAtmosphere : JsonModel
{
    public string? Compound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("compound");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("compound", value);
        }
    }

    public double? Percentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("percentage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("percentage", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Compound;
        _ = this.Percentage;
    }

    public PlanetAtmosphere() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanetAtmosphere(PlanetAtmosphere planetAtmosphere)
        : base(planetAtmosphere) { }
#pragma warning restore CS8618

    public PlanetAtmosphere(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanetAtmosphere(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanetAtmosphereFromRaw.FromRawUnchecked"/>
    public static PlanetAtmosphere FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanetAtmosphereFromRaw : IFromRawJson<PlanetAtmosphere>
{
    /// <inheritdoc/>
    public PlanetAtmosphere FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlanetAtmosphere.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<PlanetPhysicalProperties, PlanetPhysicalPropertiesFromRaw>)
)]
public sealed record class PlanetPhysicalProperties : JsonModel
{
    /// <summary>
    /// Surface gravity in Earth g
    /// </summary>
    public double? Gravity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("gravity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("gravity", value);
        }
    }

    /// <summary>
    /// Mass in Earth masses (must be greater than 0)
    /// </summary>
    public double? Mass
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("mass");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mass", value);
        }
    }

    /// <summary>
    /// Radius in Earth radii (must be greater than 0)
    /// </summary>
    public double? Radius
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("radius");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("radius", value);
        }
    }

    public PlanetPhysicalPropertiesTemperature? Temperature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlanetPhysicalPropertiesTemperature>(
                "temperature"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("temperature", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Gravity;
        _ = this.Mass;
        _ = this.Radius;
        this.Temperature?.Validate();
    }

    public PlanetPhysicalProperties() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanetPhysicalProperties(PlanetPhysicalProperties planetPhysicalProperties)
        : base(planetPhysicalProperties) { }
#pragma warning restore CS8618

    public PlanetPhysicalProperties(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanetPhysicalProperties(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanetPhysicalPropertiesFromRaw.FromRawUnchecked"/>
    public static PlanetPhysicalProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanetPhysicalPropertiesFromRaw : IFromRawJson<PlanetPhysicalProperties>
{
    /// <inheritdoc/>
    public PlanetPhysicalProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanetPhysicalProperties.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PlanetPhysicalPropertiesTemperature,
        PlanetPhysicalPropertiesTemperatureFromRaw
    >)
)]
public sealed record class PlanetPhysicalPropertiesTemperature : JsonModel
{
    /// <summary>
    /// Average temperature in Kelvin
    /// </summary>
    public double? Average
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("average");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("average", value);
        }
    }

    /// <summary>
    /// Maximum temperature in Kelvin
    /// </summary>
    public double? Max
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("max");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("max", value);
        }
    }

    /// <summary>
    /// Minimum temperature in Kelvin
    /// </summary>
    public double? Min
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("min");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("min", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Average;
        _ = this.Max;
        _ = this.Min;
    }

    public PlanetPhysicalPropertiesTemperature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanetPhysicalPropertiesTemperature(
        PlanetPhysicalPropertiesTemperature planetPhysicalPropertiesTemperature
    )
        : base(planetPhysicalPropertiesTemperature) { }
#pragma warning restore CS8618

    public PlanetPhysicalPropertiesTemperature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanetPhysicalPropertiesTemperature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanetPhysicalPropertiesTemperatureFromRaw.FromRawUnchecked"/>
    public static PlanetPhysicalPropertiesTemperature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanetPhysicalPropertiesTemperatureFromRaw : IFromRawJson<PlanetPhysicalPropertiesTemperature>
{
    /// <inheritdoc/>
    public PlanetPhysicalPropertiesTemperature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanetPhysicalPropertiesTemperature.FromRawUnchecked(rawData);
}
