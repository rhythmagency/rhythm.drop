namespace Rhythm.Drop.Infrastructure.Factories.Links;

using Rhythm.Drop.Infrastructure.Builders.Links;

/// <summary>
/// A contract for creating a <see cref="ILinkBuilder"/>.
/// </summary>
public interface ILinkBuilderFactory
{
    /// <summary>
    /// Create a <see cref="ILinkBuilder"/>.
    /// </summary>
    /// <returns>A <see cref="ILinkBuilder"/>.</returns>
    ILinkBuilder Create();
}