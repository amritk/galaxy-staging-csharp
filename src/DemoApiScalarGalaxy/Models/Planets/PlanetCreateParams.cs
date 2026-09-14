using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DemoApiScalarGalaxy.Core;
using DemoApiScalarGalaxy.Exceptions;
using DemoApiScalarGalaxy.Models.Authentication;
using System = System;

namespace DemoApiScalarGalaxy.Models.Planets;

/// <summary>
/// Time to play god and create a new planet. What do you think? Ah, don't think too
/// much. What could go wrong anyway?
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PlanetCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    public required ApiEnum<string, global::DemoApiScalarGalaxy.Models.Planets.Type> Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, global::DemoApiScalarGalaxy.Models.Planets.Type>
            >("type");
        }
        init { this._rawBodyData.Set("type", value); }
    }

    /// <summary>
    /// Atmospheric composition
    /// </summary>
    public IReadOnlyList<Atmosphere>? Atmosphere
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Atmosphere>>("atmosphere");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Atmosphere>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<User>("creator");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("creator", value);
        }
    }

    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    public System::DateTimeOffset? DiscoveredAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>("discoveredAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("discoveredAt", value);
        }
    }

    /// <summary>
    /// URL which gets invoked upon a failed operation
    /// </summary>
    public string? FailureCallbackUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("failureCallbackUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("failureCallbackUrl", value);
        }
    }

    /// <summary>
    /// A score from 0 to 1 indicating potential habitability
    /// </summary>
    public double? HabitabilityIndex
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("habitabilityIndex");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("habitabilityIndex", value);
        }
    }

    public string? Image
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("image");
        }
        init { this._rawBodyData.Set("image", value); }
    }

    public PhysicalProperties? PhysicalProperties
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PhysicalProperties>("physicalProperties");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("physicalProperties", value);
        }
    }

    public IReadOnlyList<Satellite>? Satellites
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Satellite>>("satellites");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Satellite>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("successCallbackUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("successCallbackUrl", value);
        }
    }

    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PlanetCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanetCreateParams(PlanetCreateParams planetCreateParams)
        : base(planetCreateParams)
    {
        this._rawBodyData = new(planetCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PlanetCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanetCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PlanetCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(PlanetCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/planets")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Planet,
    Terrestrial,
    GasGiant,
    IceGiant,
    Dwarf,
    SuperEarth,
}

sealed class TypeConverter : JsonConverter<global::DemoApiScalarGalaxy.Models.Planets.Type>
{
    public override global::DemoApiScalarGalaxy.Models.Planets.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "planet" => global::DemoApiScalarGalaxy.Models.Planets.Type.Planet,
            "terrestrial" => global::DemoApiScalarGalaxy.Models.Planets.Type.Terrestrial,
            "gas_giant" => global::DemoApiScalarGalaxy.Models.Planets.Type.GasGiant,
            "ice_giant" => global::DemoApiScalarGalaxy.Models.Planets.Type.IceGiant,
            "dwarf" => global::DemoApiScalarGalaxy.Models.Planets.Type.Dwarf,
            "super_earth" => global::DemoApiScalarGalaxy.Models.Planets.Type.SuperEarth,
            _ => (global::DemoApiScalarGalaxy.Models.Planets.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::DemoApiScalarGalaxy.Models.Planets.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::DemoApiScalarGalaxy.Models.Planets.Type.Planet => "planet",
                global::DemoApiScalarGalaxy.Models.Planets.Type.Terrestrial => "terrestrial",
                global::DemoApiScalarGalaxy.Models.Planets.Type.GasGiant => "gas_giant",
                global::DemoApiScalarGalaxy.Models.Planets.Type.IceGiant => "ice_giant",
                global::DemoApiScalarGalaxy.Models.Planets.Type.Dwarf => "dwarf",
                global::DemoApiScalarGalaxy.Models.Planets.Type.SuperEarth => "super_earth",
                _ => throw new DemoApiScalarGalaxyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Atmosphere, AtmosphereFromRaw>))]
public sealed record class Atmosphere : JsonModel
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

    public Atmosphere() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Atmosphere(Atmosphere atmosphere)
        : base(atmosphere) { }
#pragma warning restore CS8618

    public Atmosphere(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Atmosphere(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AtmosphereFromRaw.FromRawUnchecked"/>
    public static Atmosphere FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AtmosphereFromRaw : IFromRawJson<Atmosphere>
{
    /// <inheritdoc/>
    public Atmosphere FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Atmosphere.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PhysicalProperties, PhysicalPropertiesFromRaw>))]
public sealed record class PhysicalProperties : JsonModel
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

    public Temperature? Temperature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Temperature>("temperature");
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

    public PhysicalProperties() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalProperties(PhysicalProperties physicalProperties)
        : base(physicalProperties) { }
#pragma warning restore CS8618

    public PhysicalProperties(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhysicalProperties(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhysicalPropertiesFromRaw.FromRawUnchecked"/>
    public static PhysicalProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhysicalPropertiesFromRaw : IFromRawJson<PhysicalProperties>
{
    /// <inheritdoc/>
    public PhysicalProperties FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PhysicalProperties.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Temperature, TemperatureFromRaw>))]
public sealed record class Temperature : JsonModel
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

    public Temperature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Temperature(Temperature temperature)
        : base(temperature) { }
#pragma warning restore CS8618

    public Temperature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Temperature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemperatureFromRaw.FromRawUnchecked"/>
    public static Temperature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemperatureFromRaw : IFromRawJson<Temperature>
{
    /// <inheritdoc/>
    public Temperature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Temperature.FromRawUnchecked(rawData);
}
