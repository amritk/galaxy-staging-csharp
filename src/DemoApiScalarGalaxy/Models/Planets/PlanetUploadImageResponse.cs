using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DemoApiScalarGalaxy.Core;

namespace DemoApiScalarGalaxy.Models.Planets;

[JsonConverter(
    typeof(JsonModelConverter<PlanetUploadImageResponse, PlanetUploadImageResponseFromRaw>)
)]
public sealed record class PlanetUploadImageResponse : JsonModel
{
    /// <summary>
    /// Size of the uploaded image in bytes
    /// </summary>
    public long? FileSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("fileSize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fileSize", value);
        }
    }

    /// <summary>
    /// The URL where the uploaded image can be accessed
    /// </summary>
    public string? ImageUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("imageUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("imageUrl", value);
        }
    }

    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <summary>
    /// The content type of the uploaded image
    /// </summary>
    public string? MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mimeType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mimeType", value);
        }
    }

    /// <summary>
    /// Timestamp when the image was uploaded
    /// </summary>
    public DateTimeOffset? UploadedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("uploadedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uploadedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileSize;
        _ = this.ImageUrl;
        _ = this.Message;
        _ = this.MimeType;
        _ = this.UploadedAt;
    }

    public PlanetUploadImageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanetUploadImageResponse(PlanetUploadImageResponse planetUploadImageResponse)
        : base(planetUploadImageResponse) { }
#pragma warning restore CS8618

    public PlanetUploadImageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanetUploadImageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanetUploadImageResponseFromRaw.FromRawUnchecked"/>
    public static PlanetUploadImageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanetUploadImageResponseFromRaw : IFromRawJson<PlanetUploadImageResponse>
{
    /// <inheritdoc/>
    public PlanetUploadImageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanetUploadImageResponse.FromRawUnchecked(rawData);
}
