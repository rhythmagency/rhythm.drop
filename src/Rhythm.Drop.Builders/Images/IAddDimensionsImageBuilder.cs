namespace Rhythm.Drop.Builders.Images;

/// <summary>
/// A contract for creating an image builder that can add dimensions.
/// </summary>
/// <typeparam name="TBuilder">The type of the builder to return after adding dimensions.</typeparam>
public interface IAddDimensionsImageBuilder<TBuilder>
{
    /// <summary>
    /// Adds dimensions to the builder.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <returns>A <typeparamref name="TBuilder"/>.</returns>
    TBuilder AddDimensions(int width, int height);
}