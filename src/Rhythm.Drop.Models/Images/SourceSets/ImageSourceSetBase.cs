namespace Rhythm.Drop.Models.Images.SourceSets;

using Rhythm.Drop.Models.Images;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A base implementation of <see cref="IImageSourceSet"/>
/// </summary>
public abstract class ImageSourceSetBase : IImageSourceSet
{
    /// <summary>
    /// The internal list.
    /// </summary>
    protected readonly List<IImageSourceSetItem> _items = [];

    /// <inheritdoc/>
    public int Count => _items.Count;

    /// <summary>
    /// Constructs a <see cref="ImageSourceSetBase"/> with existing source set items.
    /// </summary>
    /// <param name="items">The items.</param>
    public ImageSourceSetBase(IReadOnlyCollection<IImageSourceSetItem> items)
    {
        _items.AddRange(items);
    }

    /// <inheritdoc/>
    public IEnumerator<IImageSourceSetItem> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Converts the current <see cref="IImageSourceSet"/> into a <see cref="IReadOnlyImageSourceSet"/>.
    /// </summary>
    /// <returns>A <see cref="IReadOnlyImageSourceSet"/>.</returns>
    public IReadOnlyImageSourceSet ToReadOnly()
    {
        return new ReadOnlyImageSourceSet(this);
    }

    /// <inheritdoc/>
    public string? ToMarkupString()
    {
        var validItems = _items.Select(x => x.ToMarkupString()).Where(x => string.IsNullOrEmpty(x) is false).ToArray();

        return string.Join(", ", validItems);
    }
}