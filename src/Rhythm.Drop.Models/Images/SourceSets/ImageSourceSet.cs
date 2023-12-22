namespace Rhythm.Drop.Models.Images.SourceSets;

using System.Collections.Generic;

/// <summary>
/// An image source set suitable of making modifications.
/// </summary>
public sealed class ImageSourceSet : ImageSourceSetBase
{
    /// <summary>
    /// Constructs an empty <see cref="ImageSourceSet"/>.
    /// </summary>
    public ImageSourceSet() : this(Array.Empty<IImageSourceSetItem>())
    {
    }

    /// <summary>
    /// Constructs an <see cref="ImageSourceSet"/> from an existing collection of items.
    /// </summary>
    /// <param name="items"></param>
    public ImageSourceSet(IReadOnlyCollection<IImageSourceSetItem> items) : base(items)
    {
    }

    /// <summary>
    /// Adds an item to this source set.
    /// </summary>
    /// <param name="item">The item.</param>
    public void Add(IImageSourceSetItem item)
    {
        _items.Add(item);
    }

    /// <summary>
    /// Adds multiple items to this source set.
    /// </summary>
    /// <param name="items">The items.</param>
    public void AddRange(IReadOnlyCollection<IImageSourceSetItem> items)
    {
        _items.AddRange(items);
    }
}