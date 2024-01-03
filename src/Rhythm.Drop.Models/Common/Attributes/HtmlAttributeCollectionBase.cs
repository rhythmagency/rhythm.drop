namespace Rhythm.Drop.Models.Common.Attributes;

using System.Collections;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// An abstract implementation of <see cref="IHtmlAttributeCollectionBase"/>.
/// </summary>
public abstract class HtmlAttributeCollectionBase : IHtmlAttributeCollectionBase
{
    /// <summary>
    /// The internal dictionary.
    /// </summary>
    protected readonly IDictionary<string, object?> _dictionary = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Constructs a new collection based on an existing collection.
    /// </summary>
    /// <param name="attributes">The attributes.</param>
    public HtmlAttributeCollectionBase(IHtmlAttributeCollectionBase attributes)
    {
        foreach (var attribute in attributes)
        {
            _dictionary[attribute.Name] = attribute.Value;
        }
    }

    /// <summary>
    /// Constructs an empty collection.
    /// </summary>
    protected HtmlAttributeCollectionBase()
    {
    }

    /// <inheritdoc/>
    public int Count => _dictionary.Count;

    /// <inheritdoc/>
    public IEnumerator<IHtmlAttribute> GetEnumerator()
    {
        foreach (var kvp in _dictionary)
        {
            yield return new HtmlAttribute(kvp.Key, kvp.Value);
        }
    }

    /// <inheritdoc/>
    public bool HasAttribute(string name)
    {
        return _dictionary.ContainsKey(name);
    }

    /// <inheritdoc/>
    public bool TryGetValue<T>(string name, [NotNullWhen(true)] out T? value)
    {
        if (_dictionary.TryGetValue(name, out var dictionaryValue) is false)
        {
            value = default;
            return false;
        }

        if (dictionaryValue is not T dictionaryValueAsT)
        {
            value = default;
            return false;
        }

        value = dictionaryValueAsT;
        return dictionaryValueAsT is not null;
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}