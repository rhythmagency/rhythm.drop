namespace Rhythm.Drop.Models.Images.SourceSets;

using System.Collections.Generic;
using Rhythm.Drop.Models.Images;

/// <summary>
/// A read only implementation of <see cref="IReadOnlyImageSourceSet"/>.
/// </summary>
public sealed class ReadOnlyImageSourceSet : ImageSourceSetBase, IReadOnlyImageSourceSet
{
    /// <summary>
    /// Constructs a <see cref="ReadOnlyImageSourceSet"/> from an existing collection of items.
    /// </summary>
    /// <param name="items">The items.</param>
    public ReadOnlyImageSourceSet(IReadOnlyCollection<IImageSourceSetItem> items) : base(items)
    {
    }

    /// <summary>
    /// Returns an empty <see cref="IReadOnlyImageSourceSet"/>.
    /// </summary>
    /// <returns>A <see cref="IReadOnlyImageSourceSet"/>.</returns>
    public static IReadOnlyImageSourceSet Empty()
    {
        return new ReadOnlyImageSourceSet(Array.Empty<IImageSourceSetItem>());
    }
}