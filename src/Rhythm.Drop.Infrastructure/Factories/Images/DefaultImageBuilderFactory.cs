namespace Rhythm.Drop.Infrastructure.Factories.Images;

using Rhythm.Drop.Infrastructure.Builders.Images;

/// <summary>
/// The default implementation of <see cref="IImageBuilderFactory"/>.
/// </summary>
internal sealed class DefaultImageBuilderFactory : IImageBuilderFactory
{
    /// <inheritdoc/>
    public IImageBuilder Create()
    {
        return new DefaultImageBuilder();
    }
}