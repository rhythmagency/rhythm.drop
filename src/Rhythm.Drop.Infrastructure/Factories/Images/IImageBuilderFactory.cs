namespace Rhythm.Drop.Infrastructure.Factories.Images;

using Rhythm.Drop.Infrastructure.Builders.Images;

/// <summary>
/// A contract for creating a <see cref="IImageBuilder"/>.
/// </summary>
public interface IImageBuilderFactory
{
    /// <summary>
    /// Create a <see cref="IImageBuilder"/>.
    /// </summary>
    /// <returns>A <see cref="IImageBuilder"/>.</returns>
    IImageBuilder Create();
}