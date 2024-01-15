namespace Rhythm.Drop.Builders.Images;

using Rhythm.Drop.Builders.Images.Common;
using Rhythm.Drop.Infrastructure.Builders.Images.Common;

/// <summary>
/// An image builder with alt text.
/// </summary>
public interface IAltTextImageBuilder
{
    /// <summary>
    /// Gets the alt text of the builder.
    /// </summary>
    string? AltText { get; }

    /// <summary>
    /// Adds a URL to the builder.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns>A <see cref="IUrlAndAltTextImageBuilder"/>.</returns>
    IUrlAndAltTextImageBuilder AndUrl(string? url);
}