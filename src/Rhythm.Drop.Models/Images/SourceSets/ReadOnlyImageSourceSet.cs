namespace Rhythm.Drop.Models.Images.SourceSets;

using Rhythm.Drop.Models.Images;
using System.Collections.Generic;

/// <summary>
/// A read only implementation of <see cref="IReadOnlyImageSourceSet"/>.
/// </summary>
/// <remarks>
/// Constructs a <see cref="ReadOnlyImageSourceSet"/> from an existing collection of items.
/// </remarks>
/// <param name="items">The items.</param>
public sealed class ReadOnlyImageSourceSet(IReadOnlyCollection<IImageSourceSetItem> items) : ImageSourceSetBase(items), IReadOnlyImageSourceSet
{

    /// <summary>
    /// Returns an empty <see cref="IReadOnlyImageSourceSet"/>.
    /// </summary>
    /// <returns>A <see cref="IReadOnlyImageSourceSet"/>.</returns>
    public static IReadOnlyImageSourceSet Empty()
    {
        return new ReadOnlyImageSourceSet(Array.Empty<IImageSourceSetItem>());
    }
}