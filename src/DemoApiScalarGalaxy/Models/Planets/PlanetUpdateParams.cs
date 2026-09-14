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
/// Sometimes you make mistakes, that's fine. No worries, you can update all planets.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PlanetUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public long? PlanetID { get; init; }

    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    public required ApiEnum<string, PlanetUpdateParamsType> Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, PlanetUpdateParamsType>>(
                "type"
            );
        }
        init { this._rawBodyData.Set("type", value); }
    }

    /// <summary>
    /// Atmospheric composition
    /// </summary>
    public IReadOnlyList<PlanetUpdateParamsAtmosphere>? Atmosphere
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<PlanetUpdateParamsAtmosphere>
            >("atmosphere");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<PlanetUpdateParamsAtmosphere>?>(
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

    public PlanetUpdateParamsPhysicalProperties? PhysicalProperties
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PlanetUpdateParamsPhysicalProperties>(
                "physicalProperties"
            );
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

    public PlanetUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanetUpdateParams(PlanetUpdateParams planetUpdateParams)
        : base(planetUpdateParams)
    {
        this.PlanetID = planetUpdateParams.PlanetID;

        this._rawBodyData = new(planetUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PlanetUpdateParams(
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
    PlanetUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        long planetID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.PlanetID = planetID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PlanetUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        long planetID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            planetID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["PlanetID"] = JsonSerializer.SerializeToElement(this.PlanetID),
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

    public virtual bool Equals(PlanetUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.PlanetID?.Equals(other.PlanetID) ?? other.PlanetID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/planets/{0}", this.PlanetID)
        )
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

[JsonConverter(typeof(PlanetUpdateParamsTypeConverter))]
public enum PlanetUpdateParamsType
{
    Planet,
    Terrestrial,
    GasGiant,
    IceGiant,
    Dwarf,
    SuperEarth,
}

sealed class PlanetUpdateParamsTypeConverter : JsonConverter<PlanetUpdateParamsType>
{
    public override PlanetUpdateParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "planet" => PlanetUpdateParamsType.Planet,
            "terrestrial" => PlanetUpdateParamsType.Terrestrial,
            "gas_giant" => PlanetUpdateParamsType.GasGiant,
            "ice_giant" => PlanetUpdateParamsType.IceGiant,
            "dwarf" => PlanetUpdateParamsType.Dwarf,
            "super_earth" => PlanetUpdateParamsType.SuperEarth,
            _ => (PlanetUpdateParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanetUpdateParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanetUpdateParamsType.Planet => "planet",
                PlanetUpdateParamsType.Terrestrial => "terrestrial",
                PlanetUpdateParamsType.GasGiant => "gas_giant",
                PlanetUpdateParamsType.IceGiant => "ice_giant",
                PlanetUpdateParamsType.Dwarf => "dwarf",
                PlanetUpdateParamsType.SuperEarth => "super_earth",
                _ => throw new DemoApiScalarGalaxyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<PlanetUpdateParamsAtmosphere, PlanetUpdateParamsAtmosphereFromRaw>)
)]
public sealed record class PlanetUpdateParamsAtmosphere : JsonModel
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

    public PlanetUpdateParamsAtmosphere() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanetUpdateParamsAtmosphere(PlanetUpdateParamsAtmosphere planetUpdateParamsAtmosphere)
        : base(planetUpdateParamsAtmosphere) { }
#pragma warning restore CS8618

    public PlanetUpdateParamsAtmosphere(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanetUpdateParamsAtmosphere(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanetUpdateParamsAtmosphereFromRaw.FromRawUnchecked"/>
    public static PlanetUpdateParamsAtmosphere FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanetUpdateParamsAtmosphereFromRaw : IFromRawJson<PlanetUpdateParamsAtmosphere>
{
    /// <inheritdoc/>
    public PlanetUpdateParamsAtmosphere FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanetUpdateParamsAtmosphere.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PlanetUpdateParamsPhysicalProperties,
        PlanetUpdateParamsPhysicalPropertiesFromRaw
    >)
)]
public sealed record class PlanetUpdateParamsPhysicalProperties : JsonModel
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

    public PlanetUpdateParamsPhysicalPropertiesTemperature? Temperature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlanetUpdateParamsPhysicalPropertiesTemperature>(
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

    public PlanetUpdateParamsPhysicalProperties() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanetUpdateParamsPhysicalProperties(
        PlanetUpdateParamsPhysicalProperties planetUpdateParamsPhysicalProperties
    )
        : base(planetUpdateParamsPhysicalProperties) { }
#pragma warning restore CS8618

    public PlanetUpdateParamsPhysicalProperties(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanetUpdateParamsPhysicalProperties(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanetUpdateParamsPhysicalPropertiesFromRaw.FromRawUnchecked"/>
    public static PlanetUpdateParamsPhysicalProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanetUpdateParamsPhysicalPropertiesFromRaw
    : IFromRawJson<PlanetUpdateParamsPhysicalProperties>
{
    /// <inheritdoc/>
    public PlanetUpdateParamsPhysicalProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanetUpdateParamsPhysicalProperties.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PlanetUpdateParamsPhysicalPropertiesTemperature,
        PlanetUpdateParamsPhysicalPropertiesTemperatureFromRaw
    >)
)]
public sealed record class PlanetUpdateParamsPhysicalPropertiesTemperature : JsonModel
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

    public PlanetUpdateParamsPhysicalPropertiesTemperature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanetUpdateParamsPhysicalPropertiesTemperature(
        PlanetUpdateParamsPhysicalPropertiesTemperature planetUpdateParamsPhysicalPropertiesTemperature
    )
        : base(planetUpdateParamsPhysicalPropertiesTemperature) { }
#pragma warning restore CS8618

    public PlanetUpdateParamsPhysicalPropertiesTemperature(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanetUpdateParamsPhysicalPropertiesTemperature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanetUpdateParamsPhysicalPropertiesTemperatureFromRaw.FromRawUnchecked"/>
    public static PlanetUpdateParamsPhysicalPropertiesTemperature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanetUpdateParamsPhysicalPropertiesTemperatureFromRaw
    : IFromRawJson<PlanetUpdateParamsPhysicalPropertiesTemperature>
{
    /// <inheritdoc/>
    public PlanetUpdateParamsPhysicalPropertiesTemperature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanetUpdateParamsPhysicalPropertiesTemperature.FromRawUnchecked(rawData);
}
