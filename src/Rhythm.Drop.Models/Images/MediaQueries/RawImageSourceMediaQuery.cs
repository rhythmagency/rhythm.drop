namespace Rhythm.Drop.Models.Images.MediaQueries;

/// <summary>
/// A media query which is based on a raw value.
/// </summary>
/// <param name="Query">The query.</param>
public sealed record RawImageSourceMediaQuery(string Query) : IImageSourceMediaQuery
{
    /// <inheritdoc/>
    public string? ToMarkupString()
    {
        return Query;
    }
}