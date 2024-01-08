namespace Rhythm.Drop.Models.Common.Attributes;

/// <summary>
/// An implementation of <see cref="IHtmlAttributeCollectionBase"/> ready for modifications.
/// </summary>
public sealed class HtmlAttributeCollection : HtmlAttributeCollectionBase, IHtmlAttributeCollection
{
    /// <summary>
    /// Constructs an empty <see cref="HtmlAttributeCollection"/>.
    /// </summary>
    public HtmlAttributeCollection() : base()
    {
    }

    /// <summary>
    /// Constructs a <see cref="HtmlAttributeCollection"/> from an existing collection.
    /// </summary>
    /// <param name="attributes">The existing collection.</param>
    public HtmlAttributeCollection(IHtmlAttributeCollectionBase attributes) : base(attributes)
    {
    }

    /// <inheritdoc/>
    public void RemoveAll()
    {
        _dictionary.Clear();
    }

    /// <inheritdoc/>
    public bool RemoveAttribute(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return false;
        }

        return _dictionary.Remove(name);
    }

    /// <inheritdoc/>
    public void SetAttribute(string name, object? value)
    {
        if (string.IsNullOrEmpty(name))
        {
            return;
        }

        _dictionary[name] = value;
    }

    /// <inheritdoc/>
    public void SetAttributes(IHtmlAttributeCollectionBase attributes)
    {
        foreach (var attribute in attributes)
        {
            SetAttribute(attribute.Name, attribute.Value);
        }
    }

    /// <inheritdoc/>
    public void SetAttributes(IReadOnlyCollection<KeyValuePair<string, object?>> kvps)
    {
        foreach (var kvp in kvps)
        {
            SetAttribute(kvp.Key, kvp.Value);
        }
    }

    /// <inheritdoc/>
    public IReadOnlyHtmlAttributeCollection ToReadOnly()
    {
        return new ReadOnlyHtmlAttributeCollection(this);
    }
}