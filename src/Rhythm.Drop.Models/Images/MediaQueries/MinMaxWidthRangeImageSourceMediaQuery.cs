namespace Rhythm.Drop.Models.Images.MediaQueries;

/// <summary>
/// A <see cref="IImageSourceMediaQuery"/> which has a Min/Max range media query.
/// </summary>
/// <param name="MinWidth">The min width.</param>
/// <param name="MaxWidth">The max width.</param>
/// <param name="Unit">The unit (e.g. px, vh, vw).</param>
public sealed record MinMaxWidthRangeImageSourceMediaQuery(int? MinWidth, int? MaxWidth, string Unit) : IImageSourceMediaQuery
{
    /// <summary>
    /// Constructs a <see cref="MinMaxWidthRangeImageSourceMediaQuery"/> with optional min width and min height using pixels as the unit.
    /// </summary>
    /// <param name="MinWidth">The min width.</param>
    /// <param name="MaxWidth">The max width.</param>
    public MinMaxWidthRangeImageSourceMediaQuery(int? MinWidth, int? MaxWidth) : this(MinWidth, MaxWidth, "px")
    {
    }

    /// <inheritdoc/>
    public string? ToMarkupString()
    {
        var result = new List<string>();

        if (MinWidth.HasValue)
        {
            result.Add($"(min-width: {MinWidth.Value}{Unit})");
        }
        if (MaxWidth.HasValue)
        {
            result.Add($"(max-width: {MaxWidth.Value}{Unit})");
        }

        if (result.Count == 0)
        {
            return default;
        }

        return result.Aggregate((c, n) => c + " and " + n);
    }
}