namespace Rhythm.Drop.Builders.Images;

/// <summary>
/// A contract for creating an image builder that can add a URL.
/// </summary>
/// <typeparam name="TBuilder">The type of the builder to return after adding a URL.</typeparam>
public interface IAndUrlImageBuilder<TBuilder>
{
    /// <summary>
    /// Adds a URL to the builder.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns>A <typeparamref name="TBuilder"/>.</returns>
    TBuilder AndUrl(string? url);
}