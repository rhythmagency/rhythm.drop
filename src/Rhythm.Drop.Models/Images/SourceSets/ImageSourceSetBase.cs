namespace Rhythm.Drop.Models.Images.SourceSets;

using System.Collections;
using System.Collections.Generic;
using Rhythm.Drop.Models.Images;

/// <summary>
/// A base implementation of <see cref="IImageSourceSet"/>
/// </summary>
public abstract class ImageSourceSetBase : IImageSourceSet
{
    protected readonly List<IImageSourceSetItem> _items = new();

    /// <inheritdoc/>
    public int Count => _items.Count;

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