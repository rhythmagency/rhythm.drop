namespace Rhythm.Drop.Infrastructure.Factories.Links;

using Rhythm.Drop.Infrastructure.Builders.Links;

/// <summary>
/// The default implementation of <see cref="ILinkBuilderFactory"/>.
/// </summary>
internal sealed class DefaultLinkBuilderFactory : ILinkBuilderFactory
{
    /// <inheritdoc/>
    public ILinkBuilder Create()
    {
        return new DefaultLinkBuilder();
    }
}