using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DemoApiScalarGalaxy.Core;
using DemoApiScalarGalaxy.Exceptions;

namespace DemoApiScalarGalaxy.Models.Webhooks;

[JsonConverter(typeof(UnwrapWebhookEventConverter))]
public record class UnwrapWebhookEvent : ModelBase
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

    public UnwrapWebhookEvent(NewPlanetWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanetWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanet(out var value)) {
    ///     // `value` is of type `NewPlanetWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanet([NotNullWhen(true)] out NewPlanetWebhookEvent? value)
    {
        value = this.Value as NewPlanetWebhookEvent;
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
    ///     (NewPlanetWebhookEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<NewPlanetWebhookEvent> newPlanet)
    {
        switch (this.Value)
        {
            case NewPlanetWebhookEvent value:
                newPlanet(value);
                break;
            default:
                throw new DemoApiScalarGalaxyInvalidDataException(
                    "Data did not match any variant of UnwrapWebhookEvent"
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
    ///     (NewPlanetWebhookEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<NewPlanetWebhookEvent, T> newPlanet)
    {
        return this.Value switch
        {
            NewPlanetWebhookEvent value => newPlanet(value),
            _ => throw new DemoApiScalarGalaxyInvalidDataException(
                "Data did not match any variant of UnwrapWebhookEvent"
            ),
        };
    }

    public static implicit operator UnwrapWebhookEvent(NewPlanetWebhookEvent value) => new(value);

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
                "Data did not match any variant of UnwrapWebhookEvent"
            );
        }
        this.Switch((newPlanet) => newPlanet.Validate());
    }

    public virtual bool Equals(UnwrapWebhookEvent? other) =>
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
            NewPlanetWebhookEvent _ => 0,
            _ => -1,
        };
    }
}

sealed class UnwrapWebhookEventConverter : JsonConverter<UnwrapWebhookEvent>
{
    public override UnwrapWebhookEvent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<NewPlanetWebhookEvent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e)
            when (e is JsonException || e is DemoApiScalarGalaxyInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnwrapWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
