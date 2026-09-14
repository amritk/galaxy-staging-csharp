using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DemoApiScalarGalaxy.Core;
using DemoApiScalarGalaxy.Exceptions;
using DemoApiScalarGalaxy.Models.Planets;

namespace DemoApiScalarGalaxy.Models.CelestialBodies;

/// <summary>
/// A celestial body which can be either a planet or a satellite
/// </summary>
[JsonConverter(typeof(CelestialBodyConverter))]
public record class CelestialBody : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? ID
    {
        get { return Match<long?>(planet: (x) => x.ID, satellite: (x) => x.ID); }
    }

    public string Name
    {
        get { return Match(planet: (x) => x.Name, satellite: (x) => x.Name); }
    }

    public string? Description
    {
        get
        {
            return Match<string?>(planet: (x) => x.Description, satellite: (x) => x.Description);
        }
    }

    public CelestialBody(Planet value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CelestialBody(Satellite value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CelestialBody(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Planet"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPlanet(out var value)) {
    ///     // `value` is of type `Planet`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPlanet([NotNullWhen(true)] out Planet? value)
    {
        value = this.Value as Planet;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Satellite"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSatellite(out var value)) {
    ///     // `value` is of type `Satellite`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSatellite([NotNullWhen(true)] out Satellite? value)
    {
        value = this.Value as Satellite;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="DemoApiScalarGalaxyInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (Planet value) =&gt; {...},
    ///     (Satellite value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<Planet> planet, Action<Satellite> satellite)
    {
        switch (this.Value)
        {
            case Planet value:
                planet(value);
                break;
            case Satellite value:
                satellite(value);
                break;
            default:
                throw new DemoApiScalarGalaxyInvalidDataException(
                    "Data did not match any variant of CelestialBody"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="DemoApiScalarGalaxyInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (Planet value) =&gt; {...},
    ///     (Satellite value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<Planet, T> planet, Func<Satellite, T> satellite)
    {
        return this.Value switch
        {
            Planet value => planet(value),
            Satellite value => satellite(value),
            _ => throw new DemoApiScalarGalaxyInvalidDataException(
                "Data did not match any variant of CelestialBody"
            ),
        };
    }

    public static implicit operator CelestialBody(Planet value) => new(value);

    public static implicit operator CelestialBody(Satellite value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DemoApiScalarGalaxyInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new DemoApiScalarGalaxyInvalidDataException(
                "Data did not match any variant of CelestialBody"
            );
        }
        this.Switch((planet) => planet.Validate(), (satellite) => satellite.Validate());
    }

    public virtual bool Equals(CelestialBody? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            Planet _ => 0,
            Satellite _ => 1,
            _ => -1,
        };
    }
}

sealed class CelestialBodyConverter : JsonConverter<CelestialBody>
{
    public override CelestialBody? Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "planet":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Planet>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "satellite":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Satellite>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new CelestialBody(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        CelestialBody value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
